using System;
using System.Collections.Generic;
using System.IO;

namespace ESOWorld {
    public class Def {
        //public static Dictionary<string, string> defNames;


        public uint version;
        public uint numRecords;
        public uint unk;
        public DefRow[] rows;

        public DefRow Get(uint id) {
            for (int i = 0; i < rows.Length; i++) if (rows[i].id == id) return rows[i];
            return null;
        }

        public string GetName(uint id) {
            for (int i = 0; i < rows.Length; i++) if (rows[i].id == id) return rows[i].data.name;
            return id.ToString();
        }

        public Def(string path) : this(path, typeof(DefDataGeneric)) { }

        public Def(string path, Type dataType) {
            using(BinaryReader r = new BinaryReader(File.OpenRead(path))) {
                r.AssertUint32(4210748395, true);
                version = r.ReadUInt32B();
                numRecords = r.ReadUInt32B();
                unk = r.ReadUInt32B();

                int i = 0;
                List<DefRow> rowList = new List<DefRow>((int)numRecords);
                while(i < numRecords && r.BaseStream.Position < r.BaseStream.Length) {
                    rowList.Add(new DefRow(r, dataType));
                }
                rows = rowList.ToArray();
            }
        }
    }

    public class DefRow {
        public uint key;
        public uint id;
        public uint dataSize;
        public DefData data;

        public DefRow(BinaryReader r, Type dataType) {
            r.Seek(20);
            key = r.ReadUInt32B();
            id = r.ReadUInt32B();
            dataSize = r.ReadUInt32B();
            long pos = r.BaseStream.Position;
            data = (DefData) Activator.CreateInstance(dataType, r);
            r.BaseStream.Seek(pos + dataSize, SeekOrigin.Begin);
        }

        public override string ToString() {
            return string.Format("{0:D8}\t{1:D6}\t{2}\t{3:D3}\t{4}", key, id, data.unk, data.updateTag, data.name);
        }
    }

    public abstract class DefData {
        protected const int HEADER_SIZE_WITHOUT_NAME = 25;

        public uint id;
        public string name;
        public uint unk;
        public ushort updateTag;
        public uint stamp;

        protected void ReadHeader(BinaryReader r) {
            id = r.ReadUInt32B();
            ushort nameLength = r.ReadUInt16B();
            name = nameLength > 0 ? System.Text.Encoding.ASCII.GetString(r.ReadBytes(nameLength)) : "";
            r.Seek(5);
            unk = r.ReadUInt32B();
            updateTag = r.ReadUInt16B();
            r.Seek(4);
            stamp = r.ReadUInt32B();
        }
  
    }

    public class DefDataGeneric : DefData {
        //public byte[] data;
        public DefDataGeneric(BinaryReader r) {
            ReadHeader(r);
            //data = r.ReadBytes((int)r.BaseStream.Length - name.Length - HEADER_SIZE_WITHOUT_NAME);
        }
    }

    public class WorldTileMapLayer {
        public uint key;
        public uint unk;
        public byte[] data;

        public WorldTileMapLayer(BinaryReader r) {
            key = r.ReadUInt32B();
            unk = r.ReadUInt32B();
            data = r.ReadBytes((int)r.ReadUInt32B());
        }
    }

    public class DefDataWorldTileMap : DefData {
        public uint worldID;
        public uint x;
        public uint y;
        public uint type;
        public uint cellSizeX;
        public uint cellSizeY;
        public WorldTileMapLayer[] layers;

        public DefDataWorldTileMap(BinaryReader r) {
            ReadHeader(r);
            worldID = r.ReadUInt32B();
            x = r.ReadUInt32B();
            y = r.ReadUInt32B();
            type = r.ReadUInt32B();
            cellSizeX = r.ReadUInt32B();
            cellSizeY = r.ReadUInt32B();
            layers = new WorldTileMapLayer[r.ReadUInt32B()];
            for (int i = 0; i < layers.Length; i++) layers[i] = new WorldTileMapLayer(r);
        }
    }

    public class DefDataWaterVolume : DefData {
        public uint height;
        public uint waterTypeID;
        public uint unk1;
        public uint unk2;

