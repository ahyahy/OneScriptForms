using System;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;
using System.IO;
using System.Drawing;
using System.Drawing.Design;
using System.Diagnostics;
using System.Data;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using Subro.IO;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

#region файл Support.cs

// Код создан на основе разработки автора Robert.Verpalen https://www.codeproject.com/Tips/995958/DataGridViewGrouper под лицензией 
// The Code Project Open License (CPOL) 1.02 https://www.codeproject.com/info/cpol10.aspx
		
namespace Subro.IO
{
    public static class IOFunctions
    {
        public static SimpleObjectSerializer Serialize(object o, Stream s)
        {
            var os = new SimpleObjectSerializer(o);
            os.SerializeTo(s);
            return os;
        }

        public static byte[] Serialize(object o)
        {
            var os = new SimpleObjectSerializer(o);
            return os.Serialize();
        }

        public static byte[] Serialize(object o, SimpleObjectFieldSerializationMode FieldMode)
        {
            var os = new SimpleObjectSerializer(o, FieldMode);
            return os.Serialize();
        }

        public static object Deserialize(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            using (var b = new BinaryReader(ms))
            {
                return new SimpleObjectDeserializer(b).Object;
            }
        }

        public static object Deserialize(BinaryReader b)
        {
            return new SimpleObjectDeserializer(b).Object;
        }

        public static SimpleObjectFieldSerializationMode DefaultFieldSerialization = SimpleObjectFieldSerializationMode.Fields;

        public static string GetTempFile(string Extension)
        {
            if (Extension == null) return Path.GetTempFileName();
            return Path.Combine(Path.GetTempPath(), Path.ChangeExtension(Guid.NewGuid().ToString(), Extension));
        }
    }

    public enum SimpleObjectFieldSerializationMode
    {
        // То же, что и двоичная сериализация: открытые и закрытые поля.
        Fields,
        // То же, что и xml: общедоступные поля и свойства, доступные для записи.
        PublicFieldsAndProperties,
    }

    public abstract class SimpleObjectSerializationBase
    {
        public readonly TypeCode TypeCode;
        public readonly object Object;
        public readonly bool IsArray;
        protected readonly DefinitionList defs;
        protected readonly TypeReference TypeRef;
        protected int ObjectIndex;

        protected const byte CommandArraySpecifier = 128;
        protected const byte TypeCodeCompressedStringCollection = 64;
        protected const byte TypeCodeTypeCollection = 65;
        protected const byte TypeCodePreviousObject = 66;
        protected const BindingFlags Fieldflags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        SimpleObjectSerializationBase(DefinitionList defs)
        {
            this.defs = defs;
        }

        protected SimpleObjectSerializationBase(object Value, DefinitionList defs) : this(defs)
        {
            this.Object = Value;
            if (Value == null)
            {
                return;
            }

            var type = Value.GetType();
            if (type.IsArray)
            {
                IsArray = true;
                type = type.GetElementType();
            }
            this.TypeCode = Type.GetTypeCode(type);
            if (TypeCode == TypeCode.Object)
            {
                TypeRef = defs.RegisterType(type);
            }

            if (NeedRegister)
            {
                defs.Register(Object, this);
            }
        }

        protected bool NeedRegister
        {
            get
            {
                return IsArray || TypeCode == TypeCode.Object;
            }
        }

        // Конструктор десериализации.
        protected SimpleObjectSerializationBase(BinaryReader b, DefinitionList defs) : this(defs)
        {
            var by = b.ReadByte();

            while (true)
            {
                if (by == TypeCodeCompressedStringCollection)
                {
                    defs.Strings.Deserialize(b);
                }
                else if (by == TypeCodeTypeCollection)
                {
                    defs.DeserializeTypes(b);
                }
                else if (by == TypeCodePreviousObject)
                {
                    ObjectIndex = b.ReadUInt16();
                    var po = defs.Objects[ObjectIndex];
                    Object = po.Object;
                    TypeCode = po.Serializer.TypeCode;
                    IsArray = po.Serializer.IsArray;
                    return;
                }
                else
                {
                    break;
                }

                by = b.ReadByte();
            }

            if ((by & CommandArraySpecifier) > 0)
            {
                IsArray = true;
                by ^= CommandArraySpecifier;
            }

            if (by == 0)
            {
                return;
            }
            TypeCode = (TypeCode)by;

            if (TypeCode == TypeCode.Object)
            {
                var tn = b.ReadUInt16();
                TypeRef = defs.GetType(tn);
            }
            this.Object = Restore(b);
        }

        protected virtual object Restore(BinaryReader b)
        {
            return null;
        }

        protected class RegisteredObject
        {
            public object Object;
            public SimpleObjectSerializationBase Serializer;
            public int Index;
        }

        protected class DefinitionList
        {
            List<TypeReference> types = new List<TypeReference>();
            public readonly StringCompacterCollection Strings = new StringCompacterCollection();
            public readonly List<RegisteredObject> Objects = new List<RegisteredObject>();

            public TypeReference RegisterType(Type type)
            {
                var tr = types.FirstOrDefault(t => t.Type == type);
                if (tr == null)
                {
                    tr = new TypeReference(
                         type,
                         Strings.Add(type.FullName + ", " + type.Assembly.GetName().Name),
                         types.Count);
                    // if (tr.Constructor == null)throw new Exception(type.FullName + " is not valid for serialization: the object does not contain a parameterless constructor");
                    types.Add(tr);
                }
                return tr;
            }

            public RegisteredObject Register(object obj, SimpleObjectSerializationBase o)
            {
                var r = new RegisteredObject { Object = obj, Serializer = o, Index = Objects.Count };
                Objects.Add(r);
                o.ObjectIndex = r.Index;
                return r;
            }

            public TypeReference GetType(int i)
            {
                return types[i];
            }

            public int AddString(string s)
            {
                return Strings.Add(s);
            }

            internal void Serialize(SimpleObjectSerializer s)
            {
                var w = s.Writer;
                if (Strings.Count > 0)
                {
                    w.Write(TypeCodeCompressedStringCollection);
                    Strings.Serialize(s);
                }
                if (types.Count > 0)
                {
                    w.Write(TypeCodeTypeCollection);
                    w.Write((UInt16)types.Count);
                    for (int i = 0; i < types.Count; i++)
                    {
                        w.Write((UInt16)types[i].StringIndex);
                    }
                }
            }

            public SimpleObjectSerializer NullValueSerializer;

            public void DeserializeTypes(BinaryReader b)
            {
                types.Clear();
                int cnt = b.ReadUInt16();
                for (int i = 0; i < cnt; i++)
                {
                    int ti = b.ReadUInt16();
                    var name = Strings[ti];
                    Type type = null;
                    try
                    {
                        type = Type.GetType(name, false);
                    }
                    catch { }

                    if (type == null)
                    {
                        if (clean(ref name))
                        {
                            try
                            {
                                type = Type.GetType(name, false);
                            }
                            catch { }
                        }

                        if (type == null)
                        {
                            throw new TypeLoadException("Could not determine type for " + name + ". Does the executing assembly contain the specified assembly?");
                        }
                    }
                    types.Add(new TypeReference(type, ti, i));
                }
            }

            // public bool IgnoreTypeErrors = true;

            bool clean(ref string name)
            {
                var cleaned = System.Text.RegularExpressions.Regex.Replace(name, @",\s*Version=[0-9\.]+", string.Empty);
                if (cleaned == name)
                {
                    return false;
                }
                name = cleaned;
                return true;
            }
        }

        public class TypeReference
        {
            public readonly Type Type;
            public readonly int StringIndex;
            public readonly int Index;

            public TypeReference(Type Type, int StringIndex, int Index)
            {
                this.Type = Type;
                this.StringIndex = StringIndex;
                this.Index = Index;
            }

            ConstructorInfo ci;
            public ConstructorInfo Constructor
            {
                get
                {
                    if (ci == null)
                    {
                        ci = Type.GetConstructor(Fieldflags, null, Type.EmptyTypes, null);
                    }
                    return ci;
                }
            }
        }

        public override string ToString()
        {
            if (Object == null)
            {
                return null;
            }
            return Object.ToString();
        }

        public bool IsEmpty
        {
            get
            {
                return TypeCode == TypeCode.Empty;
            }
        }
    }

    public interface IContentWriter
    {
        void WriteContents(BinaryWriter w);
    }

    public class SimpleObjectSerializer : SimpleObjectSerializationBase, IContentWriter
    {
        public readonly SimpleObjectFieldSerializationMode FieldMode;
        public readonly IContentWriter[] Children;
        public readonly ICustomSerializer CustomSerializer;
        protected readonly int StringIndex;

        public SimpleObjectSerializer(object Value) : this(Value, IOFunctions.DefaultFieldSerialization)
        {
        }

        public SimpleObjectSerializer(object Value, SimpleObjectFieldSerializationMode FieldMode) : this(Value, FieldMode, new DefinitionList())
        {
        }

        private SimpleObjectSerializer(object Value, SimpleObjectFieldSerializationMode FieldMode, DefinitionList Types) : base(Value, Types)
        {
            this.FieldMode = FieldMode;
            if (IsEmpty)
            {
                return;
            }

            if (IsArray)
            {
                Children = GetArrayValues().ToArray();
            }
            else if (TypeCode == TypeCode.Object)
            {
                this.CustomSerializer = Object as ICustomSerializer;
                if (CustomSerializer != null && CustomSerializer.Initialize(this))
                {
                    return;
                }
                Children = GetFields().ToArray();
            }
            else if (TypeCode == TypeCode.String)
            {
                StringIndex = defs.Strings.Add((string)Value);
            }
        }

        IEnumerable<IContentWriter> GetArrayValues()
        {
            var arr = (Array)Object;
            for (int i = 0; i < arr.Length; i++)
            {
                var o = arr.GetValue(i);
                yield return GetSubValue(o);
            }
        }

        IContentWriter GetSubValue(object o)
        {
            if (o == null)
            {
                if (defs.NullValueSerializer == null)
                {
                    defs.NullValueSerializer = new SimpleObjectSerializer(null, FieldMode, defs);
                }
                return defs.NullValueSerializer;
            }
            var res = defs.Objects.FirstOrDefault(r => r.Object == o);
            if (res == null)
            {
                return new SimpleObjectSerializer(o, FieldMode, defs);
            }
            return new PreviousObjectWriter { Object = (SimpleObjectSerializer)res.Serializer };
        }

        class PreviousObjectWriter : IContentWriter
        {
            public SimpleObjectSerializer Object;

            public void WriteContents(BinaryWriter w)
            {
                w.Write(TypeCodePreviousObject);
                w.Write((UInt16)Object.ObjectIndex);
            }
        }

        IEnumerable<FieldReference> GetFields()
        {
            var vars = GetVariables(TypeRef.Type).Select(mi => new MemberValue { Member = mi }).Where(m => ShouldSerialize(m.Member, ref m.Value)).ToArray();

            foreach (var mi in vars)
            {
                var o = GetSubValue(mi.Value);
                yield return new FieldReference
                {
                    FieldIndex = defs.Strings.Add(mi.Member.Name),
                    Serializer = o
                };
            }
        }

        BinaryWriter w;
        public BinaryWriter Writer
        {
            get { return w; }
        }

        public void SerializeTo(Stream s)
        {
            var b = new BinaryWriter(s);
            SerializeTo(b);
        }

        void writeindex(int i)
        {
            w.Write((UInt16)i);
        }

        void IContentWriter.WriteContents(BinaryWriter w)
        {
            WriteContents(w);
        }

        void WriteContents(BinaryWriter w)
        {
            this.w = w;

            if (IsEmpty)
            {
                WriteEmpty();
                return;
            }

            var tc = (byte)TypeCode;
            if (IsArray)
            {
                tc |= CommandArraySpecifier;
            }
            w.Write(tc);

            if (TypeRef != null)
            {
                writeindex(TypeRef.Index);
            }

            if (CustomSerializer != null)
            {
                if (CustomSerializer.Serialize(this))
                {
                    return;
                }
            }

            if (Children != null)
            {
                if (IsArray)
                {
                    w.Write(Children.Length);
                }
                else
                {
                    w.Write((UInt16)Children.Length);
                }
                foreach (var o in Children)
                {
                    o.WriteContents(w);
                }
            }
            else if (TypeCode != TypeCode.DBNull)
            {
                WriteValue();
            }
        }

        public void SerializeTo(BinaryWriter w)
        {
            this.w = w;

            //write defs
            defs.Serialize(this);

            //write
            WriteContents(w);
        }

        public byte[] Serialize()
        {
            using (var ms = new MemoryStream())
            {
                SerializeTo(ms);
                return ms.ToArray();
            }
        }

        void WriteEmpty()
        {
            w.Write((byte)0);
        }

        public void WriteSubValue(object value)
        {
            if (value == null)
            {
                WriteEmpty();
            }
            else
            {
                GetSubValue(value).WriteContents(w);
            }
        }

        void WriteValue()
        {
            if (TypeCode == TypeCode.DateTime)
            {
                w.Write(((DateTime)Object).Ticks);
            }
            else if (TypeCode == TypeCode.String)
            {
                w.Write((UInt16)StringIndex);
            }
            else if (TypeCode == TypeCode.Int32)
            {
                w.Write((int)Object);
            }
            else if (TypeCode == TypeCode.Int64)
            {
                w.Write((long)Object);
            }
            else if (TypeCode == TypeCode.UInt32)
            {
                w.Write((uint)Object);
            }
            else if (TypeCode == TypeCode.UInt64)
            {
                w.Write((ulong)Object);
            }
            else if (TypeCode == TypeCode.Double)
            {
                w.Write((double)Object);
            }
            else if (TypeCode == TypeCode.Single)
            {
                w.Write((float)Object);
            }
            else if (TypeCode == TypeCode.Byte)
            {
                w.Write((byte)Object);
            }
            else if (TypeCode == TypeCode.Boolean)
            {
                w.Write((bool)Object);
            }
            else
            {
                var type = Type.GetType("System." + TypeCode);
                var p = w.GetType().GetMethod("Write", new Type[] { type });
                p.Invoke(w, new object[] { Object });
            }
        }

        protected bool ShouldSerialize(MemberInfo m, ref object val)
        {
            if (!m.GetIsWritable())
            {
                // Не сериализуйте поля и свойства, доступные только для чтения.
                return false;
            }
            if (m.GetCustomAttributes(typeof(NonSerializedAttribute), false).Length > 0)
            {
                // Пропускать поля/реквизиты с несериализованным атрибутом.
                return false;
            }
            var shs = m.DeclaringType.GetMethod(
                "ShouldSerialize" + m.Name,
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public,
                null,
                Type.EmptyTypes,
                null);
            if (shs != null && !(bool)shs.Invoke(Object, null))
            {
                return false;
            }
            val = m.GetValue(Object);
            if (val is Pointer || val is IntPtr)
            {
                return false;
            }
            var dv = (DefaultValueAttribute)m.GetCustomAttributes(typeof(DefaultValueAttribute), true).FirstOrDefault();
            if (dv == null)
            {
                return true;
            }
            return !object.Equals(val, dv.Value);
        }

        protected virtual IEnumerable<MemberInfo> GetVariables(Type type)
        {
            if (FieldMode == SimpleObjectFieldSerializationMode.Fields)
            {
                while (type != typeof(object))
                {
                    foreach (var m in type.GetFields(Fieldflags))
                    {
                        yield return m;
                    }
                    type = type.BaseType;
                }
            }
            else
            {
                foreach (var m in type.GetFields())
                {
                    yield return m;
                }
                foreach (var m in type.GetProperties())
                {
                    yield return m;
                }
            }
        }

        class FieldReference : IContentWriter
        {
            public IContentWriter Serializer;
            public int FieldIndex;
            public void WriteContents(BinaryWriter w)
            {
                w.Write((UInt16)FieldIndex);
                Serializer.WriteContents(w);
            }
        }

        class MemberValue
        {
            public MemberInfo Member;
            public object Value;
        }
    }

    public class SimpleObjectDeserializer : SimpleObjectSerializationBase
    {
        internal SimpleObjectDeserializer(BinaryReader b) : this(b, new DefinitionList())
        {
        }

        private SimpleObjectDeserializer(BinaryReader b, DefinitionList types) : base(b, types)
        {
        }

        Type GetObjectType()
        {
            if (TypeRef == null)
            {
                return Type.GetType("System." + TypeCode);
            }
            return TypeRef.Type;
        }

        public BinaryReader Reader
        {
            get { return b; }
        }

        BinaryReader b;

        protected override object Restore(BinaryReader reader)
        {
            this.b = reader;
            if (IsArray)
            {
                return RestoreArray();
            }
            else if (TypeCode == TypeCode.Object)
            {
                return restoreobject();
            }
            else if (TypeCode == TypeCode.DateTime)
            {
                return new DateTime(b.ReadInt64());
            }
            else if (TypeCode == TypeCode.Int32)
            {
                return b.ReadInt32();
            }
            else if (TypeCode == TypeCode.String)
            {
                return defs.Strings[b.ReadUInt16()];
            }
            else if (TypeCode == TypeCode.DBNull)
            {
                return DBNull.Value;
            }
            else
            {
                // Наиболее распространенные типы имеют строгие ссылки, на другие методы ссылаются с помощью отражения.
                var p = b.GetType().GetMethod("Read" + TypeCode.ToString());
                return p.Invoke(b, null);
            }
        }

        public Array RestoreArray()
        {
            var len = b.ReadInt32();
            var arr = Array.CreateInstance(GetObjectType(), len);
            defs.Register(arr, this);
            for (int i = 0; i < len; i++)
            {
                var val = GetSubValue();
                arr.SetValue(val, i);
            }
            return arr;
        }

        public object GetSubValue()
        {
            return new SimpleObjectDeserializer(b, defs).Object;
        }

        object restoreobject()
        {
            var ci = TypeRef.Constructor;
            if (ci == null)
            {
                throw new Exception("Cannot create an instance of " + TypeRef.Type.FullName);
            }
            var o = ci.Invoke(null);
            defs.Register(o, this);
            var co = o as ICustomSerializer;
            if (co != null)
            {
                if (co.Deserialize(this)) return o;
            }

            var cnt = b.ReadUInt16(); // Количество сериализованных полей объекта.
            if (cnt > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    int fi = b.ReadUInt16();
                    string name = defs.Strings[fi];
                    var mi = GetMember(TypeRef.Type, name);
                    var val = GetSubValue();
                    if (mi == null)
                    {
                        // Возможная разница в версии.
                        continue;
                    }
                    mi.SetValue(o, val);
                }
            }
            return o;
        }

