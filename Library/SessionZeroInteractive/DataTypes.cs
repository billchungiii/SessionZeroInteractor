using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SessionZeroInteractive
{

    [StructLayout(LayoutKind.Sequential)]
    internal struct STARTUPINFO
    {
        public int cb;
        public string lpReserved;
        public string lpDesktop;
        public string lpTitle;
        public int dwX;
        public int dwY;
        public int dwXSize;
        public int dwXCountChars;
        public int dwYCountChars;
        public int dwFillAttribute;
        public int dwFlags;
        public short wShowWindow;
        public short cbReserved2;
        public IntPtr lpReserved2;
        public IntPtr hStdInput;
        public IntPtr hStdOutput;
        public IntPtr hStdError;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct PROCESS_INFORMATION
    {
        public IntPtr hProcess;
        public IntPtr hThread;
        public int dwProcessID;
        public int dwThreadID;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SECURITY_ATTRIBUTES
    {
        public int length;
        public IntPtr lpSecurityDescriptor;
        public bool bInheritHandle;
    }

    internal enum SECURITY_IMPERSONATION_LEVEL
    {
        SecurityAnonymous = 0,
        SecurityIdentification,
        SecurityImpersonation,
        SecurityDelegation
    }

    internal enum TOKEN_TYPE
    {
        TokenPrimary = 1,
        TokenImpersonation
    }
}
