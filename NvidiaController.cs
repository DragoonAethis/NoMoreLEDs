using System;
using System.Runtime.InteropServices;

/* Notes:

Most of this was ripped from the MSI Gaming App and analyzing calls to
the NDA.dll. If you call something along the lines of "SetGPUClock" or
"SetPowerCap" and break your pricey GPU - not my, nor MSI's fault.

NDA_GetGraphicsInfo unfortunately seems to be broken beyond sanity w/o
proper headers. Not required for disabling LEDs, so I won't try to fix
this. You're welcome to try (decompiled struct in NvidiaGPU.cs).

---

Start with Initialize(), do your work, finish with Unload(). Changes are
saved on Unload() until reboot/overridden with other app. "Your work" is
something along the lines of long gpus, GetGPUCounts(out gpus), then:
for (int i = 0; i < gpus; i++) {
    // Calls to NDA_...(), with i as iAdapterIndex.
}

---

NDA_SetIlluminationParm(gpuIndex, 0, 0) disables non-RGB LEDs, but not RGB ones. So:
NDA_SetIlluminationParmColor_RGB(gpuIndex, 24, 7, 0, 0, 0, 4, 0, 0, 32, 32, 32, false)
disables RGB LEDs (all at once), but not non-RGB LEDs.

Under Linux, nvidia-settings (as of 370.28) cannot manipulate RGB LEDs. :( */

namespace NoMoreLEDs {
    /// <summary>
    /// NDA.dll wrapper used to control Nvidia-based MSI GPUs. Read the
    /// notes before using this library.
    /// </summary>
    class NvidiaController {
        public const string NDA_DLL_FileName = "NDA.dll";

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_Initialize();

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_Unload();

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_GetGPUCounts(out long GpuCounts);

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_GetGraphicsInfo(int iAdapterIndex, out NvidiaGPU graphicsInfo);

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_SetFanSpeedPercent(int iAdapterIndex, int FanSpeedPercent);

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_SetFanSpeedPercentForI2C(int iAdapterIndex, byte i2cDeviceAddr, byte RegAddr, int FanSpeedPercent);

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_SetGPUClock(int iAdapterIndex, int GPUClock);

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_SetGPUClock_2(int iAdapterIndex, int GPUClock, int Memory);

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_SetGPUClock_Destroy(int iAdapterIndex, int GPUClock);

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_Get_G_Sync(out bool G_Sync_State);

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_Set_G_Sync(bool G_Sync_State);

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_GetGPUClock(int iAdapterIndex, out int GPUClock);

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_SetMemoryClock(int iAdapterIndex, int GPUClock);

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_SetMemoryClock_2(int iAdapterIndex, int GPUClock);

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_SetPowerCap(int iAdapterIndex, float power);

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_SetDefaultFanSpeed();

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_QueryIlluminationSupport(int iAdapterIndex, int Attribute);

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_SetIlluminationParm(int iAdapterIndex, int Attribute, int Value);

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_SetIlluminationParmColor_RGB(int iAdapterIndex, int cmd, int led1, int led2, int ontime, int offtime, int time, int darktime, int bright, int r, int g, int b, bool One = false);

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_SetIlluminationParmColor_Music(int iAdapterIndex, int led, int bright, int r, int g, int b);

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_GetIlluminationParm(int iAdapterIndex, int Attribute, out int Value);

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_SetGPUVoltage(int iAdapterIndex, int Voltage);

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_GetFanSpeed(int iAdapterIndex, out int Value);

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_GetVoltage(int iAdapterIndex, out int Value);

        [DllImport("NDA.dll", CharSet = CharSet.Unicode)]
        public static extern bool NDA_GetVoltage_2(int iAdapterIndex, out int Value);
    }
}
