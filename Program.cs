using System;

namespace NoMoreLEDs {
    class Program {
        static void Main(string[] args) {
            if (!NvidiaController.NDA_Initialize()) {
                Console.WriteLine("Failed to initialize the NDA library. Are you sure a supported MSI GPU is present?");
                return;
            } else Console.WriteLine("Initialized NDA...");

            long gpus = 0;
            NvidiaController.NDA_GetGPUCounts(out gpus);

            if (gpus <= 0) {
                Console.WriteLine("Found no supported GPUs, bailing out.");
                return;
            } else Console.WriteLine("Found {0} GPUs...", gpus);
            
            for (long gpuIndex = 0; gpuIndex < gpus; gpuIndex++) {
                Console.WriteLine("Disabling LEDs for GPU {0}...", gpuIndex);
                if (!NvidiaController.NDA_SetIlluminationParm((int) gpuIndex, 0, 0)) Console.WriteLine("Call 1 failed...");
                if (!NvidiaController.NDA_SetIlluminationParmColor_RGB((int) gpuIndex, 24, 7, 0, 0, 0, 4, 0, 0, 32, 32, 32, false)) Console.WriteLine("Call 2 failed...");
            }

            NvidiaController.NDA_Unload();
            Console.WriteLine("All done!");
        }
    }
}
