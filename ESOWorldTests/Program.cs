using System;
using System.Collections.Generic;
using ESOWorld;
using ImageMagick;
using System.IO;

namespace ESOWorldTests {
    class Program {
        static void Main(string[] args) {
            //FixtureFile f = new FixtureFile(new BinaryReader(File.OpenRead(@"F:\Extracted\ESO\139\fixtures_3_3.fft")));
            //ReadTree(f);
            
            var paths = LoadWorldFiles();
            uint worldID = 139;
            Toc t = Toc.Read(paths[Util.WorldTocID(worldID)]);
            Layer l = t.layers[21];
            for (uint y = 0; y < l.cellsY; y++) {
                for (uint x = 0; x < l.cellsX; x++) {
                    if (!paths.ContainsKey(Util.WorldCellID(worldID, 21, x, y))) continue;
                    FixtureFile f = new FixtureFile(new BinaryReader(File.OpenRead(paths[Util.WorldCellID(worldID, 21, x, y)])));
                    Console.WriteLine($"{x},{y}:\n");
                    ReadTree(f.bvh1);
                    Console.WriteLine();
                    ReadTree(f.bvh2);
                    Console.WriteLine();
                    ReadTree(f.bvh3);
                    Console.WriteLine();
                    ReadTree(f.bvh4);
                    Console.WriteLine("\n\n");
                    //if (f.unks.Length == 0) continue;
                    //Console.WriteLine($"{x},{y}:");
                    //for (int i = 0; i < f.unks.Length; i++) Console.WriteLine(f.unks[i].fixture.posX);
                }
            }
            
            //HeightMontage(777, paths);

            //for(uint i = 0; i < 1300; i++) {
            //    if(paths.ContainsKey(WorldTocID(i))) {
            //        Console.WriteLine(i);
            //        LodMontage(i, paths);
            //    }
            //}
        }


        static void ReadTree(RTree t) {
            Console.WriteLine(t.signature);
            ReadNode(0, t.root);
        }

        static void ReadNode(int depth, RTreeNode node) {
            if(node.nodes.Length == 0) {
                Console.WriteLine(new string(' ', depth * 2) + $"{node.levelsBelow}");
            } else {
                Console.WriteLine(new string(' ', depth * 2) + $"{node.bbox[0]} {node.bbox[1]} {node.bbox[2]}, {node.bbox[3]} {node.bbox[4]} {node.bbox[5]}");
                for (int i = 0; i < node.nodes.Length; i++) ReadNode(depth + 1, node.nodes[i]);
            }
        }

        static void HeightMontage(uint worldID, Dictionary<UInt64, string> paths) {
            Toc t = Toc.Read(paths[Util.WorldTocID(worldID)]);
            Layer l = t.layers[1];

            MagickImageCollection images = new MagickImageCollection();
            MagickReadSettings settings = new MagickReadSettings() { Width = 512, Height = 512, BackgroundColor = MagickColors.Black, ColorSpace = ColorSpace.RGB };
            for (uint y = 0; y < l.cellsY; y++) {
                for (uint x = 0; x < l.cellsX; x++) {
                    if (paths.ContainsKey(Util.WorldCellID(worldID, 1, x, y))) {
                        float[] heights = ReadTerrainHeights(paths[Util.WorldCellID(worldID, 1, x, y)]);
                        using (MemoryStream outstream = new MemoryStream()) {
                            using (BinaryWriter writer = new BinaryWriter(outstream)) {
                                for (int u = 0; u < 64; u++) {
                                    for (int v = 0; v < 64; v++) {
                                        writer.Write((ushort)(heights[u + v * 65] * 64));
                                    }
                                }
                                outstream.Seek(0, SeekOrigin.Begin);
                                PixelReadSettings pixelsettings = new PixelReadSettings(64, 64, StorageType.Short, "R");
                                MagickImage image = new MagickImage(outstream, pixelsettings);
                                images.Add(image);
                            }
                        }
                    } else images.Add(new MagickImage(MagickColors.Black, 64, 64));
                }
            }

            //MontageSettings montageSettings = new MontageSettings() { Geometry = new MagickGeometry(512, 512, 0, 0) };
            var montage = images.Montage(new MontageSettings() { Geometry = new MagickGeometry(64), TileGeometry = new MagickGeometry((int)l.cellsX, (int)l.cellsY), Gravity = Gravity.Southwest });
            montage.BackgroundColor = MagickColors.Black;
            montage.Extent(NextPow2(montage.Width) + 1, NextPow2(montage.Height) + 1, Gravity.Southwest);
            Console.WriteLine("saving...");

            montage.Write(string.Format(@"F:\Extracted\ESO\heights\{0:0000}_height_{1}x{2}.gray", worldID, montage.Width, montage.Height));

            for (int i = images.Count - 1; i >= 0; i--) images[i].Dispose();
            images.Dispose();
        }

