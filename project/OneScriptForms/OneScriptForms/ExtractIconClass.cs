using System;
using System.Runtime.InteropServices;

namespace osf
{
    class ExtractIconClass
    {
        [DllImport("Kernel32.dll")] public static extern int GetModuleHandle(string lpModuleName);
        [DllImport("Shell32.dll")] public static extern IntPtr ExtractIcon(int hInst, string FileName, int nIconIndex);
        [DllImport("Shell32.dll")] public static extern int DestroyIcon(IntPtr hIcon);
        [DllImport("Shell32.dll")] public static extern IntPtr ExtractIconEx(string FileName, int nIconIndex, int[] lgIcon, int[] smIcon, int nIcons);
        [DllImport("Shell32.dll")] private static extern int SHGetFileInfo(string pszPath, uint dwFileAttributes, out SHFILEINFO psfi, uint cbfileInfo, SHGFI uFlags);
        [StructLayout(LayoutKind.Sequential)]

        private struct SHFILEINFO
        {
            public SHFILEINFO(bool b)
            {
                hIcon = IntPtr.Zero;
                iIcon = 0;
                dwAttributes = 0;
                szDisplayName = "";
                szTypeName = "";
            }
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.LPStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.LPStr, SizeConst = 80)]
            public string szTypeName;
        };

        private enum SHGFI
        {
            SmallIcon = 0x00000001,
            LargeIcon = 0x00000000,
            Icon = 0x00000100,
            DisplayName = 0x00000200,
            Typename = 0x00000400,
            SysIconIndex = 0x00004000,
            UseFileAttributes = 0x00000010
        }

        public static System.Drawing.Icon GetIcon(string strPath, bool bSmall)
        {
            SHFILEINFO info = new SHFILEINFO(true);
            int cbFileInfo = Marshal.SizeOf(info);
            SHGFI flags;
            if (bSmall)
                flags = SHGFI.Icon | SHGFI.SmallIcon | SHGFI.UseFileAttributes;
            else
                flags = SHGFI.Icon | SHGFI.LargeIcon | SHGFI.UseFileAttributes;

            SHGetFileInfo(strPath, 256, out info, (uint)cbFileInfo, flags);
            
            return System.Drawing.Icon.FromHandle(info.hIcon);
        }        

        public static System.Drawing.Icon GetSysIcon(int icNo)
        {
            IntPtr HIcon = ExtractIcon(GetModuleHandle(string.Empty), "DDORes.dll"/*"Shell32.dll"*/, icNo);            
            return System.Drawing.Icon.FromHandle(HIcon);
        }
        public static System.Drawing.Icon GetSysIconFromDll(int icNo, string dll)
        {
            IntPtr HIcon = ExtractIcon(GetModuleHandle(string.Empty), dll + ".dll", icNo);
            return System.Drawing.Icon.FromHandle(HIcon);
        }
        public static System.Drawing.Icon GetIconFromExeDll(int icNo, string dll)
        {
            IntPtr HIcon = ExtractIcon(GetModuleHandle(string.Empty), dll, icNo);

            return System.Drawing.Icon.FromHandle(HIcon);
        }
    }
}
