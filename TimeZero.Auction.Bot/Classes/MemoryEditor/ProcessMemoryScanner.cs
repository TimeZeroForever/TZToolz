using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace TimeZero.Auction.Bot.Classes.MemoryEditor
{
    internal unsafe class ProcessMemoryScanner : IDisposable
    {

#region P/Invoke

        [DllImport("msvcrt.dll")]
        private static extern int memcmp(byte* b1, byte* b2, uint count);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int VirtualQueryEx(void* hProcess, void* lpAddress, void* lpBuffer, uint dwLength);

#endregion

#region Constants

        private const uint READ_STACK_SIZE = 20480;

#endregion

#region Private fields

        private readonly ProcessMemoryEditor _memoryEditor;

#endregion

#region Properties

        public Process Process { get; private set; }

#endregion

#region Class methods

        public ProcessMemoryScanner(Process process)
        {
            if (process == null)
            {
                throw new Exception("Process pointer is null-reference");
            }
            Process = process;
            _memoryEditor = new ProcessMemoryEditor(process);
        }

        private void AssertDataObject(object obj)
        {
            if (obj == null)
            {
                throw new Exception("Data object is null-reference");
            }
            SysType type = SysTypes.TypeOf(obj);
            if (type == SysType.Unknown)
            {
                throw new Exception(string.Format("Unsupported data object type: {0}", obj.GetType()));
            }
        }

        private void AssertScanResult(ScanResult result)
        {
            if (result == null)
            {
                throw new Exception("Scan result is null-reference");
            }
        }
        
        private ScanResult Scan(uint currentAddress, uint endAddress, byte[] data, uint dataLength)
        {
            uint bytesToRead = Math.Min(READ_STACK_SIZE, endAddress - currentAddress);
            while (currentAddress < endAddress && bytesToRead >= 0)
            {
                MEMORY_BASIC_INFORMATION memoryInfo = GetMemoryInformation(currentAddress);
                uint bytesRead;
                byte[] result = _memoryEditor.ReadProcessMemory(currentAddress, bytesToRead, out bytesRead);
                if (bytesRead == bytesToRead)
                {
                    bytesRead -= dataLength;
                    for (uint i = 0; i < bytesRead; i++)
                    {
                        if (IsBuffersEquals(result, i, data, 0, dataLength))
                        {
                            return new ScanResult(this, currentAddress + i, endAddress, data, dataLength);
                        }
                    }
                    currentAddress += READ_STACK_SIZE - dataLength;
                }
                else
                {
                    currentAddress += memoryInfo.RegionSize;
                }
                bytesToRead = Math.Min(READ_STACK_SIZE, endAddress - currentAddress);
            }
            return null;
        }

        public ScanResult Scan(object obj)
        {
            uint processWorkingMemorySize = (uint)Process.VirtualMemorySize64;
            return Scan(0, processWorkingMemorySize, obj);
        }

        public ScanResult Scan(uint startAddress, object obj)
        {
            uint processWorkingMemorySize = (uint)Process.VirtualMemorySize64;
            return Scan(startAddress, processWorkingMemorySize, obj);
        }

        public ScanResult Scan(uint startAddress, uint endAddress, object obj)
        {
            AssertDataObject(obj);
            byte[] data = ObjectToByteArray(obj);
            uint dataLength = (uint) data.Length;
            return Scan(startAddress, endAddress, data, dataLength);
        }

        public ScanResult ScanNext(ScanResult result)
        {
            return result != null
                       ? Scan(result.CurrentAddress + result.DataLength,
                              result.EndAddress,
                              result.Data,
                              result.DataLength)
                       : null;
        }

        public ScanResult ScanNext(ScanResult result, object obj)
        {
            return result != null
                       ? Scan(result.CurrentAddress + result.DataLength,
                              result.EndAddress,
                              obj)
                       : null;
        }

        private uint PatchMemory(uint address, byte[] data, uint dataLength)
        {
            uint bytesWritten;
            _memoryEditor.WriteProcessMemory(address, data, dataLength, out bytesWritten);
            return bytesWritten;
        }

        public uint PatchMemory(ScanResult result, object obj)
        {
            AssertScanResult(result);
            return PatchMemory(result.CurrentAddress, obj);
        }

        public uint PatchMemory(ScanResult result, object obj, uint length)
        {
            AssertScanResult(result);
            return PatchMemory(result.CurrentAddress, obj, length);
        }

        public uint PatchMemory(uint address, object obj)
        {
            AssertDataObject(obj);
            byte[] data = ObjectToByteArray(obj);
            uint length = (uint) data.Length;
            return PatchMemory(address, data, length);
        }

        public uint PatchMemory(uint address, object obj, uint length)
        {
            AssertDataObject(obj);
            byte[] data = ObjectToByteArray(obj);
            return PatchMemory(address, data, length);
        }

        public void Dispose()
        {
            _memoryEditor.CloseProcess();
        }

#endregion

#region Helpers

        private byte[] ObjectToByteArray(object obj)
        {
            SysType type = SysTypes.TypeOf(obj);
            if (type != SysType.Unknown)
            {
                switch (type)
                {
                    case SysType.Byte:
                    case SysType.SByte:
                        return new[] { (byte)obj };
                    case SysType.Char:
                        return BitConverter.GetBytes((char)obj);
                    case SysType.Short:
                        return BitConverter.GetBytes((short)obj);
                    case SysType.UShort:
                        return BitConverter.GetBytes((ushort)obj);
                    case SysType.Int:
                        return BitConverter.GetBytes((int)obj);
                    case SysType.UInt:
                        return BitConverter.GetBytes((uint)obj);
                    case SysType.Long:
                        return BitConverter.GetBytes((long)obj);
                    case SysType.ULong:
                        return BitConverter.GetBytes((ulong)obj);
                    case SysType.Float:
                        return BitConverter.GetBytes((float)obj);
                    case SysType.Double:
                        return BitConverter.GetBytes((double)obj);
                    case SysType.String:
                        return Encoding.ASCII.GetBytes((string)obj);
                    case SysType.ByteArray:
                        return (byte[])obj;
                }
            }
            return null;
        }

        private bool IsBuffersEquals(byte[] buffer1, uint offset1, 
                                     byte[] buffer2, uint offset2, 
                                     uint count)
        {
            fixed (byte* b1 = buffer1, b2 = buffer2)
            {
                return memcmp(b1 + offset1, b2 + offset2, count) == 0;
            }
        }

        private MEMORY_BASIC_INFORMATION GetMemoryInformation(uint address)
        {
            MEMORY_BASIC_INFORMATION memInfo;
            uint length = (uint)Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION));
            VirtualQueryEx(_memoryEditor.ProcessPtr, (void*) address, &memInfo, length);
            return memInfo;
        }

#endregion

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MEMORY_BASIC_INFORMATION
    {
        public IntPtr BaseAddress;
        public IntPtr AllocationBase;
        public uint AllocationProtect;
        public uint RegionSize;
        public uint State;
        public uint Protect;
        public uint Type;
    }
}