        static int NextPow2(int i) {
            int ret = 64;
            while (ret < i) ret = ret * 2;
            return ret;
        }


        static float[] ReadTerrainHeights(string path) {
            float[] heights = new float[65 * 65];
            using (FileStream filestream = File.Open(path, FileMode.Open)) {
                using (BinaryReader file = new BinaryReader(filestream)) {
                    file.ReadBytes(198);
                    for (int x = 0; x <= 64; x++) {
                        file.ReadBytes(2);
                        for (int y = 0; y <= 64; y++) {
                            heights[x + y * 65] = file.ReadSingle();
                        }
                    }
                }
            }
            return heights;
        }

        static Dictionary<UInt64, string> LoadWorldFiles() {
            Dictionary<UInt64, string> worldFiles = new Dictionary<ulong, string>();
            foreach (string path in Directory.EnumerateFiles(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\badlandsworld\", "*", SearchOption.AllDirectories))
                if (!path.Contains(".xv4")) worldFiles[UInt64.Parse(Path.GetFileNameWithoutExtension(path), System.Globalization.NumberStyles.HexNumber)] = path;
            Console.WriteLine("loaded paths");
            return worldFiles;
        }

        static void LodMontage(uint worldID, Dictionary<UInt64, string> worldFiles) {
            Toc t = Toc.Read(worldFiles[Util.WorldTocID(worldID)]);
            Layer l = t.layers[12];


            MagickImageCollection images = new MagickImageCollection();
            MagickReadSettings settings = new MagickReadSettings() { Width = 512, Height = 512, BackgroundColor = MagickColors.Black, ColorSpace = ColorSpace.RGB };
            for (uint y = 0; y < l.cellsY; y++) {
                for (uint x = 0; x < l.cellsX; x++) {
                    if (worldFiles.ContainsKey(Util.WorldCellID(worldID, 12, x, y)))
                        images.Add(new MagickImage(worldFiles[Util.WorldCellID(worldID, 12, x, y)], settings));
                    else
                        images.Add(new MagickImage(MagickColors.Black, 512, 512));
                }
            }

            //MontageSettings montageSettings = new MontageSettings() { Geometry = new MagickGeometry(512, 512, 0, 0) };
            var montage = images.Montage(new MontageSettings() { Geometry = new MagickGeometry(512), TileGeometry = new MagickGeometry((int)l.cellsX, (int)l.cellsY) });
            Console.WriteLine("saving...");
            montage.Write(string.Format(@"F:\Extracted\ESO\lodtex\{0:0000}_lod_diffuse.bmp", worldID));
            for (int i = images.Count - 1; i >= 0; i--) images[i].Dispose();
            images.Dispose();

        }

        static void CopyCellFiles(uint worldID, Dictionary<UInt64, string> worldFiles) {
            if (!worldFiles.ContainsKey(Util.WorldTocID(worldID))) return;
            Toc t = Toc.Read(worldFiles[Util.WorldTocID(worldID)]);

            if (!Directory.Exists($@"F:\Extracted\ESO\{worldID}\")) Directory.CreateDirectory($@"F:\Extracted\ESO\{worldID}\");
            for (uint l = 0; l < t.layers.Length; l++) {
                for (uint y = 0; y < t.layers[l].cellsY; y++) {
                    for (uint x = 0; x < t.layers[l].cellsX; x++) {
                        ulong id = Util.WorldCellID(worldID, l, x, y);
                        if (worldFiles.ContainsKey(id)) {
                            //Console.WriteLine($@"F:\Extracted\ESO\01a\{t.layers[l].name}_{x}_{y}.{t.layers[l].extension}");
                            File.Copy(worldFiles[id], $@"F:\Extracted\ESO\{worldID}\{t.layers[l].name}_{x}_{y}.{Util.layerExtensions[l]}", true);
                        }
                    }
                }
                if (worldFiles.ContainsKey(Util.WorldFileID(worldID, l))) {
                    File.Copy(worldFiles[Util.WorldFileID(worldID, l)], $@"F:\Extracted\ESO\{worldID}\{t.layers[l].name}.{Util.layerExtensions[l]}", true);

                }
            }

        }

    }
}
