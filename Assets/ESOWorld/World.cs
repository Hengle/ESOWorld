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
            name = r.ReadStringC();
            extension = r.ReadStringC();
            cellsX = (uint)((float)sizeX / size + 0.5);
            cellsY = (uint)((float)sizeY / size + 0.5);
        }
    }

    public class FixtureFile {
        public FixturePlaced[] fixtures;
        public FixtureLight[] lights;
        public FixtureVolume[] volumes;
        public FixtureGroup[] groups;
        public RTree bvh1;
        public RTree bvh2;
        public RTree bvh3;
        public RTree bvh4;

        public FixtureFile(BinaryReader r) {
            r.AssertUint32(23);
            fixtures = new FixturePlaced[r.ReadUInt32()];
            for(int i = 0; i < fixtures.Length; i++) {
                fixtures[i] = new FixturePlaced(r);
            }

            lights = new FixtureLight[r.ReadUInt32()];
            for (int i = 0; i < lights.Length; i++) {
                lights[i] = new FixtureLight(r);
            }

            volumes = new FixtureVolume[r.ReadUInt32()];
            for (int i = 0; i < volumes.Length; i++) {
                volumes[i] = new FixtureVolume(r);
            }

            groups = new FixtureGroup[r.ReadUInt32()];
            for (int i = 0; i < groups.Length; i++) {
                groups[i] = new FixtureGroup(r);
            }

            bvh1 = new RTree(r);
            bvh2 = new RTree(r);
            bvh3 = new RTree(r);
            bvh4 = new RTree(r);
        }

        public static FixtureFile Open(string path) {
            return new FixtureFile(new BinaryReader(File.OpenRead(path)));
        }
    }

    public struct Fixture {
        public ulong id;
        public float rotX; public float rotY; public float rotZ;
        public float posX; public float posY; public float posZ;
        public uint offsetX; public uint offsetY;

        public Fixture(BinaryReader r) {
            id = r.ReadUInt64();
            r.Seek(8);
            rotX = r.ReadSingle(); rotY = r.ReadSingle(); rotZ = r.ReadSingle();
            posX = r.ReadSingle(); posY = r.ReadSingle(); posZ = r.ReadSingle();
            offsetX = r.ReadUInt32();
            r.Seek(4);
            offsetY = r.ReadUInt32();
        }
    }

    public struct FixturePlaced {
        public Fixture fixture;
        public uint model;

        public FixturePlaced(BinaryReader r) {
            fixture = new Fixture(r);
            r.BaseStream.Seek(16, SeekOrigin.Current);
            model = r.ReadUInt32();
            r.BaseStream.Seek(24, SeekOrigin.Current);
        }
    }

    public struct FixtureLight {
        public Fixture fixture;

        public FixtureLight(BinaryReader r) {
            fixture = new Fixture(r);
            r.Seek(260);
        }
    }

    public struct FixtureVolume {
        public Fixture fixture;
        public float x;
        public float y;
        public float z;

        public FixtureVolume(BinaryReader r) {
            fixture = new Fixture(r);
            r.Seek(16);
            x = r.ReadSingle(); y = r.ReadSingle(); z = r.ReadSingle();
            r.Seek(8);
        }
    }

    public struct FixtureGroup {
        public uint id;
        public ulong[] furnitureIDs;

        public FixtureGroup(BinaryReader r) {
            id = r.ReadUInt32();
            furnitureIDs = new ulong[r.ReadUInt32()];
            for (int i = 0; i < furnitureIDs.Length; i++) furnitureIDs[i] = r.ReadUInt64(); 
        }
    }

    public class RTree {
        public string signature;
        public RTreeNode root;
        public RTree(BinaryReader r) {
            signature = new string(r.ReadChars(4));
            root = ReadNode(r);
            root.bbox = new float[6];
        }

        RTreeNode ReadNode(BinaryReader r) {
            RTreeNode node = new RTreeNode(r) { nodes = new RTreeNode[r.ReadUInt32()] };
            if (node.levelsBelow == 0) {
                for (int i = 0; i < node.nodes.Length; i++) node.nodes[i] = new RTreeNode(r) { nodes = new RTreeNode[0] };
            } else {
                for (int i = 0; i < node.nodes.Length; i++) node.nodes[i] = ReadNode(r);
            }
            return node;
        }
    }

    public class RTreeNode {
        public float[] bbox;
        public uint levelsBelow;
        public RTreeNode[] nodes;

        public RTreeNode (BinaryReader r) {
            bbox = new float[6];
            for (int i = 0; i < 6; i++) bbox[i] = r.ReadSingle();
            levelsBelow = r.ReadUInt32();
        }
    }

}
