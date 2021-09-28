using System;
using System.Collections.Generic;
using System.IO;

namespace ESOWorld {
    public class Util {

        public static string[] layerNames = new string[] {
            "grass", "terrain", "terrain-height", "terrain-color-raw", "terrain-color", "terrain-blend0-raw", "terrain-blend1-raw", "terrain-blend2-raw", "terrain-blend3-raw",
            "minimap", "terrain-lod", "terrain-map", "terrain-lod-diffuse", "terrain-lod-normal", "terrain-normal", "terrain-hole", "terrain-clutter", "terrain-clutter-pts",
            "ext0", "ext1", "ext2", "fixtures", "minimap2", "ext3", "ext4"
        };

        public static string[] layerExtensions = new string[] {
            "dds", "dat","dat","dat","dds","dat","dat","dat","dat","dds","dat","dds","dds","dds","dat","dat","dat","dat","dat","dat","dat","fft","dds","dat","dat"
        };

        public static string[] layerFiles = new string[] {
            "grass", "lod-fixtures", "trees", "2", "3", "4"
        };

        public static Dictionary<UInt64, string> LoadWorldFiles(string worldFolder = @"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\badlandsworld\") {
            Dictionary<UInt64, string> worldFiles = new Dictionary<ulong, string>();
            //foreach (string path in Directory.EnumerateFiles(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\badlandsworld\", "*", SearchOption.AllDirectories))
            foreach (string path in Directory.EnumerateFiles(worldFolder, "*", SearchOption.AllDirectories))
                if (!path.Contains(".xv4")) worldFiles[UInt64.Parse(Path.GetFileNameWithoutExtension(path), System.Globalization.NumberStyles.HexNumber)] = path;
            Console.WriteLine("loaded paths");
            return worldFiles;
        }

        public static UInt64 WorldCellID(uint worldID, uint layerID, uint cellX, uint cellY) {
            return 0x4000000000000000UL | ((worldID & 0x7FFUL) << 37) | ((layerID & 0x1FUL) << 32) | ((cellX & 0xFFFFUL) << 16) | (cellY & 0xFFFFUL);
        }

        public static UInt64 WorldTocID(uint worldID) {
            return 0x4400000000000000UL | worldID;
        }

        public static UInt64 WorldFileID(uint worldID, uint layerID) {
            return 0x4800000000000000UL | ((worldID & 0x7FFUL) << 37) | ((layerID & 0x1FUL) << 32);
        }

        public static string WorldCellFilename(uint worldID, uint layerID, uint cellX, uint cellY) {
            return string.Format("{0:X16}", WorldCellID(worldID, layerID, cellX, cellY));
        }


        public static string WorldFileDesc(ulong id) {
            //return string.Format("{0:X}", id >> 112);
            if ((id >> 120) == 0x44) return $"{id & 0xffff}.toc";
            if ((id >> 120) == 0x40) return $"{(id >> 37) & 0x7ff}_{layerNames[(id >> 32) & 0x1f]}_{(id >> 16) & 0xffff}_{id & 0xffff}.cell";
            if ((id >> 120) == 0x48) return $"{(id >> 37) & 0x7ff}_{layerFiles[(id >> 32) & 0x1f]}.file";

            return "";
        }


        public struct WorldFileData {
            public uint type; //0 = toc, 1 = cell, 2 = file
            public uint worldID;
            public uint layer;
            public uint x;
            public uint y;

            public WorldFileData(ulong id) {
                type = 3; worldID = 0; layer = 0; x = 0; y = 0;
                if ((id >> 120) == 0x44) {
                    type = 0;
                    worldID = (uint)(id & 0xffff);
                    
                }
                if ((id >> 120) == 0x40 || (id >> 120) == 0x48) {
                    type = 2;
                    worldID = (uint)((id >> 37) & 0x7ff);
                    layer = (uint)((id >> 32) & 0x1f);

                    if ((id >> 120) == 0x40) {
                        type = 1;
                        x = (uint)((id >> 16) & 0xffff);
                        y = (uint)(id & 0xffff);
                    }
                }
            }
		}

        public static int NextPow2(int i) {
            int ret = 64;
            while (ret < i) ret = ret * 2;
            return ret;
        }

        public static int NextPow2(uint i) {
            int ret = 64;
            while (ret < i) ret = ret * 2;
            return ret;
        }
    }
}
