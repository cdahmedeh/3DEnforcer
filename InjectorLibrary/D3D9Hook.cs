using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EasyHook;
using System.Runtime.InteropServices;
using SharpDX.Direct3D9;

namespace InjectorLibrary
{
    internal class D3D9Hook
    {
		LocalHook Direct3DDevice_BeginSceneHook = null;
		
        public void Hook()
        {
            Device device;
            List<IntPtr> id3dDeviceFunctionAddresses = new List<IntPtr>();
            using (Direct3D d3d = new Direct3D())
            {
                using (var renderForm = new System.Windows.Forms.Form())
                {
                    using (device = new Device(d3d, 0, DeviceType.NullReference, IntPtr.Zero, CreateFlags.HardwareVertexProcessing, new PresentParameters() { BackBufferWidth = 1, BackBufferHeight = 1, DeviceWindowHandle = renderForm.Handle }))
                    {
                        id3dDeviceFunctionAddresses.AddRange(InjectorUtils.GetVTblAddresses(device.NativePointer, Direct3D9Constants.D3D9_DEVICE_METHOD_COUNT));
                    }
                }
            }
        
            Direct3DDevice_BeginSceneHook = LocalHook.Create(
                id3dDeviceFunctionAddresses[(int)Direct3DDevice9FunctionOrdinals.BeginScene],
                new Direct3D9Device_BeginSceneDelegate(BeginSceneHook),
                this);
			
            Direct3DDevice_BeginSceneHook.ThreadACL.SetExclusiveACL(new Int32[]{0});
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        delegate int Direct3D9Device_BeginSceneDelegate(IntPtr device);

        int BeginSceneHook(IntPtr devicePtr)
        {
            Device device = (Device)devicePtr;

            for (int sampler = 0; sampler < 8; sampler++) {
	            device.SetSamplerState(sampler, SamplerState.MagFilter, TextureFilter.Anisotropic);
	            device.SetSamplerState(sampler, SamplerState.MinFilter, TextureFilter.Anisotropic);
	            device.SetSamplerState(sampler, SamplerState.MipFilter, TextureFilter.Anisotropic);
	            device.SetSamplerState(sampler, SamplerState.MaxAnisotropy, 16);		
            }
                        
			device.BeginScene();
			
            return SharpDX.Result.Ok.Code;
        }
    }
}
