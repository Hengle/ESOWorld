using System.Collections.Generic;
using System.IO;
using System.Text;
using System;

namespace ESOWorld {

    public struct Toc {
        public uint sizeX;
        public uint sizeY;
        public ushort unk;
        public Layer[] layers;

        override public string ToString() {
            StringBuilder s = new StringBuilder($"{sizeX}\t{sizeY}\t{unk}\t");
            for(int i = 0; i < layers.Length; i++) {
                s.Append($"{layers[i].name}.{layers[i].extension}({layers[i].size} {layers[i].cellsX}x{layers[i].cellsY})\t");
            }
            return s.ToString();
        }

        public Toc(BinaryReader r) {
            r.AssertUint32(1);
            sizeX = r.ReadUInt32(); sizeY = r.ReadUInt32(); unk = r.ReadUInt16();
            r.ReadByte();
            List<Layer> layerList = new List<Layer>();
            while (r.BaseStream.Position < r.BaseStream.Length - 1) {
                layerList.Add(new Layer(r, sizeX, sizeY));
            }
            layers = layerList.ToArray();
        }

        public static Toc Read(string path) {
            return new Toc(new BinaryReader(File.OpenRead(path)));
        }

    }

    public struct Layer {
        public ushort size;
        public string name;
        public string extension;
        public uint cellsX;
        public uint cellsY;
        public Layer(BinaryReader r, uint sizeX = 0, uint sizeY = 0) {
            size = r.ReadUInt16();
            name = r.ReadSTDString();
            extension = r.ReadSTDString();
            cellsX = (uint)((float)sizeX / size + 0.5);
            cellsY = (uint)((float)sizeY / size + 0.5);
        }
    }

    public struct FixtureFile {
        public FixturePlaced[] fixtures;

        public FixtureFile(BinaryReader r) {
            r.ReadInt32();
            fixtures = new FixturePlaced[r.ReadUInt32()];
            for(int i = 0; i < fixtures.Length; i++) {
                fixtures[i] = new FixturePlaced(r);
            }
        }

        public static FixtureFile Open(string path) {
            return new FixtureFile(new BinaryReader(File.OpenRead(path)));
        }
    }

    public struct FixturePlaced {
        public ulong id;
        public float rotX; public float rotY; public float rotZ;
        public float posX; public float posY; public float posZ;
        public uint offsetX; public uint offsetY;
        public uint model;

        public FixturePlaced(BinaryReader r) {
            id = r.ReadUInt64();
            r.BaseStream.Seek(8, SeekOrigin.Current);
            rotX = r.ReadSingle(); rotY = r.ReadSingle(); rotZ = r.ReadSingle();
            posX = r.ReadSingle(); posY = r.ReadSingle(); posZ = r.ReadSingle();
            offsetX = r.ReadUInt32();
            r.ReadUInt32();
            offsetY = r.ReadUInt32();
            r.BaseStream.Seek(16, SeekOrigin.Current);
            model = r.ReadUInt32();
            r.BaseStream.Seek(24, SeekOrigin.Current);
        }
    }
}
