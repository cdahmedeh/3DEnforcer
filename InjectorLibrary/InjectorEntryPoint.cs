using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InjectorLibrary;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels.Ipc;

namespace InjectorLibrary
{
    public class InjectorEntryPoint: EasyHook.IEntryPoint
    {
        D3D9Hook Hook = null;
        private InjectorInterface Interface;
		
        public InjectorEntryPoint(EasyHook.RemoteHooking.IContext context, String channelName)
        {
            Interface = EasyHook.RemoteHooking.IpcConnectClient<InjectorInterface>(channelName);
            Interface.Ping();
        }

        public void Run(EasyHook.RemoteHooking.IContext context, String channelName)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += (sender, args) =>
            {
                return this.GetType().Assembly.FullName == args.Name ? this.GetType().Assembly : null;
            };

            InitialiseDirectXHook();
        }

        private void InitialiseDirectXHook()
        {
            IntPtr d3D9Loaded = IntPtr.Zero;

            int delayTime = 100;
            int retryCount = 0;
            while (d3D9Loaded == IntPtr.Zero)
            {
                retryCount++;
                d3D9Loaded = InjectorNatives.GetModuleHandle("d3d9.dll");
                System.Threading.Thread.Sleep(delayTime);

                if (retryCount * delayTime > 5000)
                {
					return;
                }
            }

            if (d3D9Loaded != IntPtr.Zero)
            {
                Hook = new D3D9Hook();
            	Hook.Hook();
            }
        }
    }
}
