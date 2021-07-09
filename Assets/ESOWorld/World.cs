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

    public class TerrainFile {
        ushort version;
        uint[] sizes;
        public TerrainLayer[] layers;

        public TerrainFile(BinaryReader r) {
            version = r.ReadUInt16();
            r.Seek(7);
            sizes = new uint[r.ReadByte()];
            for(int i = 0; i < sizes.Length; i++) {
                r.Seek(5);
                sizes[i] = r.ReadUInt32();
			}
            r.Seek(82);
            layers = new TerrainLayer[sizes.Length];
            for(uint i = 0; i < layers.Length; i++) { //CHANGE BACK TO LAYERS.LENGTH
                if (sizes[i] > 0) layers[i] = new TerrainLayer(i, r);
			}
		}

        public float[,] GetHeights() {
            if (layers[0] == null) return new float[65, 65];
            float[,] heights = new float[layers[0].rows.Length, layers[0].rows.Length];
            for(int row = 0; row < layers[0].rows.Length; row++) {
                for(int x = 0; x < layers[0].rows.Length; x++) {
                    heights[x, row] = BitConverter.ToSingle(layers[0].rows[row], x * 4);
				}
			}
            return heights;
        }

        public byte[] GetLayerBytes(int layer) {
            List<byte> bytes = new List<byte>((int)(layers[layer].rowSize * layers[layer].rows.Length));
            for(int i = 0; i < layers[layer].rows.Length; i++) {
                bytes.AddRange(layers[layer].rows[i]);
			}
            return bytes.ToArray();
		}
    }

    public class TerrainLayer {
        public uint type;
        public ushort rowSize;
        public uint rowSize2;
        public byte[][] rows;

        public TerrainLayer(uint type, BinaryReader r) {
            this.type = type;
            r.Seek(4);
            rows = new byte[r.ReadUInt32()][];
            rowSize2 = r.ReadUInt32();
            rowSize = (ushort) r.ReadUInt32();
            
            for(uint i = 0; i < rows.Length; i++) {
                r.AssertUint16(rowSize);
                rows[i] = r.ReadBytes(rowSize);
			}
            r.Seek(4);
		}
	}

    public class FixtureFile {
        public uint version;
        public FixturePlaced[] fixtures;
        public FixtureLight[] lights;
        public FixtureVolume[] volumes;
        public FixtureGroup[] groups;
        public RTree bvh1;
        public RTree bvh2;
        public RTree bvh3;
        public RTree bvh4;

        public FixtureFile(BinaryReader r) {
            version = r.ReadUInt32();
            fixtures = new FixturePlaced[r.ReadUInt32()];
            for(int i = 0; i < fixtures.Length; i++) {
                fixtures[i] = new FixturePlaced(r, version);
            }
            /*
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
            */
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

        public FixturePlaced(BinaryReader r, uint version) {
            fixture = new Fixture(r);
            r.Seek(16);
            model = r.ReadUInt32();
            r.Seek(8);
            if (version != 22) r.Seek(16);
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
