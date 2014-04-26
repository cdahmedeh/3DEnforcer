using System;
using System.Linq;
using EasyHook;
using System.Runtime.Remoting;
using InjectorLibrary;
using System.Diagnostics;

namespace InjectorLibrary
{
    public class InjectorProcess
    {
		public InjectorProcess(Process process, InjectorInterface captureInterface)
        {
	    	string ChannelName = null;
			
			RemoteHooking.IpcCreateServer<InjectorInterface>(
                ref ChannelName,
                WellKnownObjectMode.Singleton,
                captureInterface);

            RemoteHooking.Inject(
                process.Id,
                InjectionOptions.Default,
                typeof(InjectorInterface).Assembly.Location,
                typeof(InjectorInterface).Assembly.Location,
                ChannelName
            );
        }
    }
}