        MemberInfo GetMember(Type type, string field)
        {
            var mi = type.GetMember(field, MemberTypes.Field | MemberTypes.Property, Fieldflags);
            if (mi.Length == 0)
            {
                if (type == typeof(object))
                {
                    return null;
                }
                return GetMember(type.BaseType, field);
            }
            return mi[0];
        }
    }

    public interface ICustomSerializer
    {
        bool Initialize(SimpleObjectSerializer serializer);
        bool Serialize(SimpleObjectSerializer serializer);
        bool Deserialize(SimpleObjectDeserializer deserializer);
    }

    public class StringCompacter
    {
        List<char> chars;

        public StringCompacter()
        {
            chars = new List<char>();
            for (char c = 'A'; c < 91; c++)
            {
                chars.Add(c);
                chars.Add(char.ToLower(c));
            }
            chars.AddRange("._+, <>");
            setbase();
        }

        public StringCompacter(IEnumerable<char> chars)
        {
            this.chars = new List<char>(chars);
            setbase();
        }

        public StringCompacter(params char[] chars)
        {
            this.chars = new List<char>(chars);
            setbase();
        }

        void setbase()
        {
            Base = (int)Math.Ceiling(Math.Log(chars.Count + 1, 2));
        }

        int Base;

        public char[] GetChars()
        {
            return chars.ToArray();
        }

        public byte[] Serialize(string s)
        {
            var ba = new System.Collections.BitArray(s.Length * Base);

            int pos = 0;
            foreach (var c in s)
            {
                int mask = 1;
                int val = chars.IndexOf(c) + 1;
                if (val == 0)
                {
                    throw new ArgumentException();
                }
                for (int i = 0; i < Base; i++)
                {
                    if ((val & mask) > 0)
                    {
                        ba[pos] = true;
                    }
                    mask <<= 1;
                    pos++;
                }
            }

            int len = (int)Math.Ceiling((ba.Length + Base) / 8d);
            byte[] arr = new byte[len];

            ba.CopyTo(arr, 0);

            return arr;
        }

        public string Deserialize(BinaryReader b)
        {
            return Deserialize(Enumerate(b));
        }

        IEnumerable<byte> Enumerate(BinaryReader b)
        {
            var s = b.BaseStream;
            var len = s.Length;
            while (s.Position < len)
            {
                yield return b.ReadByte();
            }
        }

        StringBuilder sb;
        public string Deserialize(IEnumerable<byte> data)
        {
            if (sb == null)
            {
                sb = new StringBuilder();
            }
            else
            {
                sb.Length = 0;
            }

            var en = data.GetEnumerator();

            int pos = 256;
            byte b = 0;
            while (true)
            {
                int val = 0;
                for (int i = 0; i < Base; i++)
                {
                    if (pos > 128)
                    {
                        pos = 1;
                        if (!en.MoveNext())
                        {
                            break;
                        }
                        b = en.Current;
                    }
                    if ((b & pos) > 0)
                    {
                        val |= (1 << i);
                    }

                    pos <<= 1;
                }
                if (val == 0)
                {
                    break;
                }
                sb.Append(chars[--val]);
            }

            return sb.ToString();
        }
    }

    public class StringCompacterCollection : ICustomSerializer
    {
        List<string> list = new List<string>();

        public int Count
        {
            get { return list.Count; }
        }

        public int Add(string s)
        {
            int i = list.IndexOf(s);
            if (i == -1)
            {
                list.Add(s);
                compacter = null;
                return list.Count - 1;
            }
            return i;
        }

        public string this[int index]
        {
            get { return list[index]; }
        }

        StringCompacter compacter;

        public bool Serialize(SimpleObjectSerializer serializer)
        {
            serializer.Writer.Write((UInt16)Count);
            if (Count == 0)
            {
                return true;
            }

            if (compacter == null)
            {
                var chars = new List<char>();
                foreach (var s in list)
                {
                    foreach (var c in s)
                    {
                        if (!chars.Contains(c))
                        {
                            chars.Add(c);
                        }
                    }
                }

                compacter = new StringCompacter(chars);
            }

            serializer.Writer.Write(new string(compacter.GetChars()));
            foreach (var s in list)
            {
                serializer.Writer.Write(compacter.Serialize(s));
            }
            return true;
        }

        bool ICustomSerializer.Initialize(SimpleObjectSerializer s)
        {
            return true;
        }

        public bool SerializationHandled
        {
            get { return true; }
        }

        internal void Deserialize(BinaryReader reader)
        {
            list.Clear();
            compacter = null;
            int cnt = reader.ReadUInt16();
            if (cnt > 0)
            {
                var chars = reader.ReadString();
                compacter = new StringCompacter(chars);

                for (int i = 0; i < cnt; i++)
                {
                    list.Add(compacter.Deserialize(reader));
                }
            }
        }

        public bool Deserialize(SimpleObjectDeserializer deserializer)
        {
            Deserialize(deserializer.Reader);
            return true;
        }
    }
}

namespace Subro
{
    public static class ReflectionExtensions
    {
        [DebuggerHidden]
        public static object GetValue(this MemberInfo mi, object o)
        {
            //if (o == null) return null; // Может быть статичным.
            if (mi is PropertyInfo)
            {
                return ((PropertyInfo)mi).GetValue(o, null);
            }
            if (mi is FieldInfo)
            {
                return ((FieldInfo)mi).GetValue(o);
            }
            return null;
        }

        [DebuggerHidden]
        public static object GetValue(this PropertyInfo pi, object o)
        {
            //if (o == null) return null;
            return pi.GetValue(o, null);
        }

        public static Type GetMemberType(this MemberInfo mi)
        {
            if (mi is PropertyInfo)
            {
                return ((PropertyInfo)mi).PropertyType;
            }
            if (mi is FieldInfo)
            {
                return ((FieldInfo)mi).FieldType;
            }
            return null;
        }

        public static bool GetIsWritable(this MemberInfo mi)
        {
            if (mi is FieldInfo)
            {
                return !((FieldInfo)mi).IsInitOnly;
            }
            return ((PropertyInfo)mi).CanWrite;
        }

        public static IEnumerable<MemberInfo> GetFieldsAndProperties(this Type type)
        {
            MemberInfo[] fields = type.GetFields();
            return fields.Concat(type.GetProperties());
        }

        [DebuggerHidden]
        public static void SetValue(this MemberInfo mi, object obj, object value)
        {
            if (mi is PropertyInfo)
            {
                ((PropertyInfo)mi).SetValue(obj, value, null);
            }
            else
            {
                ((FieldInfo)mi).SetValue(obj, value);
            }
        }

        public static IEnumerable<T> GetAttributes<T>(this ICustomAttributeProvider cap)
        {
            return from a in cap.GetCustomAttributes(typeof(T), true) select (T)a;
        }

        public static T GetAttribute<T>(this ICustomAttributeProvider cap) where T : Attribute
        {
            return GetAttributes<T>(cap).FirstOrDefault();
        }
    }
}

namespace Subro
{
    // Comparer, который пытается найти "самый сильный" компаратор для типа. 
    // Если тип реализует универсальный IComparable, он используется.
    // В противном случае, если он реализует обычный IComparable, он используется.
    // Если ни то, ни другое не реализовано, сравниваются версии приведенные ToString. 
    // Также поддерживаются заполняемые структуры.
    // Таким образом, DefaultComparer может сравнивать любые типы объектов и может использоваться для сортировки любого источника.
    public class GenericComparer : IGenericComparer
    {
        public GenericComparer()
        {
        }

        public GenericComparer(Type Type)
        {
            this.Type = Type;
        }

        Type type;
        public Type Type
        {
            get { return type; }
            set
            {
                if (type == value) return;
                if (value == null) throw new ArgumentNullException();
                type = value;
                reset();
            }
        }

        Type targettype;
        // Обычно совпадает с типом, но может быть установлен другой тип.
        public Type TargetType
        {
            get
            {
                if (targettype == null)
                {
                    return type;
                }
                return targettype;
            }
            set
            {
                if (TargetType == value)
                {
                    return;
                }
                targettype = value;
                reset();
            }
        }

        void reset()
        {
            comp = null;
            eq = null;
        }

        IComparer comp;
        IEqualityComparer eq;

        public bool Descending
        {
            get { return factor < 0; }
            set { factor = value ? -1 : 1; }
        }

        int factor = 1;

        public int Compare(object x, object y)
        {
            if (x == y)
            {
                return 0;
            }
            if (x == null)
            {
                return -factor;
            }
            if (y == null)
            {
                return factor;
            }
            if (type == null)
            {
                Type = x.GetType();
            }
            if (comp == null)
            {
                comp = CompareFunctions.GetComparer(type, TargetType);
            }
            return factor * comp.Compare(x, y);
        }

        public new bool Equals(object x, object y)
        {
            if (x == y)
            {
                return true;
            }
            if (x == null || y == null)
            {
                return false;
            }
            if (type == null)
            {
                Type = x.GetType();
            }
            if (eq == null)
            {
                eq = CompareFunctions.GetEqualityComparer(type, TargetType);
            }
            return eq.Equals(x, y);
        }

        public int GetHashCode(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return obj.GetHashCode();
        }

        public IGenericComparer ThenBy(GenericComparer cmp)
        {
            var list = new GenericComparers();
            list.Add(cmp);
            return list;
        }
    }

    public interface IGenericComparer : IComparer, IEqualityComparer
    {
        IGenericComparer ThenBy(GenericComparer cmp);
    }

    // Список для сравнения нескольких GenericComparers после одного и другого.
    public class GenericComparers : List<GenericComparer>, IGenericComparer
    {
        public int Compare(object x, object y)
        {
            return ObjectExtensions.Compare(this, x, y);
        }

        public new bool Equals(object x, object y)
        {
            return this.All(c => c.Equals(x, y));
        }

        public int GetHashCode(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return obj.GetHashCode();
        }

        public IGenericComparer ThenBy(GenericComparer cmp)
        {
            Add(cmp);
            return this;
        }
    }

    public static partial class ObjectExtensions
    {
        public static int Compare(this IEnumerable<IComparer> cmp, object x, object y)
        {
            foreach (var c in cmp)
            {
                int i = c.Compare(x, y);
                if (i != 0)
                {
                    return i;
                }
            }
            return 0;
        }
    }

    static partial class CompareFunctions
    {
        static IComparer GetGenericComparer(Type From, Type To)
        {
            return (IComparer)GetGeneric(From, To, typeof(IComparable<>));
        }

        static IEqualityComparer GetGenericEqualityComparer(Type From, Type To)
        {
            return (IEqualityComparer)GetGeneric(From, To, typeof(IEquatable<>), typeof(IComparable<>));
        }

        static Type GetInnerType(Type type)
        {
            if (type.IsGenericType && typeof(Nullable<>) == type.GetGenericTypeDefinition())
            {
                return type.GetGenericArguments()[0];
            }
            return type;
        }

        static bool hasbase(Type type)
        {
            return type.BaseType != null && type.BaseType != typeof(object);
        }

        static object GetGeneric(Type From, Type To, params Type[] GenericBaseTypes)
        {
            //From = GetBaseType(From);
            while (true)
            {
                foreach (var g in GenericBaseTypes)
                {
                    var type = To;
                    while (type != null)
                    {
                        if (g.MakeGenericType(type).IsAssignableFrom(From))
                        {
                            if (g == typeof(IEquatable<>))
                            {
                                return Activator.CreateInstance(typeof(StrongEquatable<,>).MakeGenericType(From, type));
                            }
                            return Activator.CreateInstance(typeof(StrongCompare<,>).MakeGenericType(From, type));
                        }
                        var inner = GetInnerType(type);
                        if (inner == type)
                        {
                            type = type.BaseType;
                        }
                        else
                        {
                            type = inner;
                        }
                    }
                }

                if (hasbase(From))
                {
                    From = From.BaseType;
                }
                else
                {
                    return null;
                }
            }
            //return null;
        }

        internal static IComparer GetComparer(Type From, Type To)
        {
            if (From == To && From == typeof(string))
            {
                return new StringComparer();
            }
            From = GetInnerType(From);

            var gen = GetGenericComparer(From, To);
            if (gen != null)
            {
                return gen;
            }
            else if (typeof(IComparable).IsAssignableFrom(From))
            {
                return (IComparer)Activator.CreateInstance(typeof(NonGenericCompare<>).MakeGenericType(From));
            }
            return new StringComparer();
        }

        internal static IEqualityComparer GetEqualityComparer(Type From, Type To)
        {
            if (From == To && From == typeof(string))
            {
                return new StringComparer();
            }
            From = GetInnerType(From);

            var eq = GetGenericEqualityComparer(From, To);
            if (eq != null)
            {
                return eq;
            }
            return new DefaultEquals();
        }

        class DefaultEquals : IEqualityComparer
        {
            public new bool Equals(object x, object y)
            {
                return x.Equals(y);
            }

            public int GetHashCode(object o)
            {
                return o.GetHashCode();
            }
        }
        /*
        class NullableComparer<T> : IComparer
            where T : struct
        {

            public readonly IComparer BaseComparer;
            public NullableComparer(IComparer BaseComparer)
            {
                this.BaseComparer = BaseComparer;

            }

            object getval(object o)
            {
                return ((Nullable<T>)o).Value;
            }

            public int Compare(object x, object y)
            {
                return BaseComparer.Compare(getval(x), getval(y));
            }
        }*/

        class StrongEquatable<F, T> : IEqualityComparer where F : IEquatable<T>
        {
            public new bool Equals(object x, object y)
            {
                return ((F)x).Equals((T)y);
            }

            public int GetHashCode(object o)
            {
                return o.GetHashCode();
            }
        }

        class StrongCompare<F, T> : IComparer, IEqualityComparer where F : IComparable<T>
        {
            public int Compare(object x, object y)
            {
                return ((F)x).CompareTo((T)y);
            }

            public new bool Equals(object x, object y)
            {
                return Compare(x, y) == 0;
            }

            public int GetHashCode(object o)
            {
                return o.GetHashCode();
            }
        }

        class NonGenericCompare<T> : IComparer where T : IComparable
        {
            public int Compare(object x, object y)
            {
                return ((T)x).CompareTo(y);
            }
        }

        class StringComparer : IComparer, IEqualityComparer
        {
            public int Compare(object x, object y)
            {
                return string.Compare(x.ToString(), y.ToString());
            }

            public new bool Equals(object x, object y)
            {
                return string.Equals(x.ToString(), y.ToString());
            }

            public int GetHashCode(object o)
            {
                return o.GetHashCode();
            }
        }
    }

    public class GenericComparer<T> : GenericComparer, IComparer<T>
    {
        public GenericComparer() : base(typeof(T))
        {
        }

        public int Compare(T a, T b)
        {
            return base.Compare(a, b);
        }
    }

    public class GenericComparer<T1, T2> : GenericComparer
    {
        public GenericComparer() : base(typeof(T1))
        {
            TargetType = typeof(T2);
        }

        public int Compare(T1 a, T2 b)
        {
            return base.Compare(a, b);
        }

        public bool Equals(T1 a, T2 b)
        {
            return base.Equals(a, b);
        }
    }

    public class PropertyDescriptorComparer : GenericComparer
    {
        public readonly PropertyDescriptor Prop;

        public PropertyDescriptorComparer(PropertyDescriptor Prop) : this(Prop, true)
        {
        }

        public PropertyDescriptorComparer(PropertyDescriptor Prop, bool Descending) : base(Prop.PropertyType)
        {
            this.Prop = Prop;
            this.Descending = Descending;
        }
    }

    static class Parser
    {
        public static string GetFieldName(Expression Field)
        {
            var arr = GetMembers(Field).ToArray();
            if (arr.Length == 0)
            {
                throw new Exception("Could not resolve FieldName of " + Field);
            }
            if (arr.Length == 1)
            {
                return arr[0].Member.Name;
            }
            throw new Exception("Multipe field names found for " + Field);
        }

        public static string GetFieldName<RecordType, T>(Expression<Func<RecordType, T>> Field)
        {
            return GetFieldName((LambdaExpression)Field);
        }

        public static IEnumerable<string> GetFieldNames<RecordType, T>(params Expression<Func<RecordType, T>>[] Fields)
        {
            return GetMembers(Fields).Select(f => f.Member.Name);
        }

        static IEnumerable<MemberExpression> GetMembers(params Expression[] expr)
        {
            foreach (var e in expr)
            {
                var exp = e;
                if (exp is LambdaExpression)
                {
                    exp = (exp as LambdaExpression).Body;
                }
                if (exp.NodeType == ExpressionType.Convert)
                {
                    exp = (exp as UnaryExpression).Operand;
                }
                if (exp is MemberExpression)
                {
                    yield return (MemberExpression)exp;
                }
                else if (exp is NewExpression)
                {
                    foreach (var me in from ne in ((NewExpression)exp).Arguments from m in GetMembers(ne) select m)
                    {
                        yield return me;
                    }
                }
            }
        }
    }
}

#endregion

namespace Subro.Controls
{
    // Добавьте этот компонент во время выполнения или во время разработки и назначьте ему datagridview, чтобы включить группировку в этой сетке.
    // Вы также можете добавить DataGridViewGrouperControl, который создаст свой собственный grouper.
    [DefaultEvent("DisplayGroup")]
    public partial class DataGridViewGrouper : Component
    {
        public ClDataGridViewGrouper dll_obj;
        private int dataGridViewGrouperStyle;
        private bool forceAsText;
        public DataGridViewGrouperContextMenuStrip ContextMenuStrip1;

        public DataGridViewGrouper()
        {
            source.DataSourceChanged += new EventHandler(source_DataSourceChanged);
            source.Grouper = this;
        }

        public DataGridViewGrouper(DataGridView Grid) : this()
        {
            this.DataGridView = Grid;
            ContextMenuStrip1 = new DataGridViewGrouperContextMenuStrip(this);
        }

        public DataGridViewGrouper(IContainer Container) : this()
        {
            Container.Add(this);
        }

        public bool ForceAsText
        {
            get { return forceAsText; }
            set
            {
                if (!value)
                {
                    return;
                }
                Subro.Controls.DataGridViewGrouperContextMenuStrip.GroupOnItem item = (Subro.Controls.DataGridViewGrouperContextMenuStrip.GroupOnItem)ContextMenuStrip1.ForceAsText;
                if (item == null)
                {
                    return;
                }
                var cur = ContextMenuStrip1.Grouper.GroupOn;
                if (item.EqualsInfo(cur))
                {
                    if (cur is GroupWrapper)
                    {
                        ContextMenuStrip1.Grouper.GroupOn = ((GroupWrapper)cur).Grouper;
                    }
                    item.Checked = false;
                }
                else
                {
                    ContextMenuStrip1.Grouper.GroupOn = item.CreateInfo();
                    item.Checked = true;
                }
                forceAsText = value;
            }
        }

        public int DataGridViewGrouperStyle
        {
            get { return dataGridViewGrouperStyle; }
            set
            {
                Subro.Controls.DataGridViewGrouperContextMenuStrip.GroupOnItem item = null;

                if (value == 0)
                {
                    item = (Subro.Controls.DataGridViewGrouperContextMenuStrip.GroupOnItem)ContextMenuStrip1.FirstLetter;
                }
                else if (value == 1)
                {
                    item = (Subro.Controls.DataGridViewGrouperContextMenuStrip.GroupOnItem)ContextMenuStrip1.FirstWord;
                }
                else if (value == 2)
                {
                    item = (Subro.Controls.DataGridViewGrouperContextMenuStrip.GroupOnItem)ContextMenuStrip1.LastWord;
                }

                if (item == null)
                {
                    return;
                }
                var cur = ContextMenuStrip1.Grouper.GroupOn;
                if (item.EqualsInfo(cur))
                {
                    if (cur is GroupWrapper)
                    {
                        ContextMenuStrip1.Grouper.GroupOn = ((GroupWrapper)cur).Grouper;
                    }
                    item.Checked = false;
                }
                else
                {
                    ContextMenuStrip1.Grouper.GroupOn = item.CreateInfo();
                    item.Checked = true;
                }
                dataGridViewGrouperStyle = value;
            }
        }

        private DataGridView grid;

        [DefaultValue(null)]
        public DataGridView DataGridView
        {
            get { return grid; }
            set
            {
                if (grid == value)
                {
                    return;
                }

                if (grid != null)
                {
                    //grid.Sorted -= new EventHandler(grid_Sorted);
                    grid.RowPrePaint -= new DataGridViewRowPrePaintEventHandler(grid_RowPrePaint);
                    grid.RowPostPaint -= new DataGridViewRowPostPaintEventHandler(grid_RowPostPaint);
                    grid.CellBeginEdit -= new DataGridViewCellCancelEventHandler(grid_CellBeginEdit);
                    grid.CellDoubleClick -= new DataGridViewCellEventHandler(grid_CellDoubleClick);
                    grid.CellClick -= new DataGridViewCellEventHandler(grid_CellClick);
                    grid.MouseMove -= new MouseEventHandler(grid_MouseMove);
                    grid.SelectionChanged -= new EventHandler(grid_SelectionChanged);
                    grid.DataSourceChanged -= new EventHandler(grid_DataSourceChanged);
                    grid.AllowUserToAddRowsChanged -= new EventHandler(grid_AllowUserToAddRowsChanged);    
                }
                RemoveGrouping();
                selectedGroups.Clear();
                grid = value;

                if (grid != null)
                {
                    //grid.Sorted += new EventHandler(grid_Sorted);
                    grid.RowPrePaint += new DataGridViewRowPrePaintEventHandler(grid_RowPrePaint);
                    grid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(grid_RowPostPaint);
                    grid.CellBeginEdit += new DataGridViewCellCancelEventHandler(grid_CellBeginEdit);
                    grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
                    grid.CellClick += new DataGridViewCellEventHandler(grid_CellClick);
                    grid.MouseMove += new MouseEventHandler(grid_MouseMove);
                    grid.SelectionChanged += new EventHandler(grid_SelectionChanged);
                    grid.DataSourceChanged += new EventHandler(grid_DataSourceChanged);
                    grid.AllowUserToAddRowsChanged += new EventHandler(grid_AllowUserToAddRowsChanged);       
                }
            }
        }

        void grid_AllowUserToAddRowsChanged(object sender, EventArgs e)
        {
            source.CheckNewRow();
        }

        Point capturedcollapsebox = new Point(-1, -1);