        public DefDataWaterVolume(BinaryReader r) {
            ReadHeader(r);
            height = r.ReadUInt32B();
            waterTypeID = r.ReadUInt32B();
            unk1 = r.ReadUInt32B();
            unk2 = r.ReadUInt32B();
        }
    }

    public class DefPointOfInterest : DefData {
        public uint type;

        public DefPointOfInterest(BinaryReader r) {
            ReadHeader(r);
            type = r.ReadUInt32B();
        }
    }

    public class DefZone : DefData {
        public float[] color;
        public uint worldID;
        public uint mapID;
        public uint[] pois;
        public uint loadingScreenID;
        public uint parentWorldID;

        public DefZone(BinaryReader r) {
            ReadHeader(r);
            r.Seek(8);
            color = new float[] { r.ReadSingle(), r.ReadSingle(), r.ReadSingle() };
            worldID = r.ReadUInt32B();
            r.Seek(14);
            mapID = r.ReadUInt32B();
            pois = new uint[r.ReadUInt32B()];
            for (int i = 0; i < pois.Length; i++) pois[i] = r.ReadUInt32B();
            r.Seek(8);
            r.Seek((int)r.ReadUInt32B() * 4);
            loadingScreenID = r.ReadUInt32B();
            r.Seek(4);
            parentWorldID = r.ReadUInt32B();
        }
    }

    public class DefQuest : DefData {
        public byte isShareable;
        public uint[] id1;
        public uint[] id2;
        public uint[] id3;
        public uint id4;
        public uint[] id5;
        public QuestType type;
        public uint level;
        public uint questRewardID;
        public uint unk2;
        public uint[] antiPrereqs;
        public uint[] antiCurrentPrereqs;
        public uint[] antiEndings;
        public uint unk3;
        public uint poiID;
        public uint zoneID;
        public uint zoneID2;
        public RepeatableType repeatableType;
        public uint[] bestowals;
        public uint guildID;
        public uint guildRank;
        public uint companionLevel;
        public Icon icon;
        public uint companionID;

        public enum QuestType {
            Generic = 0,
            Repeatable = 1,
            Main = 2,
            Guild = 3,
            Crafting = 4,
            Dungeon = 5,
            Trial = 6,
            PVP = 7,
            Unk1 = 9,
            PVP2 = 10,
            Event = 12,
            Battleground = 13,
            Prologue = 14,
            Pledge = 15,
            Companion = 16
        }

        public enum RepeatableType {
            No = 0,
            Repeatable = 1,
            Daily = 2,
            Event = 3
        }

        public enum Icon { 
            None = 0,
            Solo = 1,
            Group = 2,
            Trial = 3,
            GroupArea = 5,
            ZoneStory = 10,
            Companion = 11
        }

        public DefQuest(BinaryReader r) {
            ReadHeader(r);
            isShareable = r.ReadByte();
            r.Seek(2);
            id1 = r.ReadUInt32ArrayB();
            id2 = r.ReadUInt32ArrayB();
            id3 = r.ReadUInt32ArrayB();
            id4 = r.ReadUInt32B();
            id5 = r.ReadUInt32ArrayB();
            type = (QuestType) r.ReadUInt32B();
            level = r.ReadUInt32B();
            questRewardID = r.ReadUInt32B();
            unk2 = r.ReadUInt32B();
            antiPrereqs = r.ReadUInt32ArrayB();
            antiCurrentPrereqs = r.ReadUInt32ArrayB();
            antiEndings = r.ReadUInt32ArrayB();
            unk3 = r.ReadUInt32B();
            poiID = r.ReadUInt32B();
            zoneID = r.ReadUInt32B();
            zoneID2 = r.ReadUInt32B();
            repeatableType = (RepeatableType) r.ReadUInt32B();
            bestowals = r.ReadUInt32ArrayB();
            guildID = r.ReadUInt32B();
            guildRank = r.ReadUInt32B();
            companionLevel = r.ReadUInt32B();
            r.Seek(4);
            icon = (Icon) r.ReadUInt32B();
            r.Seek(8);
            companionID = r.ReadUInt32B();
        }
    }
}
