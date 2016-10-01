﻿using System;
using System.Runtime.InteropServices;

namespace NoMoreLEDs {
    /// <summary>
    /// A struct used to hold information fetched from NDA_GetGraphicsInfo.
    /// Appears to be missing something, as any call to that function causes
    /// a memory access violation (and a crash) in mscorlib, while it does
    /// work with MSI Gaming App. All fields are self-descriptive.
    /// </summary>
    class NvidiaGPU {
        internal int iAdapterIndex;
        internal bool IsPrimaryDisplay;

        [MarshalAs(UnmanagedType.BStr)]
        internal string DisplayName;

        [MarshalAs(UnmanagedType.BStr)]
        internal string Card_PNP;
        [MarshalAs(UnmanagedType.BStr)]
        internal string Card_pDeviceId;
        [MarshalAs(UnmanagedType.BStr)]
        internal string Card_pSubSystemId;
        [MarshalAs(UnmanagedType.BStr)]
        internal string Card_pRevisionId;
        [MarshalAs(UnmanagedType.BStr)]
        internal string Card_FullName;

        [MarshalAs(UnmanagedType.BStr)]
        internal string Card_BIOS_Date;
        [MarshalAs(UnmanagedType.BStr)]
        internal string Card_BIOS_PartNumber;
        [MarshalAs(UnmanagedType.BStr)]
        internal string Card_BIOS_Version;

        internal int GPU_Usage;
        internal int GPU_Clock_Current;
        internal int GPU_Clock_Base;
        internal int GPU_Clock_Set;
        internal int GPU_Clock_Max;
        internal int GPU_Clock_Min;

        internal int VRAM_Usage;
        internal int VRAM_Clock_Current;
        internal int VRAM_Clock_Base;
        internal int VRAM_Clock_Max;
        internal int VRAM_Clock_Min;

        internal int GPU_Temperature_Current;
        internal float GPU_Voltage_Current;
        internal int GPU_FanPercent_Current;

        internal int Memory_TotalSize;
    }
}