        void grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < HeaderOffset && e.X >= HeaderOffset - collapseboxwidth)
            {
                DataGridView.HitTestInfo ht = grid.HitTest(e.X, e.Y);
                if (IsGroupRow(ht.RowIndex))
                {
                    var y = e.Y - ht.RowY;

                    if (y >= CollapseBox_Y_Offset && y <= CollapseBox_Y_Offset + collapseboxwidth)
                    {
                        checkcollapsedfocused(ht.ColumnIndex, ht.RowIndex);
                        return;
                    }
                }
            }            
            checkcollapsedfocused(-1, -1);
        }

        void InvalidateCapturedBox()
        {
            if (capturedcollapsebox.Y == -1)
            {
                return;
            }
            try
            {
                grid.InvalidateCell(capturedcollapsebox.X, capturedcollapsebox.Y);
            }
            catch
            {
                capturedcollapsebox = new Point(-1, -1);
            }
        }

        void checkcollapsedfocused(int col, int row)
        {
            if (capturedcollapsebox.X != col || capturedcollapsebox.Y != row)
            {
                InvalidateCapturedBox();
                capturedcollapsebox = new Point(col, row);
                InvalidateCapturedBox();
            }
        }

        void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (e.RowIndex == capturedcollapsebox.Y)
            {
                var gr = GetGroupRow(e.RowIndex);
                gr.Collapsed = !gr.Collapsed;
            }
        }

        // Выбранные строки группы хранятся отдельно, чтобы при изменении выделения сделать недействительной всю строку, а не только одну ячейку.
        List<int> selectedGroups = new List<int>();

        void grid_SelectionChanged(object sender, EventArgs e)
        {
            if (selectionset)
            {
                selectionset = false;
                invalidateselected();
            }
        }

        bool selectionset;

        void setselection()
        {
            //invalidateselected();

            selectionset = true;
            selectedGroups.Clear();
            foreach (DataGridViewCell c in grid.SelectedCells)
            {
                if (IsGroupRow(c.RowIndex))
                {
                    if (!selectedGroups.Contains(c.RowIndex))
                    {
                        selectedGroups.Add(c.RowIndex);
                    }
                }
            }
            invalidateselected();
        }
        
        void invalidateselected()
        {
            if (selectedGroups.Count == 0 || grid.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                return;
            }
            int count = grid.Rows.Count;
            foreach (int i in selectedGroups)
            {
                if (i < count)
                {
                    grid.InvalidateRow(i);
                }
            }
        }

        public void ExpandAll()
        {
            source.CollapseExpandAll(false);
        }

        public void CollapseAll()
        {
            source.CollapseExpandAll(true);
        }

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsGroupRow(e.RowIndex) && capturedcollapsebox.Y != e.RowIndex && Options.SelectRowsOnDoubleClick)
            {
                var gr = GetGroupRow(e.RowIndex);
                gr.Collapsed = false;                
                grid.SuspendLayout();
                grid.CurrentCell = grid[1, e.RowIndex + 1];
                grid.Rows[e.RowIndex].Selected = false;
                SelectGroup(e.RowIndex);
                grid.ResumeLayout();
            }
        }

        GroupRow GetGroupRow(int RowIndex)
        {
            return (GroupRow)source.Groups.Rows[RowIndex];
        }

        IEnumerable<DataGridViewRow> GetRows(int index)
        {
            var gr = GetGroupRow(index);
            
            for (int i = 0; i < gr.Count; i++)
            {
                yield return grid.Rows[++index];
            }
        }

        void SelectGroup(int offset)
        {
            foreach (DataGridViewRow row in GetRows(offset))
            {
                row.Selected = true;
            }
        }

        public GroupList Groups
        {
            get { return source.Groups; }
        }

        public bool IsGroupRow(int RowIndex)
        {
            return source.IsGroupRow(RowIndex);
        }

        void source_DataSourceChanged(object sender, EventArgs e)
        {
            OnPropertiesChanged();
        }

        void OnPropertiesChanged()
        {
            if (PropertiesChanged != null)
            {
                PropertiesChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler PropertiesChanged;

        public IEnumerable<PropertyDescriptor> GetProperties()
        {
            foreach (PropertyDescriptor pd in source.GetItemProperties(null))
            {
                yield return pd;
            }
        }

        void grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (IsGroupRow(e.RowIndex))
            {
                e.Cancel = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            DataGridView = null;
            source.Dispose();
            base.Dispose(disposing);
        }
        /*
        void grid_Sorted(object sender, EventArgs e)
        {
            ResetGrouping();
        }*/

        readonly GroupingSource source = new GroupingSource();

        public GroupingSource GroupingSource
        {
            get { return source; }
        }

        void grid_DataSourceChanged(object sender, EventArgs e)
        {
            if (!GridUsesGroupSource)
            {
                try
                {
                    source.DataSource = grid.DataSource;
                }
                catch
                {
                    source.RemoveGrouping();
                }
            }
        }

        public bool RemoveGrouping()
        {
            if (GridUsesGroupSource)
            {
                try
                {
                    grid.DataSource = source.DataSource;
                    grid.DataMember = source.DataMember;
                    source.RemoveGrouping();
                    return true;
                }
                catch { }
            }
            return false;
        }

        public event EventHandler GroupingChanged
        {
            add { source.GroupingChanged += value; }
            remove { source.GroupingChanged -= value; }
        }

        bool GridUsesGroupSource
        {
            get { return grid != null && grid.DataSource == source; }
        }

        public void ResetGrouping()
        {
            if (!GridUsesGroupSource)
            {
                return;
            }
            this.capturedcollapsebox = new Point(-1, -1);
            source.ResetGroups();
        }

        [DefaultValue(null)]
        public GroupingInfo GroupOn
        {
            get { return source.GroupOn; }
            set
            {
                if (GroupOn == value)
                {
                    return;
                }
                if (value == null)
                {
                    RemoveGrouping();
                }
                else
                {
                    CheckSource().GroupOn = value;
                }
            }
        }

        public bool IsGrouped
        {
            get { return source.IsGrouped; }
        }

        [DefaultValue(SortOrder.Ascending)]
        public SortOrder GroupSortOrder
        {
            get { return source.GroupSortOrder; }
            set { source.GroupSortOrder = value; }
        }

        [DefaultValue(null)]
        public GroupingOptions Options
        {
            get { return source.Options; }
            set { source.Options = value; }
        }

        public bool SetGroupOn(DataGridViewColumn col)
        {
            return SetGroupOn(col == null ? null : col.DataPropertyName);
        }

        public bool SetGroupOn(PropertyDescriptor Property)
        {
            return CheckSource().SetGroupOn(Property);
        }

        public void SetCustomGroup<T>(Func<T,object> GroupValueProvider, string Description = null)
        {
            CheckSource().SetCustomGroup(GroupValueProvider, Description);
        }

        public void SetGroupOnStartLetters(GroupingInfo g, int Letters)
        {
            CheckSource().SetGroupOnStartLetters(g, Letters);
        }

        public void SetGroupOnStartLetters(string Property, int Letters)
        {
            CheckSource().SetGroupOnStartLetters(Property, Letters);
        }

        public bool SetGroupOn(string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return RemoveGrouping();
            }
            return CheckSource().SetGroupOn(Name);
        }

        // Добавлено после добавления linq в фреймворк для облегчения настройки свойств.
        public bool SetGroupOn<T>(System.Linq.Expressions.Expression<Func<T, object>> Property)
        {
            if (Property == null)
            {
                return RemoveGrouping();
            }
            return CheckSource().SetGroupOn(Parser.GetFieldName(Property));
        }

        public PropertyDescriptor GetProperty(string Name)
        {
            return CheckSource().GetProperty(Name);
        }

        // Гарантирует, что datagridview использует groupingsource в качестве своего источника данных.
        GroupingSource CheckSource()
        {
            if (grid == null)
            {
                throw new Exception("Нет целевого набора Таблица (Datagridview)");
            }

            if (!GridUsesGroupSource)
            {
                source.DataSource = grid.DataSource;
                source.DataMember = grid.DataMember;
                grid.DataSource = source;
            }
            return source;
        }

        void grid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (IsGroupRow(e.RowIndex))
            {
                e.Handled = true;
                PaintGroupRow(e);                
            }
        }

        const int collapseboxwidth = 10;
        const int lineoffset = collapseboxwidth / 2;

        int HeaderOffset
        {
            get
            {
                if (grid.RowHeadersVisible)
                {
                    return grid.RowHeadersWidth;
                }
                return lineoffset * 4;
            }
        }

        Pen linepen = Pens.SteelBlue;

        bool DrawExpandCollapseLines
        {
            get { return grid.RowHeadersVisible; }
        }

        void grid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (!DrawExpandCollapseLines || e.RowIndex >= source.Count || source.GroupOn == null)
            {
                return;
            }
            int next = e.RowIndex + 1;

            int r = grid.RowHeadersWidth;
            int x = HeaderOffset - lineoffset;
            int y = e.RowBounds.Top + e.RowBounds.Height / 2;
            e.Graphics.DrawLine(linepen, x, y, r, y);

            if (next < source.Count && !IsGroupRow(next))
            {
                y = e.RowBounds.Bottom;
            }

            e.Graphics.DrawLine(linepen, x, e.RowBounds.Top, x, y);
        }

        // Это событие срабатывает, когда необходимо закрасить строку группы и запрашиваются отображаемые значения.
        public event EventHandler<GroupDisplayEventArgs> DisplayGroup
        {
            add { source.DisplayGroup += value; }
            remove { source.DisplayGroup -= value; }
        }

        public DataGridViewGrouper this[int GroupIndex]
        {
            get { return (DataGridViewGrouper)source[GroupIndex]; }
        }

        void PaintGroupRow(DataGridViewRowPrePaintEventArgs e)
        {
            var grouprow = (GroupRow)source[e.RowIndex];
            if (!selectionset)
            {
                setselection();
            }
            var info = grouprow.GetDisplayInfo(selectedGroups.Contains(e.RowIndex));
            if (info == null || info.Cancel)
            {
                return; // Отмененный.
            }

            if (info.Font == null)
            {
                info.Font = e.InheritedRowStyle.Font;
            }
            var r = e.RowBounds;
            r.Height--;
            
            using (var bgb = new SolidBrush(info.BackColor))
            {
                // Строка под строкой группы.
                e.Graphics.DrawLine(Pens.SteelBlue, r.Left, r.Bottom, r.Right, r.Bottom);

                // Значение группы.
                {
                    int l = HeaderOffset + 1;
                    r.X = l - grid.HorizontalScrollingOffset;

                    // Очистить фон.
                    e.Graphics.FillRectangle(bgb, r);

                    using (var fb = new SolidBrush(info.ForeColor))
                    {
                        var sf = new StringFormat { LineAlignment = StringAlignment.Center };
                        if (info.Header != null)
                        {
                            var size = e.Graphics.MeasureString(info.Header, info.Font);
                            e.Graphics.DrawString(info.Header, info.Font, fb, r, sf);
                            r.X += (int)size.Width + 5;
                        }

                        if (info.DisplayValue != null)
                        {
                            using (var f = new Font(info.Font.FontFamily, info.Font.Size + 2, FontStyle.Bold))
                            {
                                var size = e.Graphics.MeasureString(info.DisplayValue, f);
                                e.Graphics.DrawString(info.DisplayValue, f, fb, r, sf);
                                r.X += (int)size.Width + 10;
                            }
                        }
                        if (info.Summary != null)
                        {
                            e.Graphics.DrawString(info.Summary, info.Font, fb, r, sf);
                        }
                    }
                    e.Graphics.FillRectangle(bgb, 0, r.Top, l, r.Height);
                }
            }

            // Свернуть/развернуть символ.
            {
                var cer = GetCollapseBoxBounds(e.RowBounds.Y);

                if (capturedcollapsebox.Y == e.RowIndex)
                {
                    e.Graphics.FillEllipse(Brushes.Yellow, cer);
                }
                e.Graphics.DrawEllipse(linepen, cer);
                bool collapsed = grouprow.Collapsed;
                int cx;

                if (DrawExpandCollapseLines && !collapsed)
                {
                    cx = HeaderOffset - lineoffset;
                    e.Graphics.DrawLine(linepen, cx, cer.Bottom, cx, r.Bottom);
                }
                cer.Inflate(-2, -2);
                var cy = cer.Y + cer.Height / 2;
                e.Graphics.DrawLine(linepen, cer.X, cy, cer.Right, cy);
                if (collapsed)
                {
                    cx = cer.X + cer.Width / 2;
                    e.Graphics.DrawLine(linepen, cx, cer.Top, cx, cer.Bottom);
                }
            }
        }

        const int CollapseBox_Y_Offset = 5;

        private Rectangle GetCollapseBoxBounds(int Y_Offset)
        {
            return new Rectangle(HeaderOffset - collapseboxwidth, Y_Offset + CollapseBox_Y_Offset, collapseboxwidth, collapseboxwidth);
        }

        public bool CurrentRowIsGroupRow
        {
            get
            {
                if (grid == null)
                {
                    return false;
                }
                return IsGroupRow(grid.CurrentCellAddress.Y);
            }
        }

        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public GroupRow CurrentGroup
        {
            get { return source.CurrentGroup; }
            set { source.CurrentGroup = value; }
        }
    }

    public class GroupDisplayEventArgs : CancelEventArgs
    {
        // Содержит подробные сведения о отображаемой информации о группировке.
        public readonly GroupRow Group;
        public readonly GroupingInfo GroupingInfo;

        public GroupDisplayEventArgs(GroupRow Row, GroupingInfo Info)
        {
            this.Group = Row;
            this.GroupingInfo = Info;
        }
        
        // Возвращает значение группировки для рисуемой строки.
        public object Value { get { return Group.Value; } }
        
        // Возвращает или задает отображаемое значение (после заголовка).
        public string DisplayValue { get; set; }
        
        // Заголовок обычно содержит имя свойства / группы, его можно изменить здесь.
        public string Header { get; set; }

        // Итоговое значение - это меньшее значение, отображаемое между () после displayValue.
        // С настройками по умолчанию это содержит количество строк.
        public string Summary { get; set; }
        public Color BackColor { get; set; }
        public Color ForeColor { get; set; }
        public Font Font { get; set; }
        
        // Указывает, выбрана ли в данный момент отображаемая строка.
        public bool Selected { get; internal set; }

        public override string ToString()
        {
            if (Summary == null)
            {
                return DisplayValue;
            }
            return string.Format("{0}   {1}", DisplayValue, Summary);            
        }

        // То же, что и Group. Добавлено для обеспечения обратной совместимости.
        public GroupRow Row
        {
            get { return Group; }
        }
    }

    public interface IDataGridViewGrouperOwner
    {
        DataGridViewGrouper Grouper { get; }
    }

    #region файл DataGridViewGrouperContextMenuStrip.cs

    public partial class DataGridViewGrouperContextMenuStrip : ContextMenuStrip
    {
        public readonly ToolStripMenuItem
            CollapseAllItem,
            ExpandAllItem,
            RemoveGroupingItem,
            GroupOnMenuItem,
            OverViewMenuItem,
            SortMenuItem,
            OptionsMenuItem,
            ForceAsText,
            FirstLetter,
            FirstWord,
            LastWord;

        public DataGridViewGrouperContextMenuStrip(DataGridViewGrouper Grouper) : this()
        {
            this.Grouper = Grouper;
        }

        partial void GetText(string keyword, ref string Value);

        public DataGridViewGrouperContextMenuStrip()
        {
            CollapseAllItem = Add("CollapseAll", "Свернуть все", collapse);
            ExpandAllItem = Add("ExpandAll", "Развернуть все", expand);

            GroupOnMenuItem = Add("Стиль группировки", null);
            GroupOnMenuItem.DropDown.ItemClicked += new ToolStripItemClickedEventHandler(GroupOnDropDown_ItemClicked);
            ForceAsText = AddGroupOnItem("Как текст", () => new StringGroupWrapper(grouper.GroupOn));
            FirstLetter = AddGroupOnItem("Первый символ", () => new StartLetterGrouper(grouper.GroupOn));
            FirstWord = AddGroupOnItem("Первое слово", () => new FirstWordGrouper(grouper.GroupOn));
            LastWord = AddGroupOnItem("Последнее слово", () => new LastWordGrouper(grouper.GroupOn));

            SortMenuItem = Add("Сортировка групп", null);
            foreach (SortOrder s in Enum.GetValues(typeof(SortOrder)))
            {
                if (s.ToString() == "None")
                {
                    SortMenuItem.DropDownItems.Add("Отсутствие");
                }
                else if (s.ToString() == "Ascending")
                {
                    SortMenuItem.DropDownItems.Add("По возрастанию");
                }
                else if (s.ToString() == "Descending")
                {
                    SortMenuItem.DropDownItems.Add("По убыванию");
                }
            }
            SortMenuItem.DropDown.ItemClicked += new ToolStripItemClickedEventHandler(SortDropDown_ItemClicked);

            OptionsMenuItem = Add("OtherOptions", "Другие настройки", null);
            AddOption("Свернуто при старте", GroupingOption.StartCollapsed);
            AddOption("Всегда группировать как текстовое значение", GroupingOption.AlwaysGroupOnText);
            OptionsMenuItem.DropDownItems.Add(new ToolStripSeparator());
            AddOption("Показать количество строк", GroupingOption.ShowCount);
            AddOption("Показать имена групповых полей", GroupingOption.ShowGroupName);
            AddOption("Выделять строки, при двойном щелчке по заголовку", GroupingOption.SelectRowsOnDoubleClick);

            Items.Add(new ToolStripSeparator());
            OverViewMenuItem = Add("JumpGroup", "Перейти к ...", jumptogroup);
            Items.Add(new ToolStripSeparator());
            RemoveGroupingItem = Add("RemoveGroup", "Удалить группировку", RemoveGrouping);
        }

        void SortDropDown_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var item = e.ClickedItem as SortItem;
            if (item == null)
            {
                return;
            }
            grouper.Options.GroupSortOrder = item.SortOrder;
        }

        void GroupOnDropDown_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var item = e.ClickedItem as GroupOnItem;
            if (item == null)
            {
                return;
            }
            var cur = grouper.GroupOn;
            if (item.EqualsInfo(cur))
            {
                if (cur is GroupWrapper)
                {
                    grouper.GroupOn = ((GroupWrapper)cur).Grouper;
                }
                item.Checked = false;
            }
            else
            {
                grouper.GroupOn = item.CreateInfo();
                item.Checked = true;
            }
        }

        void jumptogroup(object sender, EventArgs e)
        {

            var f = new FormJumpTo(Grouper);
            //f.MakeDialogForm(MessageBoxButtons.OK);
            f.Show(this);
        }

        class FormJumpTo : Form
        {
            public readonly DataGridViewGrouper Grouper;
            DataGridView GrouperGrid;
            DataGridView dg = new DataGridView();

            public FormJumpTo(DataGridViewGrouper Grouper)
            {
                this.Grouper = Grouper;
                this.GrouperGrid = Grouper.DataGridView;

                dg.AutoGenerateColumns = false;
                dg.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Value",
                    HeaderText = "Group",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    ReadOnly = true
                });
                dg.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Count",
                    Width = 60,
                    ReadOnly = true
                });
                dg.Columns.Add(new DataGridViewCheckBoxColumn()
                {
                    DataPropertyName = "Collapsed",
                    HeaderText = "Свернуть",
                    Width = 60
                });

                dg.AllowUserToAddRows = false;
                dg.AllowUserToDeleteRows = false;

                ClientSize = new Size(400, 400);

                dg.Dock = DockStyle.Fill;

                Controls.Add(dg);
                Controls.Add(new DataGridSearchBox() { DataGridView = dg, Dock = DockStyle.Top, ShowOptionsButton = true });
                dg.CreateControl();
            }

            void setdata()
            {
                var groups = Grouper.GroupingSource.Groups;
                var arr = groups == null ? null : groups.ToArray();
                settingcur = true;
                try
                {
                    dg.DataSource = arr;
                }
                finally
                {
                    settingcur = false;
                }
                dg.Enabled = arr != null;
                syncwithdg();
            }

            protected override void OnClosing(CancelEventArgs e)
            {
                Grouper.GroupingChanged -= new EventHandler(Grouper_GroupingChanged);
                GrouperGrid.CurrentCellChanged -= new EventHandler(GrouperGrid_CurrentCellChanged);
                base.OnClosing(e);
            }

            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);

                dg.CurrentCellChanged += new EventHandler(dg_CurrentCellChanged);
                dg.CellDoubleClick += new DataGridViewCellEventHandler(dg_CellDoubleClick);
                GrouperGrid.CurrentCellChanged += new EventHandler(GrouperGrid_CurrentCellChanged);
                Grouper.GroupingChanged += new EventHandler(Grouper_GroupingChanged);
                setdata();
            }

            void Grouper_GroupingChanged(object sender, EventArgs e)
            {
                setdata();
            }

            void GrouperGrid_CurrentCellChanged(object sender, EventArgs e)
            {
                syncwithdg();
            }

            void dg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                SelectCurrent();
                DialogResult = DialogResult.OK;
                Close();
            }

            void syncwithdg()
            {
                if (settingcur)
                {
                    return;
                }
                var gr = Grouper.GroupingSource.CurrentGroup;
                if (gr == null)
                {
                    return;
                }
                int pos = Grouper.GroupingSource.Groups.IndexOf(gr);
                if (dg.CurrentCellAddress.Y == pos)
                {
                    return;
                }
                settingcur = true;
                try
                {
                    dg.CurrentCell = dg[0, pos];
                }
                catch { }
                finally
                {
                    settingcur = false;
                }
            }

            void dg_CurrentCellChanged(object sender, EventArgs e)
            {
                SelectCurrent();
            }

            bool settingcur;

            public void SelectCurrent()
            {
                if (settingcur)
                {
                    return;
                }
                settingcur = true;
                try
                {
                    Grouper.GroupingSource.CurrentGroup = Current;
                }
                finally
                {
                    settingcur = false;
                }
            }

            public GroupRow Current
            {
                get { return (GroupRow)dg.CurrentRow.DataBoundItem; }
            }
        }

        private DataGridViewGrouper grouper;

        public DataGridViewGrouper Grouper
        {
            get { return grouper; }
            set { grouper = value; }
        }

        protected override void OnOpening(CancelEventArgs e)
        {
            Initialize();
            base.OnOpening(e);
        }

        public void Initialize()
        {
            bool hasgrouper = grouper != null;
            bool isgrouped = hasgrouper && grouper.IsGrouped;
            CollapseAllItem.Enabled = isgrouped;
            ExpandAllItem.Enabled = isgrouped;
            RemoveGroupingItem.Enabled = isgrouped;
            GroupOnMenuItem.Enabled = isgrouped;
            OverViewMenuItem.Enabled = isgrouped;
            SortMenuItem.Enabled = hasgrouper;
            OptionsMenuItem.Enabled = hasgrouper;

            if (hasgrouper)
            {
                var sort = grouper.Options.GroupSortOrder;
                foreach (var si in GetSortItems())
                {
                    si.Checked = si.SortOrder == sort;
                }

                foreach (var m in OptionsMenuItem.DropDownItems)
                {
                    if (m is booloption)
                    {
                        ((booloption)m).Init();
                    }
                }
            }

            if (isgrouped)
            {
                var cur = grouper.GroupOn;
                foreach (var item in this.GetGroupOnItems())
                {
                    item.Checked = item.EqualsInfo(cur);
                }
            }
        }

        ToolStripMenuItem Add(string txt)
        {
            return Add(txt, null);
        }

        ToolStripMenuItem Add(string txt, EventHandler onClick)
        {
            return Add(null, txt, onClick);
        }

        ToolStripMenuItem Add(string kw, string txt, EventHandler onClick)
        {
            if (kw != null)
            {
                GetText(kw, ref txt);
            }
            return Add(txt, onClick, Items);
        }

        ToolStripMenuItem Add(string txt, EventHandler onClick, ToolStripItemCollection Items)
        {
            ToolStripMenuItem m = new ToolStripMenuItem(txt, null, onClick);
            Items.Add(m);
            return m;
        }

        booloption AddOption(string txt, GroupingOption o)
        {
            var res = new booloption(o);
            res.Text = txt;
            res.Strip = this;
            OptionsMenuItem.DropDownItems.Add(res);
            return res;
        }

        void expand(object sender, EventArgs e)
        {
            Grouper.GroupingSource.CollapseExpandAll(false);
        }

        void collapse(object sender, EventArgs e)
        {
            Grouper.GroupingSource.CollapseExpandAll(true);
        }

        void RemoveGrouping(object sender, EventArgs e)
        {
            Grouper.GroupOn = null;
        }

        public ToolStripMenuItem AddGroupOnItem<T>(string Text, Func<T> Creator) where T : GroupingInfo
        {
            var mi = new GroupOnItem<T>();
            mi.Text = Text;
            mi.CreateInfoDelegate = Creator;
            GroupOnMenuItem.DropDownItems.Add(mi);
            return mi;
        }

        public IEnumerable<GroupOnItem> GetGroupOnItems()
        {
            foreach (var item in GroupOnMenuItem.DropDownItems)
            {
                if (item is GroupOnItem)
                {
                    yield return (GroupOnItem)item;
                }
            }
        }

        public abstract class GroupOnItem : ToolStripMenuItem
        {
            public virtual GroupingInfo CreateInfo()
            {
                return (GroupingInfo)Activator.CreateInstance(GroupInfoType);
            }

            public abstract Type GroupInfoType { get; }

            public virtual bool EqualsInfo(GroupingInfo g)
            {
                return GroupInfoType.IsAssignableFrom(g.GetType());
            }
        }

        public class GroupOnItem<T> : GroupOnItem where T : GroupingInfo
        {
            public override Type GroupInfoType
            {
                get { return typeof(T); }
            }

            public Func<T> CreateInfoDelegate;

            public override GroupingInfo CreateInfo()
            {
                if (CreateInfoDelegate == null)
                {
                    return base.CreateInfo();
                }
                return CreateInfoDelegate();
            }

            public override bool EqualsInfo(GroupingInfo g)
            {
                return g is T;
            }
        }

        public IEnumerable<SortItem> GetSortItems()
        {
            foreach (var item in SortMenuItem.DropDownItems)
            {
                if (item is SortItem)
                {
                    yield return (SortItem)item;
                }
            }
        }

        public class SortItem : ToolStripMenuItem
        {
            public readonly SortOrder SortOrder;

            public SortItem(SortOrder SortOrder)
            {
                this.SortOrder = SortOrder;
                this.Text = SortOrder.ToString();
            }
        }

        //////SortItem AddSortItem(SortOrder s)
        //////{
        //////    var si = new SortItem(s);
        //////    SortMenuItem.DropDownItems.Add(si);
        //////    return si;
        //////}

        class booloption : ToolStripMenuItem
        {
            public readonly GroupingOption Option;

            public booloption(GroupingOption Option)
            {
                this.Option = Option;
            }

            internal DataGridViewGrouperContextMenuStrip Strip;

            GroupingOptionValue<bool> GetOption()
            {
                return (GroupingOptionValue<bool>)Strip.grouper.Options[Option];
            }

            protected override void OnClick(EventArgs e)
            {
                base.OnClick(e);
                var o = GetOption();
                Checked = !Checked;
                o.Value = Checked;
            }

            public void Init()
            {
                Checked = GetOption().Value;
            }
        }
    }

    #endregion

    #region файл GroupingInfo.cs

    // Информация о том, как GroupingSource должен группировать свою информацию.
    public abstract class GroupingInfo
    {
        public abstract object GetGroupValue(object Row);

        public virtual bool IsProperty(PropertyDescriptor p)
        {
            return p != null && IsProperty(p.Name);
        }

        public virtual bool IsProperty(string Name)
        {
            return Name == ToString();
        }

        public static implicit operator GroupingInfo(PropertyDescriptor p)
        {
            return new PropertyGrouper(p);
        }

        public virtual Type GroupValueType
        {
            get { return typeof(object); }
        }

        public virtual void SetDisplayValues(GroupDisplayEventArgs e)
        {
            var o = e.Value;

            if (o.ToString() == "False")
            {
                e.DisplayValue = o == null ? "<Null>" : "Ложь";
            }
            else if(o.ToString() == "True")
            {
                e.DisplayValue = o == null ? "<Null>" : "Истина";
            }
            else
            {
                e.DisplayValue = o == null ? "<Null>" : o.ToString();
            }
        }
    }

    // Группы по значению свойства.
    public class PropertyGrouper : GroupingInfo
    {
        public readonly PropertyDescriptor Property;

        public PropertyGrouper(PropertyDescriptor Property)
        {
            if (Property == null)
            {
                throw new ArgumentNullException();
            }
            this.Property = Property;
        }

        public override bool IsProperty(PropertyDescriptor p)
        {
            return p == Property || (p != null && p.Name == Property.Name);
        }

        public override object GetGroupValue(object Row)
        {
            return Property.GetValue(Row);
        }

        public override string ToString()
        {
            return Property.Name;
        }

        public override Type GroupValueType
        {
            get { return Property.PropertyType; }
        }
    }

    public class DelegateGrouper<T> : GroupingInfo
    {
        public readonly string Name;
        public readonly Func<T, object> GroupProvider;

        public DelegateGrouper(Func<T, object> GroupProvider, string Name)
        {
            if (GroupProvider == null)
            {
                throw new ArgumentNullException();
            }
            this.Name = Name;
            if (Name == null)
            {
                this.Name = GroupProvider.ToString();
            }
            this.GroupProvider = GroupProvider;
        }

        public override string ToString()
        {
            return Name;
        }

        public override object GetGroupValue(object Row)
        {
            return GroupProvider((T)Row);
        }
    }

    public abstract class GroupWrapper : GroupingInfo
    {
        public readonly GroupingInfo Grouper;

        public GroupWrapper(GroupingInfo Grouper) : this(Grouper, true)
        {
        }

        public GroupWrapper(GroupingInfo Grouper, bool RemovePreviousWrappers)
        {
            if (Grouper == null)
            {
                throw new ArgumentNullException();
            }
            if (RemovePreviousWrappers)
            {
                while (Grouper is GroupWrapper)
                {
                    Grouper = ((GroupWrapper)Grouper).Grouper;
                }
            }
            this.Grouper = Grouper;
        }

        public override string ToString()
        {
            return Grouper.ToString();
        }

        public override bool IsProperty(PropertyDescriptor p)
        {
            return Grouper.IsProperty(p);
        }

        public override object GetGroupValue(object Row)
        {
            return GetValue(Grouper.GetGroupValue(Row));
        }

        public override Type GroupValueType
        {
            get { return Grouper.GroupValueType; }
        }

        protected abstract object GetValue(object GroupValue);
    }

    // Принудительная группировка значения по его строковому значению независимо от того, какое значение сгруппировано.
    public class StringGroupWrapper : GroupWrapper
    {
        public StringGroupWrapper(GroupingInfo Grouper) : base(Grouper)
        {
        }

        protected override object GetValue(object GroupValue)
        {
            if (GroupValue == null)
            {
                return (string)null;
            }
            return GetValue(GroupValue.ToString());
        }

        public override Type GroupValueType
        {
            get { return typeof(string); }
        }

        protected virtual string GetValue(string s)
        {
            return s;
        }
    }

    public class StartLetterGrouper : StringGroupWrapper
    {
        public readonly int Letters;

        public StartLetterGrouper(GroupingInfo Grouper) : this(Grouper, 1)
        {
        }

        public StartLetterGrouper(GroupingInfo Grouper, int Letters) : base(Grouper)
        {
            this.Letters = Letters;
        }

        protected override string GetValue(string s)
        {
            if (s.Length < Letters)
            {
                return s;
            }
            return s.Substring(0, Letters);
        }
    }

    public class FirstWordGrouper : StringGroupWrapper
    {
        public FirstWordGrouper(GroupingInfo Grouper) : base(Grouper)
        {
        }

        internal static char[] EndOfWordChars = new char[] { ' ', '\r', '\n', '\t' };

        protected override string GetValue(string s)
        {
            int i = s.IndexOfAny(EndOfWordChars);
            if (i == -1)
            {
                return s;
            }
            return s.Substring(0, i);
        }
    }

    public class LastWordGrouper : StringGroupWrapper
    {
        public LastWordGrouper(GroupingInfo Grouper) : base(Grouper)
        {
        }

        protected override string GetValue(string s)
        {
            int i = s.LastIndexOfAny(FirstWordGrouper.EndOfWordChars);
            if (i == -1)
            {
                return s;
            }
            return s.Substring(++i);
        }
    }

    public class DateTimeGrouper : GroupWrapper
    {
        public readonly DateTimeGrouping Mode;

        public DateTimeGrouper(GroupingInfo Grouper) : this(Grouper, DateTimeGrouping.Date)
        {
        }

        public DateTimeGrouper(GroupingInfo Grouper, DateTimeGrouping Mode) : base(Grouper)
        {
            this.Mode = Mode;
        }

        bool set(DateTimeGrouping val)
        {
            return (Mode & val) > 0;
        }

        public override Type GroupValueType
        {
            get
            {
                if (Mode == DateTimeGrouping.Date)
                {
                    return typeof(DateTime);
                }
                return typeof(int);
            }
        }

        protected override object GetValue(object GroupValue)
        {
            DateTime dt = (DateTime)GroupValue;
            if (Mode == DateTimeGrouping.Date)
            {
                return dt.Date;
            }
            if (Mode == DateTimeGrouping.WeekDay)
            {
                return (int)dt.DayOfWeek;
            }
            int i = 0;
            if (set(DateTimeGrouping.Year))
            {
                i += dt.Year * 10000;
            }
            if (set(DateTimeGrouping.Month))
            {
                i += dt.Month * 100;
            }
            if (set(DateTimeGrouping.Day))
            {
                i += dt.Day;
            }
            return i;
        }

        public override void SetDisplayValues(GroupDisplayEventArgs e)
        {
            base.SetDisplayValues(e);
            if (Mode == DateTimeGrouping.Date)
            {
                e.DisplayValue = ((DateTime)e.Value).ToShortDateString();
            }
            else if (e.Value is int)
            {
                int i = (int)e.Value;
                string value = null;
                if (set(DateTimeGrouping.Year))
                {
                    value = "Year: " + i / 10000;
                }
                if (set(DateTimeGrouping.Month))
                {
                    if (value != null)
                    {
                        value += ", ";
                    }
                    int m = (i / 100) % 100;
                    value += System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(m);
                }
                if (set(DateTimeGrouping.Day) || set(DateTimeGrouping.WeekDay))
                {
                    if (value != null)
                    {
                        value += ", ";
                    }
                    int d = i % 10000;
                    value += set(DateTimeGrouping.WeekDay)
                        ? System.Globalization.DateTimeFormatInfo.CurrentInfo.GetDayName((DayOfWeek)d)
                        : "Day: " + d;
                }
                e.DisplayValue = value;
            }
        }
    }

    public enum DateTimeGrouping
    {
        Year = 1,
        Month = 2,
        YearAndMonth = 3,
        Day = 4,
        Date = 7,
        WeekDay = 32
    }

    #endregion

    #region файл GroupingOptions.cs

    [Serializable]
    public partial class GroupingOptions : INotifyPropertyChanged, IEquatable<GroupingOptions>
    {
        public GroupingOptions()
        {
            add(GroupingOption.StartCollapsed, false);
            add(GroupingOption.GroupSortOrder, DefaultGroupSortOrder);
            add(GroupingOption.AlwaysGroupOnText, false);
            add(GroupingOption.ShowCount, true);
            add(GroupingOption.ShowGroupName, true);
            add(GroupingOption.SelectRowsOnDoubleClick, true);
        }

        List<GroupingOptionValue> list = new List<GroupingOptionValue>();

        void add<T>(GroupingOption o, T Default)
        {
            list.Add(new GroupingOptionValue<T>(Default, o)
            {
                Owner = this
            });
        }

        public GroupingOptionValue this[GroupingOption option]
        {
            get
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Option == option)
                    {
                        return list[i];
                    }
                }
                return null;
            }
        }

        T GetValue<T>(GroupingOption o)
        {
            return ((GroupingOptionValue<T>)this[o]).Value;
        }

        void SetValue<T>(GroupingOption o, T value)
        {
            ((GroupingOptionValue<T>)this[o]).Value = value;
        }

        bool ShouldSerialize(GroupingOption o)
        {
            return !this[o].IsDefault;
        }

        // Если значение true, новые группы всегда начинают сворачиваться.
        public bool StartCollapsed
        {
            get { return GetValue<bool>(GroupingOption.StartCollapsed); }
            set { SetValue(GroupingOption.StartCollapsed, value); }
        }

        bool ShouldSerializeStartCollapsed()
        {
            return ShouldSerialize(GroupingOption.StartCollapsed);
        }

        public const SortOrder DefaultGroupSortOrder = SortOrder.Ascending;

        [DefaultValue(DefaultGroupSortOrder)]
        public SortOrder GroupSortOrder
        {
            get { return GetValue<SortOrder>(GroupingOption.GroupSortOrder); }
            set { SetValue(GroupingOption.GroupSortOrder, value); }
        }

        bool ShouldSerializeGroupSortOrder()
        {
            return ShouldSerialize(GroupingOption.GroupSortOrder);
        }

        public bool AlwaysGroupOnText
        {
            get { return GetValue<bool>(GroupingOption.AlwaysGroupOnText); }
            set { SetValue(GroupingOption.AlwaysGroupOnText, value); }
        }

        bool ShouldSerializeAlwaysGroupOnText()
        {
            return ShouldSerialize(GroupingOption.AlwaysGroupOnText);
        }

        public bool ShowCount
        {
            get { return GetValue<bool>(GroupingOption.ShowCount); }
            set { SetValue(GroupingOption.ShowCount, value); }
        }

        bool ShouldSerializeShowCount()
        {
            return ShouldSerialize(GroupingOption.ShowCount);
        }

        public bool ShowGroupName
        {
            get { return GetValue<bool>(GroupingOption.ShowGroupName); }
            set { SetValue(GroupingOption.ShowGroupName, value); }
        }

        bool ShouldSerializeShowGroupName()
        {
            return ShouldSerialize(GroupingOption.ShowGroupName);
        }

        public bool SelectRowsOnDoubleClick
        {
            get { return GetValue<bool>(GroupingOption.SelectRowsOnDoubleClick); }
            set { SetValue(GroupingOption.SelectRowsOnDoubleClick, value); }
        }

        bool ShouldSerializeSelectRowsOnDoubleClick()
        {
            return ShouldSerialize(GroupingOption.SelectRowsOnDoubleClick);
        }

        public bool HasNonDefaultValues
        {
            get
            {
                foreach (var g in list)
                {
                    if (!g.IsDefault)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void CopyValues(GroupingOptions options)
        {
            foreach (var g in list)
            {
                g.CopyValue(options[g.Option]);
            }
        }

        public void SetDefaults()
        {
            foreach (var g in list)
            {
                g.Reset();
            }
        }

        internal void NotifyChanged(GroupingOption o)
        {
            if (OptionChanged != null)
            {
                OptionChanged(this, new GroupingOptionChangedEventArgs(o));
            }
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(o.ToString()));
            }
        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        [field: NonSerialized]
        public event EventHandler<GroupingOptionChangedEventArgs> OptionChanged;

        public bool Equals(GroupingOptions o)
        {
            if (o == null)
            {
                return false;
            }
            if (o.list.Count != list.Count)
            {
                return false;
            }
            foreach (var g in list)
            {
                if (!g.Equals(o[g.Option]))
                {
                    return false;
                }
            }
            return true;
        }
    }

    partial class GroupingOptions : ISerializable
    {
        GroupingOptions(SerializationInfo info, StreamingContext context) : this()
        {
            foreach (var kv in info)
            {
                try
                {
                    var o = EnumFunctions.Parse<GroupingOption>(kv.Name);
                    this[o].SetValue(kv.Value);
                }
                catch { }
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            foreach (var g in list)
            {
                if (!g.IsDefault)
                {
                    info.AddValue(g.Option.ToString(), g.GetValue());
                }
            }
        }
    }

    partial class GroupingOptions : ICustomSerializer
    {
        bool ICustomSerializer.Serialize(SimpleObjectSerializer s)
        {
            var vals = list.Where(g => !g.IsDefault).ToArray();
            s.Writer.Write((byte)vals.Length);
            if (vals.Length > 0)
            {
                foreach (var g in vals)
                {
                    s.Writer.Write(g.Option.ToString());
                    s.WriteSubValue(g.GetValue());
                }
            }
            return true;
        }

        bool ICustomSerializer.Deserialize(SimpleObjectDeserializer ds)
        {
            int cnt = ds.Reader.ReadByte();
            for (int i = 0; i < cnt; i++)
            {
                var name = ds.Reader.ReadString();
                var val = ds.GetSubValue();
                var o = EnumFunctions.Parse<GroupingOption>(name);
                this[o].SetValue(val);
            }
            return true;
        }

        bool ICustomSerializer.Initialize(SimpleObjectSerializer s)
        {
            return true;
        }
    }

    public enum GroupingOption
    {
        StartCollapsed,
        GroupSortOrder,
        AlwaysGroupOnText,
        ShowCount,
        ShowGroupName,
        SelectRowsOnDoubleClick
    }

    public class GroupingOptionChangedEventArgs : EventArgs
    {
        public readonly GroupingOption Option;

        public GroupingOptionChangedEventArgs(GroupingOption Option)
        {
            this.Option = Option;
        }
    }

    [Serializable]
    public abstract class GroupingOptionValue
    {
        internal GroupingOptions Owner;
        public readonly GroupingOption Option;

        protected GroupingOptionValue(GroupingOption o)
        {
            this.Option = o;
        }

        public abstract bool IsDefault
        {
            get;
        }

        public abstract object GetValue();
        public abstract object GetDefaultValue();
        public abstract void Reset();
        internal abstract void CopyValue(GroupingOptionValue o);
        public abstract Type ValueType { get; }
        public abstract void SetValue(object value);
        public abstract bool Equals(GroupingOptionValue v);
    }


    [Serializable]
    internal class GroupingOptionValue<T> : GroupingOptionValue
    {
        public GroupingOptionValue(T Default, GroupingOption o) : base(o)
        {
            this.DefaultValue = Default;
            this.value = DefaultValue;
        }

        [NonSerialized]
        public T DefaultValue;

        T value;

        public T Value
        {
            get { return value; }
            set
            {
                if (Equals(value, this.value))
                {
                    return;
                }
                this.value = value;
                Owner.NotifyChanged(Option);
            }
        }

        [NonSerialized]
        EqualityComparer<T> eq;
        bool Equals(T t1, T t2)
        {
            if (eq == null)
            {
                eq = EqualityComparer<T>.Default;
            }
            return eq.Equals(t1, t2);
        }

        public override bool Equals(GroupingOptionValue v)
        {
            if (v == null)
            {
                return false;
            }
            var o = v.GetValue();
            if (o is T)
            {
                return Equals(value, (T)o);
            }
            return false;
        }

        public override bool IsDefault
        {
            get { return Equals(value, DefaultValue); }
        }

        public override Type ValueType
        {
            get { return typeof(T); }
        }

        public override object GetValue()
        {
            return value;
        }

        public override void SetValue(object value)
        {
            Value = (T)value;
        }

        public override object GetDefaultValue()
        {
            return DefaultValue;
        }

        internal override void CopyValue(GroupingOptionValue o)
        {
            Value = ((GroupingOptionValue<T>)o).value;
        }

        public override void Reset()
        {
            Value = DefaultValue;
        }
    }

    public static class EnumFunctions
    {
        // Возвращает все значения указанного перечисления.
        public static IEnumerable<T> GetValues<T>() where T : IComparable, IFormattable, IConvertible
        {
            return GetValues<T>(x => x);
        }

        // Возвращает все значения указанного перечисления.
        public static IEnumerable<T> GetValues<T>(Func<T, T> pred) where T : IComparable, IFormattable, IConvertible
        {
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                yield return pred(item);
            }
        }

        // Возвращает все значения указанного перечисления, которые соответствуют указанному предикату.
        public static IEnumerable<T> GetValues<T>(Func<T, bool> predicate) where T : IComparable, IFormattable, IConvertible
        {
            foreach (var item in GetValues<T>())
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        // Проверяет, установлен ли для указанного значения перечисления бит флага.
        [Obsolete("Framework 4.0 contains a native HasFlag function :D")]
        public static bool HasFlag<T>(this T value, T flag) where T : IComparable, IFormattable, IConvertible
        {
            int fl = flag.ToInt32(null);
            return (value.ToInt32(null) & fl) == fl;
        }

        // Вызывает Enum.Parse и создает строго типизированный результат.
        public static T Parse<T>(string Value) where T : IComparable, IFormattable, IConvertible
        {
            if (string.IsNullOrEmpty(Value))
            {
                return default(T);
            }
            return (T)Enum.Parse(typeof(T), Value, true);
        }

        // Разбивает перечисление флагов на его базовые значения.
        public static IEnumerable<T> Select<T>(this T e, Func<T, T> pred) where T : IComparable, IFormattable, IConvertible
        {
            foreach (T item in Split(e))
            {
                yield return pred(item);
            }
        }

        // Разбивает перечисление флагов на его базовые значения.
        public static IEnumerable<T> Split<T>(this T enumeration) where T : IComparable, IFormattable, IConvertible
        {
            int val = Convert.ToInt32(enumeration);
            foreach (var item in GetValues<T>())
            {
                int i = item.ToInt32(null);
                if (i > 0 & (i & val) == i)
                {
                    yield return item;
                }
            }
        }

        // Разбивает перечисление флагов на его базовые значения и фильтрует значения, уже установленные с помощью маски.
        public static IEnumerable<T> Split<T>(this T enumeration, bool CompactMaskedValues) where T : IComparable, IFormattable, IConvertible
        {
            var res = Split(enumeration);
            if (!CompactMaskedValues)
            {
                return res;
            }

            var list = res.OrderByDescending(r => r.ToInt32(null)).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                var val = list[i].ToInt32(null);
                for (int j = i + 1; j < list.Count; j++)
                {
                    if ((val & list[j].ToInt32(null)) == list[j].ToInt32(null))
                    {
                        list.RemoveAt(j--);
                    }
                }
            }
            return list;
        }

        public static IEnumerable<T> GetValues<T>(this T e, Func<T, bool> pred) where T : IComparable, IFormattable, IConvertible
        {
            foreach (T item in Split(e))
            {
                if (pred(item))
                {
                    yield return item;
                }
            }
        }
    }

    #endregion

    #region файл GroupingSource.cs

    [DefaultEvent("GroupingChanged")]
    public partial class GroupingSource : BindingSource, ICancelAddNew
    {
        public GroupingSource()
        {
        }

        public GroupingSource(object DataSource) : this()
        {
            this.DataSource = DataSource;
        }

        public GroupingSource(object DataSource, string GroupOn) : this(DataSource)
        {
        }

        GroupingInfo groupon;

        [DefaultValue(null)]
        public GroupingInfo GroupOn
        {
            get { return groupon; }
            set
            {
                if (groupon == value)
                {
                    return;
                }

                if (value == null)
                {
                    RemoveGrouping();
                }
                else
                {
                    if (value.Equals(groupon))
                    {
                        return;
                    }
                    setgroupon(value, Options.AlwaysGroupOnText);
                }
            }
        }

        void setgroupon(GroupingInfo value, bool forcetext)
        {
            info = null;
            if (forcetext && value.GroupValueType != typeof(string))
            {
                value = new StringGroupWrapper(value);
            }
            groupon = value;
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            OnGroupingChanged();
        }

        public bool IsGrouped
        {
            get { return groupon != null; }
        }

        internal DataGridViewGrouper Grouper;

        public void RemoveGrouping()
        {
            if (groupon == null)
            {
                return;
            }
            groupon = null;
            ResetGroups();
            OnGroupingChanged();
        }

        public bool SetGroupOn(string Property)
        {
            return SetGroupOn(GetProperty(Property));
        }

        public PropertyDescriptor GetProperty(string Name)
        {
            var pd = this.GetItemProperties(null)[Name];
            if (pd == null)
            {
                throw new Exception(Name + " is not a valid property");
            }
            return pd;
        }

        public bool SetGroupOn(PropertyDescriptor p)
        {
            if (p == null)
            {
                throw new ArgumentNullException();
            }
            if (groupon == null || !groupon.IsProperty(p))
            {
                GroupOn = new PropertyGrouper(p);
                return true;
            }
            return false;
        }

        public void SetCustomGroup<T>(Func<T, object> GroupValueProvider, string Description = null)
        {
            if (GroupValueProvider == null)
            {
                throw new ArgumentNullException();
            }
            GroupOn = new DelegateGrouper<T>(GroupValueProvider, Description);
        }

        public void SetGroupOnStartLetters(GroupingInfo g, int Letters)
        {
            GroupOn = new StartLetterGrouper(g, Letters);
        }

        public void SetGroupOnStartLetters(string Property, int Letters)
        {
            SetGroupOnStartLetters(GetProperty(Property), Letters);
        }

        public bool IsGroupRow(int Index)
        {
            if (info == null)
            {
                return false;
            }
            if (Index < 0 || Index >= Count)
            {
                return false;
            }
            return info.Rows[Index] is GroupRow;
        }

        public void CollapseExpandAll(bool collapse)
        {
            if (Groups == null)
            {
                return;
            }
            var cur = CurrentGroup;
            Groups.CollapseExpandAll(collapse);
            if (cur != null)
            {
                try
                {
                    CurrentGroup = cur;
                }
                catch { }
            }
        }

        [DefaultValue(GroupingOptions.DefaultGroupSortOrder)]
        public SortOrder GroupSortOrder
        {
            get
            {
                if (options == null)
                {
                    return GroupingOptions.DefaultGroupSortOrder;
                }
                return options.GroupSortOrder;
            }
            set { Options.GroupSortOrder = value; }
        }

        GroupingOptions options;
        [DefaultValue(null)]
        public GroupingOptions Options
        {
            get
            {
                if (options == null && !DesignMode)
                {
                    Options = new GroupingOptions();
                }
                return options;
            }
            set
            {
                if (options == value)
                {
                    return;
                }
                var cursort = GroupSortOrder;
                if (options != null)
                {
                    options.OptionChanged -= new EventHandler<GroupingOptionChangedEventArgs>(options_OptionChanged);
                    cursort = options.GroupSortOrder;
                }
                options = value;
                if (options != null)
                {
                    options.OptionChanged += new EventHandler<GroupingOptionChangedEventArgs>(options_OptionChanged);
                }
                if (GroupSortOrder != cursort)
                {
                    sort();
                }
            }
        }

        void options_OptionChanged(object sender, GroupingOptionChangedEventArgs e)
        {

            if (!shouldreset)
            {
                return;
            }
            if (e.Option == GroupingOption.GroupSortOrder)
            {
                sort();
            }
            else if (e.Option == GroupingOption.AlwaysGroupOnText)
            {
                setgroupontext();
            }
            else if (e.Option == GroupingOption.StartCollapsed)
            {
                CollapseExpandAll(options.StartCollapsed);
            }
            else if (e.Option == GroupingOption.ShowCount || e.Option == GroupingOption.ShowGroupName)
            {
                if (Grid != null)
                {
                    InvalidateGridGroupRows();
                }
            }
        }

        void InvalidateGridGroupRows()
        {
            var grid = Grid;
            foreach (var gr in info.Groups)
            {
                grid.InvalidateRow(gr.Index);
            }
        }

        void setgroupontext()
        {
            var istext = groupon.GroupValueType == typeof(string);
            if (istext == options.AlwaysGroupOnText)
            {
                return;
            }
            if (istext)
            {
                if (groupon is StringGroupWrapper)
                {
                    GroupOn = ((StringGroupWrapper)groupon).Grouper;
                }
            }
            else
            {
                setgroupon(groupon, true);
            }
        }

        void sort()
        {
            if (info == null)
            {
                return;
            }
            if (GroupSortOrder == SortOrder.None)
            {
                reset(false);
            }
            else
            {
                info.Sort();
            }
        }

        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public GroupRow CurrentGroup
        {
            get { return GetGroup(Position); }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                Position = value.Index;
                if (!value.Collapsed)
                {
                    Position++;
                }
            }
        }

        public GroupRow GetGroup(int RowIndex)
        {
            if (RowIndex == -1 || Groups == null)
            {
                return null;
            }
            return Groups.GetByRow(RowIndex);
        }

        public GroupList Groups
        {
            get { return Info.Groups; }
        }

        internal void CheckNewRow()
        {
            if (shouldreset)
            {
                info.Groups.CheckNewRow(true);
            }
        }

        class NullValue
        {
            public override string ToString()
            {
                return "<Null>";
            }

            public static readonly NullValue Instance = new NullValue();
        }

        class GroupInfo
        {
            public readonly GroupingSource Owner;

            public GroupInfo(GroupingSource Owner)
            {
                this.Owner = Owner;
                set();
            }

            public IList Rows;
            //public List<GroupRow> Groups = new List<GroupRow>();
            public GroupList Groups;

            void set()
            {
                Groups = null;
                if (Owner.groupon == null)
                {
                    Rows = Owner.List;
                    return;
                }
                Groups = new GroupList(Owner);
                Rows = Groups.Fill();
            }

            public void ReBuild()
            {
                if (Groups == null)
                {
                    set();
                }
                else
                {
                    Groups.Fill();
                }
            }

            public void Sort()
            {
                if (Groups == null)
                {
                    return;
                }
                Groups.Sort(Owner.GroupSortOrder);
            }
        }

        GroupInfo info;

        GroupInfo Info
        {
            get
            {
                if (info == null)
                {
                    info = new GroupInfo(this);
                    if (NeedSync)
                    {
                        SyncCurrencyManagers();
                    }
                }
                return info;
            }
        }

        void OnGroupingChanged()
        {
            if (GroupingChanged != null)
            {
                GroupingChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler GroupingChanged;

        internal DataGridView Grid
        {
            get
            {
                if (Grouper == null)
                {
                    return null;
                }
                return Grouper.DataGridView;
            }
        }

        public void ResetGroups()
        {
            reset(false);
        }

        bool resetting;

        void reset(bool fromlistchange)
        {
            if (info == null || resetting)
            {
                return;
            }
            int pos = Position;
            var cur = Current;
            var grid = Grid;
            int? firstrow = grid == null ? (int?)null : grid.FirstDisplayedScrollingRowIndex;
            resetting = true;
            try
            {
                if (fromlistchange)
                {
                    info.ReBuild();
                }
                else
                {
                    info = null;
                }
                base.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));

                if (pos != -1)
                {
                    int i = cur is GroupRow ? pos : IndexOf(cur);
                    if (i == -1)
                    {
                        i = pos;
                    }

                    if (Position == i)
                    {
                        OnPositionChanged(EventArgs.Empty);
                    }
                    else
                    {
                        this.Position = i;
                    }

                    if (firstrow.HasValue)
                    {
                        try
                        {
                            if (grid.Rows.Count > firstrow.Value && firstrow.Value > -1)
                            {
                                grid.FirstDisplayedScrollingRowIndex = firstrow.Value;
                            }
                            //OnPositionChanged(EventArgs.Empty);
                        }
                        catch { }
                    }
                }
            }
            finally
            {
                resetting = false;

                if (NeedSync)
                {
                    SyncCurrencyManagers();
                }
            }
        }

        internal void FireBaseReset(bool PreserveScrollPosition)
        {
            FireBaseChanged(new ListChangedEventArgs(ListChangedType.Reset, -1), PreserveScrollPosition);
        }

        internal void FireBaseChanged(ListChangedType type, int index, bool PreserveScrollPosition)
        {
            FireBaseChanged(new ListChangedEventArgs(type, index), PreserveScrollPosition);
        }
        internal void FireBaseChanged(ListChangedEventArgs e, bool PreserveScrollPosition)
        {
            int soffset = -1;
            PreserveScrollPosition &= Grid != null;
            if (PreserveScrollPosition)
            {
                soffset = Grid.FirstDisplayedScrollingRowIndex;
            }
            base.OnListChanged(e);
            if (soffset > 0)
            {
                try
                {
                    Grid.FirstDisplayedScrollingRowIndex = soffset;
                }
                catch { }
            }
        }

        // Это событие срабатывает, когда необходимо закрасить строку группы и запрашиваются отображаемые значения.
        public event EventHandler<GroupDisplayEventArgs> DisplayGroup;

        internal void FireDisplayGroup(GroupDisplayEventArgs e)
        {
            if (DisplayGroup != null)
            {
                DisplayGroup(this, e);
            }
        }

        CurrencyManager cm;

        void UnwireCurMan()
        {
            if (cm == null)
            {
                return;
            }
            cm.CurrentChanged -= new EventHandler(bsource_CurrentChanged);
        }

        protected override void Dispose(bool disposing)
        {
            UnwireCurMan();
            groupon = null;
            base.Dispose(disposing);
        }

        protected override void OnDataSourceChanged(EventArgs e)
        {
            UnwireCurMan();
            ResetGroups();
            var ds = DataSource;
            if (ds is ICurrencyManagerProvider)
            {
                cm = ((ICurrencyManagerProvider)ds).CurrencyManager;
            }
            else
            {
                //find from bindingcontext?
            }

            if (cm != null)
            {
                cm.CurrentChanged += new EventHandler(bsource_CurrentChanged);
                if (NeedSync)
                {
                    SyncCurrencyManagers();
                }
            }
            base.OnDataSourceChanged(e);
        }

        int suspendlistchange;

        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (suspendlistchange > 0 || resetting)
            {
                return;
            }

            if (shouldreset)
            {
                switch (e.ListChangedType)
                {
                    case ListChangedType.ItemChanged:
                        if (groupon.IsProperty(e.PropertyDescriptor) && !info.Groups.IsNewRow(e.NewIndex))
                        {
                            reset(true);
                        }
                        else
                        {
                            FireBaseChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, IndexOf(List[e.NewIndex]), e.PropertyDescriptor), false);
                        }
                        return;
                    case ListChangedType.ItemAdded:
                        if (info.Groups.HasNewRow)
                        {
                            info.Groups.AddNew(List[e.NewIndex], true);
                        }
                        else
                        {
                            reset(true);
                        }
                        return;
                    case ListChangedType.ItemDeleted:
                        reset(true);
                        return;
                    case ListChangedType.Reset:
                        reset(true);
                        return;
                    case ListChangedType.ItemMoved:
                        reset(true); //check sorting??
                        return;
                }
            }

            switch (e.ListChangedType)
            {
                case ListChangedType.PropertyDescriptorAdded:
                case ListChangedType.PropertyDescriptorChanged:
                case ListChangedType.PropertyDescriptorDeleted:
                    props = null;
                    break;
            }

            base.OnListChanged(e);
        }

        bool shouldreset
        {
            get { return info != null && info.Groups != null; }
        }

        public override object AddNew()
        {
            if (!shouldreset)
            {
                return base.AddNew();
            }

            object res;
            int newrow;
            suspendlistchange++;
            try
            {
                res = base.AddNew();
                newrow = info.Groups.AddNew(res, false);
            }
            finally
            {
                suspendlistchange--;
            }

            Position = newrow;
            return res;
        }

        public override void ApplySort(PropertyDescriptor property, ListSortDirection sort)
        {
            if (property is PropertyWrapper)
            {
                property = (property as PropertyWrapper).Property;
            }
            base.ApplySort(property, sort);
        }

        public override void ApplySort(ListSortDescriptionCollection sorts)
        {
            base.ApplySort(sorts);
        }

        public override void RemoveAt(int index)
        {
            if (!shouldreset)
            {
                base.RemoveAt(index);
            }
            else if (!IsGroupRow(index))
            {
                suspendlistchange++;
                try
                {
                    // Удалить из базового списка.
                    var rec = this[index];
                    var i = List.IndexOf(rec);
                    if (i != -1)
                    {
                        List.RemoveAt(i);
                    }

                    //Удалить из списка строк.
                    info.Rows.RemoveAt(index);

                    base.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));

                    var gr = GetGroup(index);
                    if (gr != null)
                    {
                        gr.Remove(rec);
                    }
                }
                finally
                {
                    suspendlistchange--;
                }
            }
        }

        public override void Remove(object value)
        {
            if (value is GroupRow)
            {
                return;
            }

            int index = this.IndexOf(value);

            if (index != -1)
            {
                RemoveAt(index);
            }
        }

        void ICancelAddNew.CancelNew(int pos)
        {
            if (!shouldreset || !info.Groups.IsNewRow(pos))
            {
                return;
            }

            ICancelAddNew list = this.List as ICancelAddNew;
            if (list != null)
            {
                suspendlistchange++;
                try
                {
                    int li = List.IndexOf(this[pos]);
                    list.CancelNew(li);
                }
                finally { suspendlistchange--; }
            }
            RemoveAt(pos);
        }


        protected override void OnCurrentChanged(EventArgs e)
        {
            base.OnCurrentChanged(e);
            if (NeedSync)
            {
                var cur = Current;
                while (cur is GroupRow)
                {
                    cur = ((GroupRow)cur).FirstRow;
                    if (cur == cm.Current)
                    {
                        return;
                    }
                }
                suspendsync = true;
                try
                {
                    cm.Position = cm.List.IndexOf(cur);
                }
                finally
                {
                    suspendsync = false;
                }
            }
        }

        void bsource_CurrentChanged(object sender, EventArgs e)
        {
            if (NeedSync)
            {
                SyncCurrencyManagers();
            }
        }

        bool suspendsync;

        bool NeedSync
        {
            get
            {
                if (cm == null || suspendlistchange > 0 || suspendsync || cm.Count == 0)
                {
                    return false;
                }

                //if (cm.IsBindingSuspended || this.IsBindingSuspended)
                //{
                //    return false;
                //}

                var p1 = Position;
                if (p1 == cm.Position)
                {
                    if (p1 == -1)
                    {
                        return false;
                    }
                    return Current != cm.Current;
                }
                return true;
            }
        }

        private void SyncCurrencyManagers()
        {
            suspendsync = true;
            try
            {
                if (cm.Count > 0)
                {
                    Position = IndexOf(cm.Current);
                }
            }
            finally { suspendsync = false; }
        }

        public override int IndexOf(object value)
        {
            return Info.Rows.IndexOf(value);
        }

        public override bool Contains(object value)
        {
            return Info.Rows.Contains(value);
        }

        public override void Clear()
        {
            suspendlistchange++;
            try
            {
                base.Clear();
                if (shouldreset)
                {
                    info.Groups.Fill();
                }
                FireBaseReset(false);
            }
            finally
            {
                suspendlistchange--;
            }
        }

        public override int Add(object value)
        {
            return base.Add(value);
        }

        public override void Insert(int index, object value)
        {
            base.Insert(index, value);
        }

        public class PropertyWrapper : PropertyDescriptor
        {
            public readonly PropertyDescriptor Property;
            public readonly GroupingSource Owner;

            public PropertyWrapper(PropertyDescriptor Property, GroupingSource Owner) : base(Property)
            {
                this.Property = Property;
                this.Owner = Owner;
            }

            public override bool CanResetValue(object component)
            {
                return Property.CanResetValue(component);
            }

            public override Type ComponentType
            {
                get { return Property.ComponentType; }
            }

            public override object GetValue(object component)
            {
                if (component is GroupRow)
                {
                    if (Owner.groupon.IsProperty(Property))
                    {
                        return (component as GroupRow).Value;
                    }
                    return null;
                }
                return Property.GetValue(component);
            }

            public override bool IsReadOnly
            {
                get { return Property.IsReadOnly; }
            }

            public override Type PropertyType
            {
                get { return Property.PropertyType; }
            }

            public override string Category
            {
                get { return Property.Category; }
            }

            public override string Description
            {
                get { return Property.Description; }
            }

            public override string DisplayName
            {
                get { return Property.DisplayName; }
            }

            public override bool DesignTimeOnly
            {
                get { return Property.DesignTimeOnly; }
            }

            public override AttributeCollection Attributes
            {
                get { return Property.Attributes; }
            }

            public override string Name
            {
                get { return Property.Name; }
            }

            public override void ResetValue(object component)
            {
                Property.ResetValue(component);
            }

            public override void SetValue(object component, object value)
            {
                Property.SetValue(component, value);
            }

            public override bool ShouldSerializeValue(object component)
            {
                return Property.ShouldSerializeValue(component);
            }
        }

        PropertyDescriptorCollection props;

        public override PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            if (listAccessors == null)
            {
                if (props == null)
                {
                    /*
                    props = new PropertyDescriptorCollection(
                        base.GetItemProperties(null).Cast<PropertyDescriptor>()
                        .Select(pd => new PropertyWrapper(pd, this)).ToArray());*/
                    props = base.GetItemProperties(null);
                    if (props == null)
                    {
                        return null;
                    }
                    PropertyDescriptor[] arr = new PropertyDescriptor[props.Count];

                    for (int i = 0; i < props.Count; i++)
                    {
                        arr[i] = new PropertyWrapper(props[i], this);
                    }
                    props = new PropertyDescriptorCollection(arr);
                }
                return props;
            }
            return base.GetItemProperties(listAccessors);
        }

        // Количество базового источника (без групповых запросов).
        public int BaseCount
        {
            get { return List.Count; }
        }

        public object GetBaseRow(int Index)
        {
            return List[Index];
        }

        // Общее количество: количество записей плюс количество групповых записей.
        public override int Count
        {
            get { return Info.Rows.Count; }
        }

        public override object this[int index]
        {
            get { return Info.Rows[index]; }
            set { Info.Rows[index] = value; }
        }
    }

    #endregion

    #region файл GroupList.cs

    // Коллекция GroupRow, используемая GroupingSource
    public class GroupList : IEnumerable<GroupRow>
    {
        GroupingInfo gi;
        public readonly GroupingSource Source;
        public readonly Type GroupValueType;
        GenericComparer comparer;

        // Текущая коллекция GroupRow.
        internal List<GroupRow> List = new List<GroupRow>();

        // Коллекции всех групп. Записи в этом списке сохраняются для сохранения настроек (например, свернутые)
        // для каждой группы. Очищается только коллекция строк внутри каждого GroupRow.
        List<GroupRow> allgroups = new List<GroupRow>();

        public GroupList(GroupingSource Source)
        {
            this.Source = Source;
            this.gi = Source.GroupOn;
            this.GroupValueType = gi.GroupValueType;
        }

        internal IList Fill()
        {
            var options = Source.Options;
            bool startcollapsed = options.StartCollapsed;
            bool RemoveEmpty = allgroups.Count > 0;

            if (RemoveEmpty)
            {
                foreach (var g in allgroups)
                {
                    g.Rows.Clear();
                    //if (startcollapsed)
                    //{
                    //    g.SetCollapsed(true, false);
                    //}
                }
            }
            List.Clear();
            if (newrows != null)
            {
                newrows.Rows.Clear();
            }

            foreach (object row in Source.List)
            {
                object key = gi.GetGroupValue(row);
                int hash = key == null ? 0 : key.GetHashCode();
                GroupRow gr = null;
                for (int i = 0; i < allgroups.Count; i++)
                {
                    if (allgroups[i].HashCode == hash && (key == null || key.Equals(allgroups[i].value)))
                    {
                        gr = allgroups[i];
                        break;
                    }
                }

                if (gr == null)
                {
                    gr = new GroupRow(this);
                    gr.value = key;
                    gr.HashCode = hash;
                    if (startcollapsed)
                    {
                        gr.SetCollapsed(true, false);
                    }
                    allgroups.Add(gr);
                }
                gr.Rows.Add(row); // Не gr.Add чтобы предотвратить события, измененные списком.
            }


            if (RemoveEmpty)
            {
                foreach (var g in allgroups)
                {
                    if (g.Count > 0)
                    {
                        List.Add(g);
                    }
                }
            }
            else
            {
                List.AddRange(allgroups);
            }

            sort(Source.GroupSortOrder, false);

            if (Rows == null)
            {
                Rows = new ArrayList(List.Count + Source.BaseCount);
            }
            else
            {
                Rows.Clear();
            }

            if (startcollapsed && !RemoveEmpty)
            {
                AddGroupsOnly();
            }
            else
            {
                RebuildRows();
            }
            CheckNewRow(false);
            return Rows;
        }

        int compare(GroupRow g1, GroupRow g2)
        {
            return comparer.Compare(g1.value, g2.value);
        }

        internal ArrayList Rows;

        internal void RebuildRows()
        {
            int gi = 0;
            foreach (GroupRow g in List)
            {
                g.Index = Rows.Count;
                g.GroupIndex = gi++;
                Rows.Add(g);
                if (!g.Collapsed)
                {
                    foreach (object row in g.Rows)
                    {
                        Rows.Add(row);
                    }
                }
            }
        }

        // Добавляет группы в коллекцию строк и объединяет группы.
        internal void AddGroupsOnly()
        {
            Rows.AddRange(List);
            ReIndex(0);
        }

        internal void ReIndex(int From)
        {
            int last = From == 0 ? 0 : List[From - 1].LastIndex + 1;
            for (int i = From; i < List.Count; i++)
            {
                List[i].Index = last;
                List[i].GroupIndex = i;
                last = List[i].LastIndex + 1;
            }
        }

        public GroupRow[] ToArray()
        {
            return List.ToArray();
        }

        public int Count
        {
            get { return List.Count; }
        }

        public GroupRow this[int Index]
        {
            get { return List[Index]; }
        }

        public int IndexOf(GroupRow row)
        {
            return List.IndexOf(row);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return List.GetEnumerator();
        }

        IEnumerator<GroupRow> IEnumerable<GroupRow>.GetEnumerator()
        {
            return List.GetEnumerator();
        }

        public GroupRow GetByRow(int RowIndex)
        {
            GroupRow res = null;
            foreach (GroupRow g in List)
            {
                if (g.Index > RowIndex)
                {
                    break;
                }
                res = g;
            }
            return res;
        }

        public void CollapseExpandAll(bool collapse)
        {
            foreach (var gr in List)
            {
                gr.SetCollapsed(collapse, false);
            }

            Rows.Clear();
            if (collapse)
            {
                AddGroupsOnly();
            }
            else
            {
                RebuildRows();
            }
            Source.FireBaseReset(false);
        }

        void sort(SortOrder order, bool Rebuild)
        {
            if (order != SortOrder.None)
            {
                GroupRow g = Rebuild ? Source.GetGroup(Source.Position) : null;

                if (comparer == null)
                {
                    comparer = new GenericComparer(GroupValueType);
                }

                comparer.Descending = order == SortOrder.Descending;
                List.Sort(compare);

                if (Rebuild)
                {
                    Rows.Clear();
                    RebuildRows();
                    Source.FireBaseReset(false);
                    if (g != null)
                    {
                        Source.Position = g.Index;
                        if (!g.Collapsed)
                        {
                            Source.Position++;
                        }
                    }
                }
            }
        }

        public void Sort(SortOrder sortOrder)
        {
            sort(sortOrder, true);
        }

        internal int AddNew(object res, bool GroupOnly)
        {
            if (newrows == null)
            {
                int i = Rows.Add(res);
                Source.FireBaseChanged(ListChangedType.ItemAdded, i, false);
                return i;
            }
            else
            {
                return newrows.Add(res);
            }
        }

        internal bool HasNewRow
        {
            get { return newrows != null; }
        }

        internal bool IsNewRow(int pos)
        {
            if (newrows == null)
            {
                return false;
            }
            return pos > newrows.Index;
        }

        internal void CheckNewRow(bool FireChanged)
        {
            var grid = Source.Grid;
            bool nr = grid != null && grid.AllowUserToAddRows;

            int i = FireChanged && newrows != null ? Rows.IndexOf(newrows) : -1;

            if (nr)
            {
                if (i == -1)
                {
                    if (newrows == null)
                    {
                        newrows = new NewRowsGroup(this);
                        //allgroups.Add(newrows);
                    }
                    newrows.Index = Rows.Count;
                    List.Add(newrows);
                    Rows.Add(newrows);
                    if (FireChanged)
                    {
                        Source.FireBaseChanged(ListChangedType.ItemAdded, newrows.Index, true);
                    }
                }
            }
            else if (i != -1)
            {
                Rows.RemoveAt(i);
                if (newrows.Count == 0)
                {
                    Source.FireBaseChanged(ListChangedType.ItemDeleted, i, true);
                }
                else
                {
                    newrows.Rows.Clear();
                    Fill();
                    Source.FireBaseReset(true);
                }
            }
        }

        NewRowsGroup newrows;

        class NewRowsGroup : GroupRow
        {
            public NewRowsGroup(GroupList list) : base(list)
            {
            }

            protected override void SetDisplayInfo(GroupDisplayEventArgs e)
            {
                base.SetDisplayInfo(e);
                e.Header = "New Rows";
                e.DisplayValue = null;
            }

            protected override bool AllowRemove
            {
                get { return false; }
            }

            protected override bool AllowCollapse
            {
                get { return false; }
            }
        }
    }

    // Информация об одной группе внутри GroupingSource.
    public class GroupRow : IEnumerable
    {
        // Список владельцев, который создал эту группу.
        public readonly GroupList Owner;

        internal GroupRow(GroupList Owner)
        {
            this.Owner = Owner;
        }

        // Индекс, который эта группа имеет в качестве объекта строки в ОБЩЕЙ коллекции.
        public int Index { get; internal set; }

        // Коллекция-индекс последней строки в этой группе.
        public int LastIndex
        {
            get
            {
                if (collapsed)
                {
                    return Index;
                }
                return Index + Rows.Count;
            }
        }

        // Индекс самой группы в коллекции групп.
        public int GroupIndex { get; internal set; }

        internal object value;

        // Ключевое значение, на котором основана эта группа.
        public object Value
        {
            get { return value; }
        }

        // Количество строк внутри этой группы.
        public int Count
        {
            get { return Rows.Count; }
        }

        bool collapsed;

        // Возвращает или задает, должна ли группа отображаться свернутой (только для группы) или полностью.
        public bool Collapsed
        {
            get { return collapsed; }
            set { SetCollapsed(value, true); }
        }

        internal void SetCollapsed(bool collapse, bool Perform)
        {
            if (collapsed == collapse)
            {
                return;
            }
            if (collapse && !AllowCollapse)
            {
                return;
            }
            collapsed = collapse;

            if (Perform)
            {
                int index = Index + 1;
                if (collapse)
                {
                    Owner.Rows.RemoveRange(index, Rows.Count);
                }
                else
                {
                    Owner.Rows.InsertRange(index, Rows);
                }
                Owner.ReIndex(Owner.IndexOf(this));
                try
                {
                    if (Rows.Count > 1)
                    {
                        Owner.Source.FireBaseReset(true);
                    }
                    else
                    {
                        Owner.Source.FireBaseChanged(collapsed ? ListChangedType.ItemDeleted : ListChangedType.ItemAdded, index, true);
                    }
                }
                catch { }
            }
        }

        protected virtual bool AllowCollapse
        {
            get { return true; }
        }

        internal List<object> Rows = new List<object>();
        internal int HashCode;

        // Возвращает строку с указанным индексом внутри этой группы. Индекс равен 0, основанному внутри этой группы, а не индексу коллекции, на которой он основан.
        public object this[int Index]
        {
            get { return Rows[Index]; }
        }

        public object FirstRow
        {
            get
            {
                if (Rows.Count == 0)
                {
                    return null;
                }
                return Rows[0];
            }
        }

        public GroupDisplayEventArgs GetDisplayInfo(bool selected)
        {
            GroupDisplayEventArgs e = new GroupDisplayEventArgs(this, Owner.Source.GroupOn);
            e.Selected = selected;
            SetDisplayInfo(e);
            if (e.Cancel)
            {
                return null;
            }
            Owner.Source.FireDisplayGroup(e);
            return e;
        }

        protected virtual void SetDisplayInfo(GroupDisplayEventArgs e)
        {
            var grid = Owner.Source.Grid;
            if (grid != null)
            {
                e.BackColor = e.Selected ? grid.DefaultCellStyle.SelectionBackColor : grid.DefaultCellStyle.BackColor;
                e.ForeColor = e.Selected ? grid.DefaultCellStyle.SelectionForeColor : grid.DefaultCellStyle.ForeColor;
            }

            var o = Owner.Source.Options;
            if (o.ShowCount)
            {
                e.Summary = "(" + Count + ")";
            }
            if (o.ShowGroupName)
            {
                e.Header = e.GroupingInfo.ToString();
            }
            e.GroupingInfo.SetDisplayValues(e);
        }

        public virtual void Remove(object rec)
        {
            if (!Rows.Remove(rec))
            {
                return;
            }
            bool delete = Count == 0 && AllowRemove;
            int i = Owner.List.IndexOf(this);
            if (delete)
            {
                Owner.Rows.RemoveAt(Index);
                Owner.List.RemoveAt(i);
            }
            Owner.ReIndex(i);
            Owner.Source.FireBaseChanged(delete ? ListChangedType.ItemDeleted : ListChangedType.ItemChanged, Index, true);
        }

        public virtual int Add(object rec)
        {
            int i = Owner.Rows.Add(rec);
            Owner.Source.FireBaseChanged(ListChangedType.ItemAdded, i, false);
            Rows.Add(rec);
            Owner.Source.FireBaseChanged(ListChangedType.ItemChanged, Index, false);
            return i;
        }

        protected virtual bool AllowRemove
        {
            get { return true; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Rows.GetEnumerator();
        }
    }

    #endregion

    #region файл SearchBox.cs

    public abstract partial class SearchBoxBase : UserControl, ISupportInitialize
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.Button btnNext;
        protected System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsClear;
        private System.Windows.Forms.ToolStripMenuItem tsInner;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

        public SearchBoxBase()
        {
            searchmatcher = new StringSearchMatcher(GetDefaultMode());

            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchBoxBase));
            txt = new System.Windows.Forms.TextBox();
            btnNext = new System.Windows.Forms.Button();
            menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            tsInner = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            tsClear = new System.Windows.Forms.ToolStripMenuItem();
            menu.SuspendLayout();
            SuspendLayout();

            txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txt.Dock = System.Windows.Forms.DockStyle.Fill;
            txt.Location = new System.Drawing.Point(0, 0);
            txt.Margin = new System.Windows.Forms.Padding(4);
            txt.Name = "txt";
            txt.Size = new System.Drawing.Size(204, 22);
            txt.TabIndex = 0;
            txt.TextChanged += new System.EventHandler(this.txt_TextChanged);

            btnNext.Dock = System.Windows.Forms.DockStyle.Right;
            string str_btnNext = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAAlwSFlzAAAK9wAACvcBEOiS5wAAAS5JREFUOE9j+P//P0UYqyApGKsgDM/ZMuH/sgMzPLDJwTBWQRievKrzf8v06v8zN/SmYJMHYayCMNyzsOn/jodL8RqCwlm0Z+p/kLNBNoM0t8yo+b/76Yr/04434DQEhQPSfPLjlv9H3q37v//Vqv87nyz5v+3B4v89B8v+N2zKhRiysTcZWQ+KASCbj73f+H/to8n/F9/o/j/jbCNE89ac/yWrkv6nTAr7n16WAFSKwwCQs/e9XPm/bXPx/9pVWf9LFiT9z5oeBdbsV+78X0ZJ+r+po0kQsh4UA0B+VtZW+q9jpv3f1MH4v42n1f+E3kC4ZjMnU19k9SCMwkHH9ZMq8GoGYQwBZAwyAKRZVVcFq2YQxioIwyADgN4xxiYHw1gFScFYBUnBWAWJx/8ZAKWH1qCc8THzAAAAAElFTkSuQmCC";
            byte[] imageBytes = Convert.FromBase64String(str_btnNext);
            var ms = new System.IO.MemoryStream(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            btnNext.Image = image;
            btnNext.Location = new System.Drawing.Point(204, 0);
            btnNext.Margin = new System.Windows.Forms.Padding(4);
            btnNext.Name = "btnNext";
            btnNext.Size = new System.Drawing.Size(27, 26);
            btnNext.TabIndex = 0;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += new System.EventHandler(this.btnNext_Click);

            menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripSeparator1,
            tsInner,
            toolStripSeparator2,
            tsClear});
            menu.Name = "menu";
            menu.Size = new System.Drawing.Size(284, 60);
            menu.Opening += new System.ComponentModel.CancelEventHandler(this.menu_Opening);

            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(280, 6);

            tsInner.Name = "tsInner";
            tsInner.Size = new System.Drawing.Size(283, 22);
            tsInner.Text = "Поиск по внутреннему тексту";
            tsInner.ToolTipText = "Если флажок установлен, поиск выполняется по всему тексту, в противном случае тол" +
                "ько по значениям, начинающимся с выполняется поиск поисковых значений";
            tsInner.Click += new System.EventHandler(this.tsInner_Click);

            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(280, 6);

            tsClear.Name = "tsClear";
            tsClear.Size = new System.Drawing.Size(283, 22);
            tsClear.Text = "Очистить";
            tsClear.Click += new System.EventHandler(this.tsClear_Click);

            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ContextMenuStrip = this.menu;
            Controls.Add(this.txt);
            Controls.Add(this.btnNext);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "SearchBoxBase";
            Size = new System.Drawing.Size(231, 26);
            menu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        StringSearchMatcher searchmatcher;

        protected virtual SearchBoxMode GetDefaultMode()
        {
            return SearchBoxMode.Lookup_Wildcards;
        }

        public SearchBoxMode Mode
        {
            get { return searchmatcher.Mode; }
            set
            {
                if (Mode == value)
                {
                    return;
                }
                searchmatcher.Mode = value;
                btnNext.Visible = value != SearchBoxMode.Filter;
                NotifyStateChanged(true);
            }
        }

        bool ShouldSerializeMode()
        {
            return Mode != GetDefaultMode();
        }

        public void ResetMode()
        {
            Mode = GetDefaultMode();
        }

        public Func<string, bool> SearchDelegate
        {
            get { return searchmatcher.SearchDelegate; }
        }

        bool alwayswildcard = false;

        [DefaultValue(false)]
        public bool AlwaysSearchInnerText
        {
            get { return alwayswildcard; }
            set
            {
                if (alwayswildcard == value)
                {
                    return;
                }
                alwayswildcard = value;
                searchmatcher.AlwaysSearchInnerText = value;
                NotifyStateChanged(false);
            }
        }

        protected void NotifyStateChanged(bool resettext)
        {
            if (IsBusy || disposed)
            {
                return;
            }
            ResetStartPosition(null);
            NullResult = false;
            checkvalid();

            if (txt.TextLength > 0)
            {
                if (resettext)
                {
                    txt.Clear();
                }
                else
                {
                    check();
                }
            }
        }

        // Очистите все используемые ресурсы.
        protected override sealed void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            while (registeredcontrols.Count > 0)
            {
                UnRegisterControl(registeredcontrols[0]);
            }
            disposed = true;
            OnDisposed();
        }

        bool disposed;

        protected virtual void OnDisposed()
        {
        }

        int initializing;

        public bool IsInitializing
        {
            get { return initializing > 0; }
        }

        public void BeginInit()
        {
            initializing++;
        }

        public void EndInit()
        {
            if (--initializing == 0)
            {
                OnEndInit();
            }
        }

        protected virtual void OnEndInit()
        {
            NotifyStateChanged(false);
        }

        void checkvalid()
        {
            isvalid = CheckIsReady();
            if (isvalid && !Supports(Mode))
            {
                isvalid = false;
                OnInvalidModeSelected();
            }
            txt.Enabled = isvalid;
        }

        bool isvalid;
        public bool IsValid
        {
            get { return isvalid; }
        }

        protected virtual void OnInvalidModeSelected()
        {
            var ex = new Exception("Source does not support " + Mode);
            if (DesignMode)
            {
                throw ex;
            }
            ShowException(ex);
        }

        protected virtual bool CheckIsReady()
        {
            return initializing == 0;
        }

        protected virtual bool Supports(SearchBoxMode Mode)
        {
            return true;
        }

        Label lbl;

        [DefaultValue(false)]
        [Category("Label")]
        public bool ShowLabel
        {
            get { return lbl != null; }
            set
            {
                if (ShowLabel == value)
                {
                    return;
                }
                if (value)
                {
                    lbl = new Label();
                    setlabeltext();
                    lbl.Dock = DockStyle.Left;
                    lbl.AutoSize = true;
                    Controls.Add(lbl);
                }
                else
                {
                    lbl.Dispose();
                    lbl = null;
                }
            }
        }

        void setlabeltext()
        {
            if (labeltext == null)
            {
                var val = "Search";
                GetText(val, ref val);
                lbl.Text = val;
            }
            else
            {
                lbl.Text = labeltext;
            }
        }

        partial void GetText(string keyword, ref string Value);

        string labeltext = null;

        [Category("Label")]
        [DefaultValue(null)]
        public string CustomLabelText
        {
            get { return labeltext; }
            set
            {
                labeltext = value;
                if (lbl == null)
                {
                    if (DesignMode)
                    {
                        ShowLabel = true;
                    }
                }
                else
                {
                    setlabeltext();
                }
            }
        }

        protected bool HandleKey(KeyEventArgs k)
        {
            return HandleKey(k.KeyCode, k.Modifiers);
        }

        protected bool HandleKey(Keys key, Keys mod)
        {
            if (key == Keys.Back)
            {
                if (mod == Keys.Control)
                {
                    Text = null;
                }
                else if (Text.Length > 0)
                {
                    Text = Text.Substring(0, Text.Length - 1);
                }
            }
            else if (key == Keys.Escape)
            {
                Text = null;
            }
            else
            {
                return false;
            }
            return true;
        }

        protected bool HandleKey(KeyPressEventArgs e)
        {
            var c = e.KeyChar;
            if (c < 32 || c > 127)
            {
                return false;
            }
            Text += c.ToString();
            return true;
        }

        void c_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (HandleRegisteredKeyDowns)
            {
                e.Handled = HandleKey(e);
            }
        }

        void c_KeyDown(object sender, KeyEventArgs e)
        {
            if (HandleRegisteredKeyDowns)
            {
                e.Handled = HandleKey(e);
            }
        }

        protected bool HandleRegisteredKeyDowns = true;

        List<Control> registeredcontrols = new List<Control>();

        protected void RegisterControl(Control c)
        {
            if (registeredcontrols.Contains(c))
            {
                return;
            }
            registeredcontrols.Add(c);
            c.KeyDown += new KeyEventHandler(c_KeyDown);
            c.KeyPress += new KeyPressEventHandler(c_KeyPress);
        }

        protected void UnRegisterControl(Control c)
        {
            if (registeredcontrols.Remove(c))
            {
                c.KeyDown -= new KeyEventHandler(c_KeyDown);
                c.KeyPress -= new KeyPressEventHandler(c_KeyPress);
            }
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            searchmatcher.SearchText = Text;
            check();
            OnTextChanged(e);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SearchNext();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Text = null;
        }

        [DefaultValue(null)]
        public override string Text
        {
            get { return txt.Text; }
            set { txt.Text = value; }
        }

        public int TextLength
        {
            get { return searchmatcher.TextLength; }
        }

        int prevlen;

        void check()
        {
            setvisible();
            if (!isvalid)
            {
                return;
            }
            if (txt.TextLength < prevlen)
            {
                ResetStartPosition(null);
            }
            prevlen = txt.TextLength;

            if (Mode == SearchBoxMode.Filter)
            {
                Filter();
            }
            else
            {
                Search();
            }

            btnNext.Enabled = prevlen > 0 && !nullresult;
        }

        void setvisible()
        {
            if (autohide)
            {
                Visible = txt.TextLength > 0;
            }
        }

        private bool autohide;

        [DefaultValue(false)]
        public bool AutoHide
        {
            get { return autohide; }
            set
            {
                if (autohide == value)
                {
                    return;
                }
                autohide = value;
                setvisible();
            }
        }

        protected abstract void ResetStartPosition(object storedpos);
        protected abstract bool IncreasePosition();
        protected abstract void SetFoundPosition();
        bool nullresult;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NullResult
        {
            get { return nullresult; }
            private set
            {
                if (nullresult == value)
                {
                    return;
                }
                nullresult = value;
                txt.BackColor = value ? notfoundcol : Color.Empty;
            }
        }

        Color notfoundcol = Color.Red;

        public Color NotFoundColor
        {
            get { return notfoundcol; }
            set { notfoundcol = value; }
        }

        bool ShouldSerializeNotFoundColor()
        {
            return notfoundcol != Color.Red;
        }

        bool searching;

        public bool Search()
        {
            var res = search();
            NullResult = txt.TextLength > 0 && !res;
            return res;
        }

        public bool IsSearching
        {
            get { return searching; }
        }

        public bool IsFiltering
        {
            get { return filtering; }
        }

        // Указывает, выполняется ли фильтрация или поиск.
        public bool IsBusy
        {
            get { return searching || filtering || initializing > 0; }
        }

        public bool SearchNext()
        {
            IncreasePosition();
            return Search();
        }

        bool search()
        {
            searching = true;
            try
            {
                return txt.TextLength > 0 && search(searchmatcher);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
            finally
            {
                searching = false;
            }
            return false;
        }

        protected abstract object GetPosition();
        protected abstract object GetCurrent();

        protected virtual bool search(StringSearchMatcher search)
        {
            object pos = GetPosition();
            for (;;)
            {
                var val = GetCurrent();
                if (val != null && search.Matches(val.ToString()))
                {
                    SetFoundPosition();
                    return true;
                }
                if (!IncreasePosition())
                {
                    break;
                }
            }
            ResetStartPosition(pos);
            return false;
        }

        bool filtering;

        public void Filter()
        {
            filtering = true;
            try
            {
                filter(searchmatcher);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
            finally
            {
                filtering = false;
            }
        }

        protected virtual void ShowException(Exception ex)
        {
            if (Disposing)
            {
                return;
            }
            //new ErrorForm(ex).Show(this);            
            MessageBox.Show(ex.Message); // Вызовите здесь свою собственную процедуру устранения ошибок.
        }

        protected abstract void filter(StringSearchMatcher search);

        // Базовое текстовое поле
        public System.Windows.Forms.TextBox TextBox
        {
            get { return txt; }
        }

        ContextMenuStripButton btnOptions;

        [DefaultValue(false)]
        public bool ShowOptionsButton
        {
            get { return btnOptions != null; }
            set
            {
                if (ShowOptionsButton == value)
                {
                    return;
                }
                if (value)
                {
                    btnOptions = new ContextMenuStripButton();
                    btnOptions.Dock = DockStyle.Right;
                    btnOptions.ContextMenuStrip = menu;
                    Controls.Add(btnOptions);
                }
                else
                {
                    btnOptions.Dispose();
                    btnOptions = null;
                }
            }
        }

        ModeItem[] modeitems;

        private void menu_Opening(object sender, CancelEventArgs e)
        {
            if (modeitems == null)
            {
                modeitems = Enum.GetValues(typeof(SearchBoxMode)).Cast<SearchBoxMode>().Select(sm => new ModeItem(this, sm)).ToArray();
                for (int i = 0; i < modeitems.Length; i++)
                {
                    menu.Items.Insert(i, modeitems[i]);
                }
                OnOpeningContextMenu(menu, true);
            }
            else
            {
                foreach (var m in modeitems)
                {
                    m.Check();
                }
                OnOpeningContextMenu(menu, false);
            }
            tsInner.Checked = alwayswildcard;
            tsClear.Enabled = txt.TextLength > 0;
        }

        protected virtual void OnOpeningContextMenu(ContextMenuStrip menu, bool FirstTime)
        {
        }

        void tsClear_Click(object sender, System.EventArgs e)
        {
            txt.Clear();
        }

        void tsInner_Click(object sender, System.EventArgs e)
        {
            AlwaysSearchInnerText = !alwayswildcard;
        }

        protected class SearchBoxItem : ToolStripMenuItem
        {
            public readonly SearchBoxBase SearchBox;

            public SearchBoxItem(SearchBoxBase sb)
            {
                SearchBox = sb;
            }
        }

        protected class ModeItem : SearchBoxItem
        {
            public readonly SearchBoxMode Mode;

            public ModeItem(SearchBoxBase sb, SearchBoxMode mode) : base(sb)
            {
                Mode = mode;
                Text = Mode.ToString();
                Check();
            }

            public void Check()
            {
                Checked = SearchBox.Mode == Mode;
            }

            protected override void OnClick(EventArgs e)
            {
                SearchBox.Mode = Mode;
            }
        }
    }

    public abstract class SourceSearchBox : SearchBoxBase
    {
        private Column col;

        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Editor(typeof(Editor), typeof(UITypeEditor))]
        public Column SearchProperty
        {
            get { return col; }
            set
            {
                if (col == value)
                {
                    return;
                }
                col = value;
                propname = value == null ? null : value.Name;
                pos.X = col == null ? 0 : col.Index.Value;
                NotifyStateChanged(true);
            }
        }

        private string propname;

        [DefaultValue(null)]
        public string PropertyName
        {
            get { return propname; }
            set
            {
                if (propname == value)
                {
                    return;
                }
                propname = value;
                if (IsInitializing)
                {
                    return;
                }
                if (needsetprops)
                {
                    setprops();
                }
                else if (value == null || Columns == null)
                {
                    NotifyStateChanged(false);
                }
                else
                {
                    SearchProperty = getcol(value, true);
                }
            }
        }

        Column getcol(string name, bool Throw)
        {
            var col = props.FirstOrDefault(c => c.Name == name);
            if (col == null && Throw)
            {
                throw new ArgumentException(name + " is not a valid property");
            }
            return col;
        }

        protected void SourceChanged()
        {
            needsetprops = true;
            NotifyStateChanged(true);
        }

        protected override void OnEndInit()
        {
            base.OnEndInit();
            if (propname != null)
            {
                PropertyName = propname;
            }
        }

        protected override bool search(StringSearchMatcher search)
        {
            if (needsetprops)
            {
                setprops();
            }
            return base.search(search);
        }

        Column[] props;
        public Column[] Columns
        {
            get
            {
                if (needsetprops)
                {
                    if (IsInitializing)
                    {
                        return null;
                    }
                    setprops();
                }
                return props;
            }
        }

        protected void ResetColumns()
        {
            needsetprops = true;
        }

        void setprops()
        {
            needsetprops = false;
            var cols = GetColumns();
            if (cols == null)
            {
                props = null;
            }
            else
            {
                props = GetColumns().ToArray();
                if (props.Length == 0)
                {
                    props = null;
                }
                else
                {
                    for (int i = 0; i < props.Length; i++)
                    {
                        if (props[i].Index == null)
                        {
                            props[i].Index = i;
                        }
                    }
                }
                if (propname != null)
                {
                    col = getcol(propname, false);
                    if (col == null)
                    {
                        propname = null;
                        pos.X = 0;
                    }
                }
            }
        }

        protected abstract IEnumerable<Column> GetColumns();

        public class Column
        {
            public readonly string Name;
            public readonly Func<int, object> GetValue;
            public int? Index;

            public Column(string Name, Func<int, object> GetValue)
            {
                this.Name = Name;
                this.GetValue = GetValue;
            }

            private string header;

            public string Header
            {
                get
                {
                    if (header == null)
                    {
                        return Name;
                    }
                    return header;
                }
                set { header = value; }
            }

            public override string ToString()
            {
                return Header;
            }
        }

        bool needsetprops = true;

        class Editor : UITypeEditor
        {
            public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            {
                return UITypeEditorEditStyle.DropDown;
            }

            public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
            {
                var b = (SourceSearchBox)context.Instance;
                if (b != null && b.Columns != null)
                {
                    var lb = new ListBox();
                    foreach (var pd in b.props)
                    {
                        int i = lb.Items.Add(pd);
                        if (b.col == pd || pd.Name == b.propname)
                        {
                            lb.SelectedIndex = i;
                        }
                    }
                    var iw = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                    lb.Click += delegate
                    {
                        b.PropertyName = (string)lb.SelectedItem;
                        iw.CloseDropDown();
                    };
                    iw.DropDownControl(lb);
                }
                return base.EditValue(context, provider, value);
            }
        }

        Point pos;
        int curcol;

        protected override sealed void ResetStartPosition(object stored)
        {
            if (stored == null)
            {
                pos = Point.Empty;
                if (col != null)
                {
                    pos.X = col.Index.Value;
                }
            }
            else
            {
                pos = (Point)stored;
            }
            if (Columns != null && col != null)
            {
                curcol = Array.IndexOf(props, col);
            }
            else
            {
                curcol = 0;
            }
        }

        // Последняя позиция поиска.
        public Point Position
        {
            get { return pos; }
            set { pos = value; }
        }

        protected sealed override void SetFoundPosition()
        {
            try
            {
                SetPosition(pos.X, pos.Y);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        protected abstract void SetPosition(int col, int row);

        protected override object GetCurrent()
        {
            return props[curcol].GetValue(pos.Y);
        }

        protected abstract int RecordCount
        {
            get;
        }

        protected override bool IncreasePosition()
        {
            if (col == null)
            {
                if (++curcol < props.Length)
                {
                    pos.X = props[curcol].Index.Value;
                    return true;
                }
                curcol = 0;
                pos.X = props[0].Index.Value;
            }
            return ++pos.Y < RecordCount;
        }

        protected override object GetPosition()
        {
            return pos;
        }

        protected override bool Supports(SearchBoxMode Mode)
        {
            switch (Mode)
            {
                case SearchBoxMode.Filter:
                    return CanFilter;
                case SearchBoxMode.Lookup:
                    //isvalid &= source.SupportsSearching;
                    break;
            }
            //DataGridView dg;
            return true;
        }

        protected abstract bool CanFilter { get; }

        protected override bool CheckIsReady()
        {
            if (Columns == null)
            {
                return false;
            }
            if (col == null)
            {
                return Mode != SearchBoxMode.Filter;
            }
            return true;
        }

        protected abstract Point GetCurrentPosition();

        protected void filter(IBindingListView source, StringSearchMatcher search)
        {
            if (propname == null || search.TextLength == 0)
            {
                source.RemoveFilter();
                if (propname == null)
                {
                    TextBox.Clear();
                }
            }
            else
            {
                source.Filter = propname + " like " + (AlwaysSearchInnerText ? "*" : null) + Text + "*";
            }

            var p = GetCurrentPosition();
            if (p.X != pos.X && pos.X != -1 && RecordCount > 0 && p.Y != -1)
            {
                SetPosition(pos.X, p.Y);
            }
        }

        protected void NotifyPositionChanged()
        {
            if (IsBusy || Mode == SearchBoxMode.Filter)
            {
                return;
            }
            ResetStartPosition(null);
            Text = null;
        }
    }

    public class BindingSourceSearchBox : SourceSearchBox
    {
        protected override void SetPosition(int col, int row)
        {
            source.Position = row;
        }

        protected override Point GetCurrentPosition()
        {
            if (source == null)
            {
                return Point.Empty;
            }
            return new Point(0, source.Position);
        }

        protected override int RecordCount
        {
            get { return source.Count; }
        }

        protected override bool CanFilter
        {
            get
            {
                var l = source.List as IBindingListView;
                return l != null && l.SupportsFiltering;
            }
        }

        protected override void filter(StringSearchMatcher search)
        {
            filter(source.List as IBindingListView, search);
        }

        protected override void OnDisposed()
        {
            BindingSource = null;
        }

        private CurrencyManager source;

        [DefaultValue(null)]
        public CurrencyManager BindingSource
        {
            get { return source; }
            set
            {
                if (source == value)
                {
                    return;
                }
                if (source != null)
                {
                    source.PositionChanged -= source_PositionChanged;
                    source.ListChanged -= new ListChangedEventHandler(source_ListChanged);
                }
                source = value;
                if (source != null)
                {
                    source.PositionChanged += source_PositionChanged;
                    source.ListChanged += new ListChangedEventHandler(source_ListChanged);
                }
                SourceChanged();
            }
        }

        void source_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.PropertyDescriptorAdded:
                case ListChangedType.PropertyDescriptorChanged:
                case ListChangedType.PropertyDescriptorDeleted:
                    SourceChanged();
                    break;
            }
        }

        protected override IEnumerable<Column> GetColumns()
        {
            if (source == null || source.List == null)
            {
                return null;
            }
            return source.GetItemProperties().Cast<PropertyDescriptor>().Select(pd => new Column(pd.Name, i => pd.GetValue(source.List[i])) { Header = pd.DisplayName });
        }

        void source_PositionChanged(object sender, EventArgs e)
        {
            NotifyPositionChanged();
        }
    }

    public class DataGridSearchBox : SourceSearchBox
    {
        DataGridView grid;

        [DefaultValue(null)]
        [Description("Таблица (DataGridView), связанная с этим полем поиска. Когда таблица доступна только для чтения, также обрабатываются нажатия клавиш самой таблицы")]
        public DataGridView DataGridView
        {
            get { return grid; }
            set
            {
                if (grid == value)
                {
                    return;
                }
                if (grid != null)
                {
                    grid.DataSourceChanged -= grid_DataSourceChanged;
                    grid.CurrentCellChanged -= grid_CurrentCellChanged;
                    grid.ColumnAdded -= grid_ColumnsChanged;
                    grid.ColumnRemoved -= grid_ColumnsChanged;
                    grid.ColumnStateChanged -= grid_ColumnStateChanged;
                    UnRegisterControl(grid);
                }
                grid = value;
                if (grid != null)
                {
                    grid.DataSourceChanged += grid_DataSourceChanged;
                    grid.CurrentCellChanged += grid_CurrentCellChanged;
                    grid.ColumnAdded += grid_ColumnsChanged;
                    grid.ColumnRemoved += grid_ColumnsChanged;
                    grid.ColumnStateChanged += grid_ColumnStateChanged;
                    RegisterControl(grid);
                }
                SourceChanged();
            }
        }

        protected override bool CheckIsReady()
        {
            if (grid == null)
            {
                return false;
            }
            if (grid.Columns.Count == 0)
            {
                return false;
            }
            if (SearchProperty == null)
            {
                if (SearchModeColumn != ColumnSearchMode.AllColumns && Mode != SearchBoxMode.Filter)
                {
                    return false;
                }
            }
            return true;
        }

        void grid_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Visible)
            {
                ResetColumns();
            }
        }

        void grid_ColumnsChanged(object sender, DataGridViewColumnEventArgs e)
        {
            ResetColumns();
            if (!IsValid)
            {
                NotifyStateChanged(true);
            }
        }

        protected override int RecordCount
        {
            get
            {
                if (grid == null)
                {
                    return 0;
                }
                return grid.Rows.Count;
            }
        }

        protected override Point GetCurrentPosition()
        {
            if (grid == null)
            {
                return Point.Empty;
            }
            return grid.CurrentCellAddress;
        }

        protected override void SetPosition(int col, int row)
        {
            grid.CurrentCell = grid[col, row];
        }

        protected override void OnDisposed()
        {
            DataGridView = null;
        }

        protected override IEnumerable<Column> GetColumns()
        {
            if (grid == null)
            {
                return null;
            }
            return from c in grid.Columns.Cast<DataGridViewColumn>()
                   where c.Visible
                   orderby c.DisplayIndex
                   select new Column(c.DataPropertyName, i => grid[c.Index, i].Value)
                   {
                       Header = c.HeaderText,
                       Index = c.Index
                   };
        }

        void grid_DataSourceChanged(object sender, EventArgs e)
        {
            SourceChanged();
        }


        void grid_CurrentCellChanged(object sender, EventArgs e)
        {
            if (IsBusy)
            {
                return;
            }
            setcurrentprop();
        }

        IBindingListView BindingListView
        {
            get
            {
                if (grid == null)
                {
                    return null;
                }
                return grid.DataSource as IBindingListView;
            }
        }

        protected override bool CanFilter
        {
            get { return BindingListView != null && BindingListView.SupportsFiltering; }
        }

        protected override void filter(StringSearchMatcher search)
        {
            filter(BindingListView, search);
        }

        private ColumnSearchMode colsearchmode = ColumnSearchMode.ActiveColumn;

        [DefaultValue(ColumnSearchMode.ActiveColumn)]
        public ColumnSearchMode SearchModeColumn
        {
            get { return colsearchmode; }
            set
            {
                if (colsearchmode == value)
                {
                    return;
                }
                colsearchmode = value;
                setcurrentprop();
                NotifyStateChanged(false);
            }
        }

        DataGridViewCell lastcell;
        void setcurrentprop()
        {
            if (IsBusy)
            {
                return;
            }
            var cell = grid.CurrentCell;
            if (cell == lastcell)
            {
                return;
            }
            lastcell = cell;
            var i = cell == null ? -1 : cell.ColumnIndex;
            Column prop;
            if (i == -1)
            {
                prop = null;
                HandleRegisteredKeyDowns = false;
            }
            else
            {
                var col = grid.Columns[i];
                prop = colsearchmode == ColumnSearchMode.ActiveColumn || Mode == SearchBoxMode.Filter ? Columns.First(c => c.Index == i) : null;
                HandleRegisteredKeyDowns = col.ReadOnly;
            }
            if (SearchProperty == prop)
            {
                Text = null;
                //NotifyStateChanged(true);
            }
            else
            {
                SearchProperty = prop;
            }
        }

        public enum ColumnSearchMode
        {
            ActiveColumn,
            AllColumns
        }

        protected override void OnOpeningContextMenu(ContextMenuStrip menu, bool FirstTime)
        {
            base.OnOpeningContextMenu(menu, FirstTime);
            if (FirstTime)
            {
                searchitems = Enum.GetValues(typeof(ColumnSearchMode)).Cast<ColumnSearchMode>().Select(g => new GridSearchModeItem(this, g)).ToArray();
                menu.Items.Add(new ToolStripSeparator());
                menu.Items.AddRange(searchitems);
            }
            else
            {
                foreach (var m in searchitems)
                {
                    m.Check();
                }
            }
        }

        GridSearchModeItem[] searchitems;

        class GridSearchModeItem : SearchBoxItem
        {
            ColumnSearchMode mode;
            DataGridSearchBox sb;

            public GridSearchModeItem(DataGridSearchBox sb, ColumnSearchMode mode) : base(sb)
            {
                this.mode = mode;
                this.sb = sb;
                this.Text = mode.ToString();
                Check();
            }

            public void Check()
            {
                Checked = mode == sb.colsearchmode;
                Enabled = sb.Mode != SearchBoxMode.Filter;
            }

            protected override void OnClick(EventArgs e)
            {
                sb.SearchModeColumn = mode;
            }
        }
    }

    public class TreeviewSearchBox : SearchBoxBase
    {
        TreeNode lastnode;

        protected override void ResetStartPosition(object storedpos)
        {
            if (storedpos != null)
            {
                lastnode = (TreeNode)storedpos;
            }
            else if (tv == null || tv.Nodes.Count == 0)
            {
                lastnode = null;
            }
            else
            {
                lastnode = tv.Nodes[0];
            }
        }

        protected override bool IncreasePosition()
        {
            if (lastnode == null || lastnode.TreeView == null)
            {
                if (tv.Nodes.Count == 0)
                {
                    return false;
                }
                lastnode = tv.Nodes[0];
                return true;
            }
            lastnode = GetNextNode(lastnode, false);
            return lastnode != null;
        }

        protected override void SetFoundPosition()
        {
            tv.SelectedNode = lastnode;
        }

        protected override object GetPosition()
        {
            return lastnode;
        }

        TreeNode GetNextNode(TreeNode n, bool SkipChildren)
        {
            if (n == null)
            {
                return null;
            }
            if (!SkipChildren && n.Nodes.Count > 0)
            {
                return n.Nodes[0];
            }

            if (n.NextNode != null)
            {
                return n.NextNode;
            }
            return GetNextNode(n.Parent, true);
        }

        protected override bool CheckIsReady()
        {
            return base.CheckIsReady() && tv != null;
        }

        protected override object GetCurrent()
        {
            if (lastnode == null)
            {
                return null;
            }
            return lastnode.Text;
        }

        protected override void filter(StringSearchMatcher search)
        {
            throw new NotImplementedException();
        }

        protected override bool Supports(SearchBoxMode Mode)
        {
            return base.Supports(Mode) && Mode != SearchBoxMode.Filter;
        }

        private TreeView tv;

        [DefaultValue(null)]
        public TreeView TreeView
        {
            get { return tv; }
            set
            {
                if (tv == value)
                {
                    return;
                }
                if (tv != null)
                {
                    tv.AfterSelect -= new TreeViewEventHandler(tv_AfterSelect);
                    UnRegisterControl(tv);
                }
                tv = value;
                if (tv != null)
                {
                    tv.AfterSelect += new TreeViewEventHandler(tv_AfterSelect);
                    RegisterControl(tv);
                }
                NotifyStateChanged(true);
            }
        }

        protected override void OnDisposed()
        {
            TreeView = null;
        }

        void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (IsBusy)
            {
                return;
            }
            ResetStartPosition(null);
            Text = null;
        }
    }

    /*
    public class TextBoxSearchBox : SearchBoxBase
    {
        private TextBoxBase tb;

        [DefaultValue(null)]
        public TextBoxBase TextBox
        {
            get { return tb; }
            set
            {
                if (tb == value)
                {
                    return;
                }
                if (tb != null)
                {
                    tb.TextChanged -= new EventHandler(tb_TextChanged);
                }
                tb = value;
                if (tb != null)
                {
                    tb.TextChanged += new EventHandler(tb_TextChanged);
                }
                NotifyStateChanged(true);
            }
        }

        void tb_TextChanged(object sender, EventArgs e)
        {
        }

        int pos;

        protected override void ResetStartPosition(object storedpos)
        {
            pos = 0;
        }

        protected override bool IncreasePosition()
        {
            return ++pos < tb.TextLength - Text.Length;
        }

        protected override bool Supports(SearchMode Mode)
        {
            return Mode != SearchMode.Filter && base.Supports(Mode);
        }

        protected override bool CheckIsReady()
        {
            return tb!=null && base.CheckIsReady();
        }

        protected override void SetFoundPosition()
        {
            tb.SelectionStart = pos;
            tb.SelectionLength = Text.Length;
        }

        protected override object GetPosition()
        {
            return pos;
        }

        protected override bool search(StringSearchMatcher search)
        {
        }
   
        protected override object GetCurrent()
        {
            throw new NotImplementedException();
        }

        protected override void filter(StringSearchMatcher search)
        {
            throw new NotImplementedException();
        }
    }
    */

    public enum SearchBoxMode
    {
        Lookup,
        Lookup_Wildcards,
        Lookup_Regex,
        Filter,
    }

    public class StringSearchMatcher
    {

        Func<string, bool> fn;

        public StringSearchMatcher()
        {
        }

        public StringSearchMatcher(SearchBoxMode Mode)
        {
            this.Mode = Mode;
        }

        public StringSearchMatcher(SearchBoxMode Mode, string SearchValue) : this(Mode)
        {
            this.SearchText = SearchValue;
        }

        private SearchBoxMode mode = SearchBoxMode.Lookup_Wildcards;

        public SearchBoxMode Mode
        {
            get { return mode; }
            set
            {
                if (mode == value)
                {
                    return;
                }
                mode = value;
                rx = null;
                fn = null;
            }
        }

        bool searchinner;

        public bool AlwaysSearchInnerText
        {
            get { return searchinner; }
            set
            {
                if (searchinner == value)
                {
                    return;
                }
                searchinner = value;
                rx = null;
                fn = null;
            }
        }

        private string txt;

        public string SearchText
        {
            get { return txt; }
            set
            {
                txt = value;
                rx = null;
                len = txt == null ? 0 : txt.Length;
                if (mode == SearchBoxMode.Lookup_Wildcards)
                {
                    // Принудительный набор для перепроверки, если требуется регулярное выражение.
                    fn = WildCardSearch;
                }
            }
        }

        public override string ToString()
        {
            return Mode + " for " + txt;
        }

        int len;

        public int TextLength
        {
            get { return len; }
        }

        public bool Matches(string s)
        {
            if (fn == null)
            {
                setSearchMatcher();
            }
            return fn(s);
        }

        public bool Matches(object o)
        {
            if (o == null)
            {
                return txt == null;
            }
            return Matches(o.ToString());
        }

        public Func<string, bool> SearchDelegate
        {
            get
            {
                if (fn == null)
                {
                    setSearchMatcher();
                }
                return fn;
            }
        }

        void setSearchMatcher()
        {
            if (mode == SearchBoxMode.Lookup)
            {
                if (searchinner)
                {
                    fn = ContainsSearch;
                }
                else
                {
                    fn = StartSearch;
                }
            }
            else if (mode == SearchBoxMode.Lookup_Wildcards)
            {
                fn = WildCardSearch;
            }
            else
            {
                fn = RegExSearch;
            }
        }

        bool ContainsSearch(string s)
        {
            return s.IndexOf(txt, StringComparison.OrdinalIgnoreCase) != -1;
        }

        bool StartSearch(string s)
        {
            return s.StartsWith(txt, StringComparison.OrdinalIgnoreCase);
        }

        Regex rx;

        bool WildCardSearch(string s)
        {
            if (rx == null)
            {
                var text = txt;
                if (searchinner || text.Contains('*') || text.Contains('?'))
                {
                    var pattern = (searchinner ? null : "^") + Regex.Escape(text).Replace(@"\?", ".").Replace(@"\*", ".*");
                    rx = new Regex(pattern, RegexOptions.IgnoreCase);
                }
                else
                {
                    fn = StartSearch;
                    return StartSearch(s);
                }
            }
            return rx.IsMatch(s ?? string.Empty);
        }

        bool RegExSearch(string s)
        {
            if (rx == null)
            {
                if (searchinner)
                {
                    rx = new Regex(txt, RegexOptions.IgnoreCase);
                }
                else
                {
                    rx = new Regex("^" + txt, RegexOptions.IgnoreCase);
                }
            }
            return rx.IsMatch(s);
        }
    }

    public class ToolstripSearchBox<CT> : ToolStripControlHost, ISupportInitialize where CT : SearchBoxBase, new()
    {
        public ToolstripSearchBox() : base(new CT())
        {
            SearchBoxControl.MinimumSize = new Size(150, 20);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CT SearchBoxControl
        {
            get { return (CT)Control; }
        }

        public override string Text
        {
            get { return SearchBoxControl.Text; }
            set { SearchBoxControl.Text = value; }
        }

        [DefaultValue(SearchBoxMode.Lookup_Wildcards)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SearchBoxMode Mode
        {
            get { return SearchBoxControl.Mode; }
            set { SearchBoxControl.Mode = value; }
        }

        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AlwaysSearchInnerText
        {
            get { return SearchBoxControl.AlwaysSearchInnerText; }
            set { SearchBoxControl.AlwaysSearchInnerText = value; }
        }

        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowOptionsButtons
        {
            get { return SearchBoxControl.ShowOptionsButton; }
            set { SearchBoxControl.ShowOptionsButton = value; }
        }

        public void BeginInit()
        {
            SearchBoxControl.BeginInit();
        }

        public void EndInit()
        {
            SearchBoxControl.EndInit();
        }
    }

    public class ToolStripSourceSearchBox<CT> : ToolstripSearchBox<CT> where CT : SourceSearchBox, new()
    {
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PropertyName
        {
            get { return SearchBoxControl.PropertyName; }
            set { SearchBoxControl.PropertyName = value; }
        }

        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SourceSearchBox.Column SearchProperty
        {
            get { return SearchBoxControl.SearchProperty; }
            set { SearchBoxControl.SearchProperty = value; }
        }
    }

    // Инкапсулирует BindingSourceSearchBox в ToolStripItem.
    public class ToolstripBindingSourceSearchBox : ToolStripSourceSearchBox<BindingSourceSearchBox>
    {
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CurrencyManager CurrencyManager
        {
            get { return SearchBoxControl.BindingSource; }
            set { SearchBoxControl.BindingSource = value; }
        }
    }

    public class ToolstripDataGridSearchBox : ToolStripSourceSearchBox<DataGridSearchBox>
    {
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridView DataGridView
        {
            get { return SearchBoxControl.DataGridView; }
            set { SearchBoxControl.DataGridView = value; }
        }

        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridSearchBox.ColumnSearchMode SearchModeColumn
        {
            get { return SearchBoxControl.SearchModeColumn; }
            set { SearchBoxControl.SearchModeColumn = value; }
        }
    }

    public class ContextMenuStripButton : Control
    {
        bool down;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!down)
            {
                down = true;
                ContextMenuStrip cm = this.ContextMenuStrip;
                if (cm != null)
                {
                    cm.Show(this, new Point(Width, Height), ToolStripDropDownDirection.BelowLeft);
                    cm.Closed += new ToolStripDropDownClosedEventHandler(cm_Closed);
                }
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            down = false;
            Invalidate();
        }

        protected override Size DefaultSize
        {
            get { return new Size(10, 24); }
        }

        void cm_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            ((ContextMenuStrip)sender).Closed -= cm_Closed;
            down = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            try
            {
                Rectangle r = e.ClipRectangle;
                if (r.IsEmpty)
                {
                    return;
                }
                ControlPaint.DrawButton(e.Graphics, r, down ? ButtonState.Pushed : ButtonState.Normal);

                if (down)
                {
                    r.Offset(1, 1);
                }
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Point p = new Point(r.X + 2, r.Y + r.Height / 2 - 2);
                for (int i = 0; i < 2; i++)
                {
                    int w = r.Right - p.X - 4;
                    Point[] ps = { p, new Point(p.X + w / 2, p.Y + 2), new Point(p.X + w, p.Y) };
                    e.Graphics.DrawLines(Pens.Black, ps);
                    p.Y += 3;
                }
            }
            catch { }
        }
    }

    #endregion

    [ContextClass("КлГруппировкаТаблицы", "ClDataGridViewGrouper")]
    public class ClDataGridViewGrouper : AutoContext<ClDataGridViewGrouper>
    {

        public ClDataGridViewGrouper()
        {
            DataGridViewGrouper DataGridViewGrouper1 = new DataGridViewGrouper();
            DataGridViewGrouper1.dll_obj = this;
            Base_obj = DataGridViewGrouper1;
        }
		
        public ClDataGridViewGrouper(osf.ClDataGridView p1)
        {
            DataGridViewGrouper DataGridViewGrouper1 = new DataGridViewGrouper(p1.Base_obj.M_DataGridView);
            DataGridViewGrouper1.dll_obj = this;
            Base_obj = DataGridViewGrouper1;
        }

        public ClDataGridViewGrouper(DataGridViewGrouper p1)
        {
            DataGridViewGrouper DataGridViewGrouper1 = p1;
            DataGridViewGrouper1.dll_obj = this;
            Base_obj = DataGridViewGrouper1;
        }

        public DataGridViewGrouper Base_obj;

        //Свойства============================================================
        [ContextProperty("ВсегдаГруппироватьКакТекст", "AlwaysGroupOnText")]
        public bool AlwaysGroupOnText
        {
            get { return Base_obj.Options.AlwaysGroupOnText; }
            set { Base_obj.Options.AlwaysGroupOnText = value; }
        }
        
        [ContextProperty("ВыделятьСтрокиПриДвойномНажатии", "SelectRowsOnDoubleClick")]
        public bool SelectRowsOnDoubleClick
        {
            get { return Base_obj.Options.SelectRowsOnDoubleClick; }
            set { Base_obj.Options.SelectRowsOnDoubleClick = value; }
        }
        
        [ContextProperty("ГруппироватьКакТекст", "ForceAsText")]
        public bool ForceAsText
        {
            get { return Base_obj.ForceAsText; }
            set { Base_obj.ForceAsText = value; }
        }
        
        [ContextProperty("ИмяГруппы", "GroupName")]
        public IValue GroupName
        {
            get
            {
                try
                {
                    return ValueFactory.Create(Base_obj.GroupOn.ToString());
                }
                catch
                {
                    return null;
                }
            }
        }
        
        [ContextProperty("ПоказатьИмяГруппы", "ShowGroupName")]
        public bool ShowGroupName
        {
            get { return Base_obj.Options.ShowGroupName; }
            set { Base_obj.Options.ShowGroupName = value; }
        }
        
        [ContextProperty("ПоказатьКоличество", "ShowCount")]
        public bool ShowCount
        {
            get { return Base_obj.Options.ShowCount; }
            set { Base_obj.Options.ShowCount = value; }
        }
        
        [ContextProperty("ПорядокСортировки", "GroupSortOrder")]
        public int GroupSortOrder
        {
            get { return (int)Base_obj.GroupSortOrder; }
            set { Base_obj.GroupSortOrder = (System.Windows.Forms.SortOrder)value; }
        }
        
        [ContextProperty("СвернутоПриСтарте", "StartCollapsed")]
        public bool StartCollapsed
        {
            get { return Base_obj.Options.StartCollapsed; }
            set { Base_obj.Options.StartCollapsed = value; }
        }
        
        [ContextProperty("СтильГруппировкиТаблицы", "DataGridViewGrouperStyle")]
        public int DataGridViewGrouperStyle
        {
            get { return Base_obj.DataGridViewGrouperStyle; }
            set { Base_obj.DataGridViewGrouperStyle = value; }
        }
        
        [ContextProperty("Таблица", "DataGridView")]
        public osf.ClDataGridView DataGridView
        {
            get { return ((osf.DataGridViewEx)Base_obj.DataGridView).M_Object.dll_obj; }
        }
        
        //Методы============================================================
        [ContextMethod("РазвернутьВсе", "ExpandAll")]
        public void ExpandAll()
        {
            Base_obj.ExpandAll();
        }
					
        [ContextMethod("СвернутьВсе", "CollapseAll")]
        public void CollapseAll()
        {
            Base_obj.CollapseAll();
        }
					
        [ContextMethod("УдалитьГруппировку", "RemoveGroup")]
        public void RemoveGroup()
        {
            Base_obj.RemoveGrouping();
        }
        
        [ContextMethod("УстановитьГруппировку", "SetGroup")]
        public bool SetGroup(IValue p1)
        {
            if (p1.SystemType.Name == "Строка")
            {
                return Base_obj.SetGroupOn(p1.AsString());
            }
            else
            {
                string strType = p1.AsObject().GetType().ToString();
                if (strType.Contains("DataGridViewColumn") ||
                    strType.Contains("DataGridViewImageColumn") ||
                    strType.Contains("DataGridViewButtonColumn") ||
                    strType.Contains("DataGridViewTextBoxColumn") ||
                    strType.Contains("DataGridViewComboBoxColumn") ||
                    strType.Contains("DataGridViewLinkColumn") ||
                    strType.Contains("DataGridViewCheckBoxColumn"))
                {
                    return Base_obj.SetGroupOn(((dynamic)p1.AsObject()).Base_obj.M_DataGridViewColumn);
                }
            }
            return false;
        }
    }
}
