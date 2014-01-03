namespace TimeZero.Auction.Bot.Classes.MemoryEditor
{
    internal sealed class ScanResult
    {

#region Properties

        public ProcessMemoryScanner ProcessMemoryScanner { get; private set; }
        public uint CurrentAddress { get; private set; }
        public uint EndAddress { get; private set; }
        public byte[] Data { get; private set; }
        public uint DataLength { get; private set; }

#endregion

#region Class methods

        public ScanResult(ProcessMemoryScanner scanner, uint currentAddress,
                          uint endAddress, byte[] data, uint dataLength)
        {
            ProcessMemoryScanner = scanner;
            CurrentAddress = currentAddress;
            EndAddress = endAddress;
            Data = data;
            DataLength = dataLength;
        }

        public ScanResult ScanNext()
        {
            return ProcessMemoryScanner.ScanNext(this);
        }

        public ScanResult ScanNext(object obj)
        {
            return ProcessMemoryScanner.ScanNext(this, obj);
        }

        public override string ToString()
        {
            return string.Format("[{0}]", CurrentAddress);
        }

#endregion

    }
}
