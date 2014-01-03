using System;
using System.Diagnostics;
using TimeZero.Auction.Bot.Classes.MemoryEditor;

namespace TimeZero.Auction.Bot.Classes.TZProcess
{
    internal static class TZProcessPatch
    {

#region Constants

        private const string KW_EXTERNAL_GET_MASSA = "externalGetMassa";

        private const string KW_ADD = "add";
        private const string KW_DCT = "dct";

        private static readonly byte[] KD_SHOW_ATTACK_CLAIM =
            new byte[]
                {
                    0x96, 0x0f, 0x00, 0x04, 0x04, 0x04, 0x03, 0x04, 0x02, 0x07, 
                    0x03, 0x00, 0x00, 0x00, 0x04, 0x01, 0x08, 0x13, 0x52, 0x17
                };
        private static readonly byte[] KD_DCT =
            new byte[]
                {
                    0x96, 0x0f, 0x00, 0x04, 0x04, 0x04, 0x03, 0x04, 0x02, 0x07, 
                    0x03, 0x00, 0x00, 0x00, 0x04, 0x01, 0x08, 0x1D, 0x52, 0x3E
                };

#endregion

#region Class methods

        private static void AssertNull(ScanResult scanResult)
        {
            if (scanResult == null)
            {
                throw new Exception();
            }
        }

        private static void AssertPatchMemoryResult(uint patchResult, uint expectedResult)
        {
            if (patchResult != expectedResult)
            {
                throw new Exception();
            }
        }

        private static void ScanAndPatch(ProcessMemoryScanner scanner, ScanResult scanResult)
        {
            try
            {
                AssertNull(scanResult);

                //Find KW_ADD keyword
                ScanResult patchScanResult = scanResult.ScanNext(KW_ADD);
                AssertNull(patchScanResult);

                //Change keyword KW_ADD value onto KW_DCT value
                uint patchResult = scanner.PatchMemory(patchScanResult, KW_DCT);
                AssertPatchMemoryResult(patchResult, (uint) KW_DCT.Length);

                //Looking for 'showAttackClaim' method call
                patchScanResult = scanResult.ScanNext(KD_SHOW_ATTACK_CLAIM);
                AssertNull(patchScanResult);

                //Call 'dct' method instead 'showAttackClaim' and change current procedure to method
                patchResult = scanner.PatchMemory(patchScanResult, KD_DCT);
                AssertPatchMemoryResult(patchResult, (uint) KD_DCT.Length);
            } catch {}
        }

        public static void PatchCurrentProcess()
        {
            Process process = Process.GetCurrentProcess();
            using (ProcessMemoryScanner scanner = new ProcessMemoryScanner(process))
            {
                ScanResult scanResult = scanner.Scan(103000000, KW_EXTERNAL_GET_MASSA);
                ScanAndPatch(scanner, scanResult.ScanNext());
            }
        }

#endregion

    }
}
