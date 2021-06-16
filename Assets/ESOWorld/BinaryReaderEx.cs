using System;
using System.IO;


namespace ESOWorld {
    public static class BinaryReaderEx {
        public static uint AssertUint32(this BinaryReader r, uint comp) {
            uint val = r.ReadUInt32();
            if (val != comp) Console.WriteLine($"ASSERTION FAILED {val} !+ {comp}");
            return val;
        }

        public static string ReadSTDString(this BinaryReader r) {
            string s = new string(r.ReadChars(r.ReadUInt16()));
            r.ReadByte();
            return s;
        }
    }
}
