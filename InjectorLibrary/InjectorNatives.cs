using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace InjectorLibrary
{
    [System.Security.SuppressUnmanagedCodeSecurity()]
    internal sealed class InjectorNatives
    {
        private InjectorNatives() {}
		
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
