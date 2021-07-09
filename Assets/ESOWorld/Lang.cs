using System;
using System.Collections.Generic;
using System.IO;

namespace ESOWorld {
    public class Lang {

        public enum Entry {
            PointOfInterest =  10860933,
            ObjectiveText = 129979412,
            ObjectiveCompleteText = 108566804,
            Zone = 162658389,
            ZoneLoadScreenText = 70901198,
            Quest = 52420949
        }


        long textOffset;
        BinaryReader reader;
        public Dictionary<ulong, uint> offsets;

        public Lang(string path) {
            offsets = new Dictionary<ulong, uint>();
            reader = new BinaryReader(File.OpenRead(path));
            reader.AssertUint32(2, true);
            uint recordCount = reader.ReadUInt32B();
            for (int i = 0; i < recordCount; i++) {
                uint type = reader.ReadUInt32B();
                uint subType = reader.ReadUInt32B();
                uint id = reader.ReadUInt32B();
                uint offset = reader.ReadUInt32B();
                if(offset != 0) offsets[((ulong)type << 32) + id] = offset;
            }
            textOffset = reader.BaseStream.Position;
        }

        public bool HasName(uint id, Entry type) {
            return offsets.ContainsKey(((ulong)type << 32) + id);
        }

        public string GetName(uint id, Entry type) {
            ulong key = ((ulong)type << 32) + id;
            if(offsets.ContainsKey(key)) {
                reader.BaseStream.Seek(offsets[key] + textOffset, SeekOrigin.Begin);
                return reader.ReadStringNullTerminated();
            }
            return "";
        }

        ~Lang() {
            if(reader != null) reader.Close();
        }

    }

}
