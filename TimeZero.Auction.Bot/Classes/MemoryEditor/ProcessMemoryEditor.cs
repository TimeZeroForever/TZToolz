using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TimeZero.Auction.Bot.Classes.MemoryEditor
{
    internal unsafe class ProcessMemoryEditor
    {

#region P/Invoke

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void* OpenProcess(uint dwDesiredAccess, bool bInheritHandle, 
                                               uint dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle(void* hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int ReadProcessMemory(void* hProcess, void* lpBaseAddress, void* buffer,
                                                   uint size, uint* lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int WriteProcessMemory(void* hProcess, void* lpBaseAddress, void* buffer,
                                                    uint size, uint* lpNumberOfBytesWritten);

#endregion

#region Constants

        public const ProcessAccessRights DEFAULT_PROCESS_ACCESS = ProcessAccessRights.PROCESS_VM_READ |
                                                                  ProcessAccessRights.PROCESS_VM_WRITE |
                                                                  ProcessAccessRights.PROCESS_VM_OPERATION |
                                                                  ProcessAccessRights.PROCESS_QUERY_INFORMATION;

#endregion

#region Private fields

        private void* _processPtr;

#endregion

#region Properties

        public Process Process { get; private set; }

        public void* ProcessPtr { get { return _processPtr; } }

#endregion

#region Class methods

        public ProcessMemoryEditor()
        {
            Process = null;
            _processPtr = null;
        }

        public ProcessMemoryEditor(Process process, ProcessAccessRights access = DEFAULT_PROCESS_ACCESS) 
            : this()
        {
            OpenProcess(process, access);
        }

        public void OpenProcess(Process process, ProcessAccessRights access = DEFAULT_PROCESS_ACCESS)
        {
            if (process == null)
            {
                throw new Exception("Process pointer is null-reference");
            }
            if (Process != null)
            {
                CloseProcess();
            }
            _processPtr = OpenProcess((uint)access, false, (uint)process.Id);
            Process = process;
        }

        public void CloseProcess()
        {
            bool done = CloseHandle(_processPtr);
            if (!done)
            {
                throw new Exception("CloseProcess failed");
            }
            _processPtr = null;
        }

        public byte[] ReadProcessMemory(uint address, uint bytesToRead, out uint bytesRead)
        {
            byte[] buffer = new byte[bytesToRead];
            fixed (void* pBuffer = buffer)
            {
                fixed (uint* pBytesRead = &bytesRead)
                {
                    ReadProcessMemory(_processPtr, (void*)address, pBuffer, bytesToRead, pBytesRead);
                    return buffer;
                }
            }
        }

        public void WriteProcessMemory(uint address, byte[] data, uint bytesToWrite, out uint bytesWritten)
        {
            fixed (void* pData = data)
            {
                fixed (uint* pBytesWritten = &bytesWritten)
                {
                    WriteProcessMemory(_processPtr, (void*)address, pData, bytesToWrite, pBytesWritten);
                }
            }
        }

#endregion

    }
}