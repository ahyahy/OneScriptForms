using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Reflection;
using System.Runtime.InteropServices;

namespace osf
{
    //class Class1
    /// A utility class to determine a process parent.
    /// </summary>
    //[StructLayout(LayoutKind.Sequential)]
    //[ContextClass("КлУтилиты", "ClUtilities")]
    //public class ClUtilities : AutoContext<ClUtilities>

    public class ParentProcessUtilities
    {
        //////    // Эти члены должны соответствовать PROCESS_BASIC_INFORMATION
        //////    internal IntPtr Reserved1;
        //////    internal IntPtr PebBaseAddress;
        //////    internal IntPtr Reserved2_0;
        //////    internal IntPtr Reserved2_1;
        //////    internal IntPtr UniqueProcessId;
        //////    internal IntPtr InheritedFromUniqueProcessId;

        //////    [DllImport("ntdll.dll")]
        //////    private static extern int NtQueryInformationProcess(IntPtr processHandle, int processInformationClass, ref ParentProcessUtilities processInformation, int processInformationLength, out int returnLength);

        //////    /// <summary>
        //////    /// Возвращает родительский процесс текущего процесса.
        //////    /// </summary>
        //////    /// <returns>Экземпляр класса Process.</returns>
        //////    public static Process GetParentProcess()
        //////    {
        //////        return GetParentProcess(System.Diagnostics.Process.GetCurrentProcess().Handle);
        //////    }

        //////    /// <summary>
        //////    /// Gets the parent process of specified process.
        //////    /// </summary>
        //////    /// <param name="id">The process id.</param>
        //////    /// <returns>An instance of the Process class.</returns>
        //////    public static Process GetParentProcess(int id)
        //////    {
        //////        Process process = Process.GetProcessById(id);
        //////        return GetParentProcess(process.Handle);
        //////    }

        //////    /// <summary>
        //////    /// Gets the parent process of a specified process.
        //////    /// </summary>
        //////    /// <param name="handle">The process handle.</param>
        //////    /// <returns>An instance of the Process class.</returns>
        //////    public static Process GetParentProcess(IntPtr handle)
        //////    {
        //////        ParentProcessUtilities pbi = new ParentProcessUtilities();
        //////        int returnLength;
        //////        int status = NtQueryInformationProcess(handle, 0, ref pbi, Marshal.SizeOf(pbi), out returnLength);
        //////        if (status != 0)
        //////            throw new Win32Exception(status);

        //////        try
        //////        {
        //////            return Process.GetProcessById(pbi.InheritedFromUniqueProcessId.ToInt32());
        //////        }
        //////        catch (ArgumentException)
        //////        {
        //////            // not found
        //////            return null;
        //////        }
        //////    }
    }
}
