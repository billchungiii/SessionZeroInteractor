using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace SessionZeroInteractive
{
    public static class Interactor
    {
        [DllImport("kernel32")]
        private static extern bool CloseHandle(IntPtr intPtr);


        [DllImport("advapi32")]
        private static extern bool OpenProcessToken(IntPtr ProcessHandle, UInt32 DesiredAccess, ref IntPtr TokenHandle);


        [DllImport("advapi32.dll", EntryPoint = "CreateProcessAsUser", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern bool CreateProcessAsUser(IntPtr hToken, string lpApplicationName, string lpCommandLine, ref SECURITY_ATTRIBUTES lpProcessAttributes, ref SECURITY_ATTRIBUTES lpThreadAttributes, bool bInheritHandle, Int32 dwCreationFlags, IntPtr byvallpEnvrionment, string lpCurrentDirectory, ref STARTUPINFO lpStartupInfo, ref PROCESS_INFORMATION lpProcessInformation);

        private static bool GetProcessToken(ref IntPtr pToken)
        {
            IntPtr pHandle;
            Process[] processes;
            bool returnValue = false;
            processes = Process.GetProcessesByName("explorer");
            try
            {
                if (processes != null)
                {
                    pHandle = processes[0].Handle;
                    if (OpenProcessToken(pHandle, Constants.TOKEN_ALL_ACCESS, ref pToken) == true)
                        returnValue = true;
                }
                return returnValue;
            }
            catch (Exception)
            {
                return returnValue;
            }
        }


        public static bool Start(string fileName)
        {

            return Start(fileName, string.Empty);

        }

        public static bool Start(string fileName, string arguments)
        {
            if (arguments == null)
            {
                arguments = string.Empty; 
            }
            IntPtr pToken = IntPtr.Zero;
            try
            {
                if (!GetProcessToken(ref pToken))
                {
                    return false;
                }

                PROCESS_INFORMATION processInformation = new PROCESS_INFORMATION();
                SECURITY_ATTRIBUTES securityAttributes = new SECURITY_ATTRIBUTES();
                STARTUPINFO startupInformation = new STARTUPINFO();
                securityAttributes.length = Marshal.SizeOf(securityAttributes);
                startupInformation.cb = Marshal.SizeOf(startupInformation);
                startupInformation.lpDesktop = string.Empty;
                return CreateProcessAsUser(pToken, null, $"{fileName} {arguments}", ref securityAttributes, ref securityAttributes, false, 0x20, IntPtr.Zero, null, ref startupInformation, ref processInformation);

            }
            finally
            {
                CloseHandle(pToken);
            }
        }
      
    }
}
