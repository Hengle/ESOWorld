using System;
using System.Collections.Generic;
using ESOWorld;
using ImageMagick;
using System.IO;

namespace ESOWorldTests {
    class Program {
        static void Main(string[] args) {
            /*
            Lang l = new Lang(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\newlang\gamedata\lang\en.lang");
            Def zones = new Def(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\badlandsdata3\000\a\6000000000000032_Uncompressed.EsoFileData", typeof(DefZone));
            Def worlds = new Def(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\badlandsdata3\000\a\600000000000003C_Uncompressed.EsoFileData");
            for (int i = 0; i < zones.rows.Length; i++) { //zones.rows.Length
                DefZone zone = (DefZone)zones.rows[i].data;
                Console.WriteLine($"{zone.id}|{worlds.Get(zone.worldID).id}|{zone.name}|{l.GetName(zone.id, Lang.Entry.Zone)}|{worlds.GetName(zone.parentWorldID)}");
            }
            */
            //var paths = Util.LoadWorldFiles();
            //HeightMontage(198, paths);

                //var paths = Util.LoadWorldFiles();
                //HeightMontage(475, paths);

                //Def zones = new Def(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\badlandsdata3\000\a\6000000000000032_Uncompressed.EsoFileData", typeof(DefZone));

                /*
                Def quests = new Def(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\badlandsdata3\000\a\600000000000000A_Uncompressed.EsoFileData", typeof(DefQuest));

                TextWriter w = new StreamWriter(File.Open("quests.csv", FileMode.Create));
                Lang l = new Lang(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\newlang\gamedata\lang\en.lang");
                for(uint i = 0; i < quests.rows.Length; i++) {
                    DefQuest quest = (DefQuest)quests.rows[i].data;
                    if(quest.name != "")
                    w.WriteLine($"{quest.id}|{quest.name}|{l.GetName(quest.id, Lang.Entry.Quest)}|{quest.zoneID}|{l.GetName(quest.zoneID, Lang.Entry.Zone)}|{quest.poiID}|{l.GetName(quest.poiID, Lang.Entry.PointOfInterest)}|{quest.type}|{quest.repeatableType}|{quest.icon}");
                   // if (quest.poiID != 0) w.Write($"|{l.GetName(quest.poiID, Lang.Entry.PointOfInterest)}");
                }
                w.Flush(); w.Close();
                */

                /*
                Def quests = new Def(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\badlandsdata3\000\a\600000000000000A_Uncompressed.EsoFileData", typeof(DefQuest));

                TextWriter w = new StreamWriter(File.Open("quests.csv", FileMode.Create));
                Lang l = new Lang(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\newlang\gamedata\lang\en.lang");
                for (uint i = 0; i < quests.rows.Length; i++) {
                    DefQuest quest = (DefQuest)quests.rows[i].data;
                    if (quest.name != "")
                        w.WriteLine($"{quest.id}|{quest.name}|{l.GetName(quest.id, Lang.Entry.Quest)}|{quest.zoneID}|{l.GetName(quest.zoneID, Lang.Entry.Zone)}|{quest.poiID}|{l.GetName(quest.poiID, Lang.Entry.PointOfInterest)}|{quest.type}|{quest.repeatableType}|{quest.icon}");
                    // if (quest.poiID != 0) w.Write($"|{l.GetName(quest.poiID, Lang.Entry.PointOfInterest)}");
                }
                w.Flush(); w.Close();
                */

                //DefRowNameExport(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\y0data\database\", @"F:\Extracted\ESO\y0defnames\");
                //DefRowNameExport(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\badlandsdata3\000\a\", @"F:\Extracted\ESO\bwdefnames\");
                //DefRowNameExport(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\tudata\database\", @"F:\Extracted\ESO\tudefnames\");
                //DefRowNameExport(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\icdata\database\", @"F:\Extracted\ESO\defnames\ic\");
                //CopyToc(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\y0\world\", @"F:\Extracted\ESO\y0toc\");
                //CopyToc(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\badlandsworld\", @"F:\Extracted\ESO\bwtoc\");
                //CopyToc(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\icdata\world\", @"F:\Extracted\ESO\toc\ic\");
                //CopyToc(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\tudata\world\", @"F:\Extracted\ESO\toc\tu\");

                /*
                Def tilemaps = new Def(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\y0data\database\6000000000000044_Uncompressed.EsoFileData", typeof(DefPointOfInterest));
                using(TextWriter w = new StreamWriter(File.Open(@"F:\Extracted\ESO\y0tilemaps.txt", FileMode.Create))) {
                    for(int i = 0; i < tilemaps.rows.Length; i++) {
                        DefPointOfInterest tilemap = (DefPointOfInterest)tilemaps.rows[i].data;
                        if(tilemap.name.Length > 0) w.WriteLine($"{tilemap.type}|{tilemap.id}|{tilemap.name}");
                    }
                }
                */
                //Console.WriteLine( Util.WorldCellFilename(494, 21, 9, 9));

                /*
                Def worlds = new Def(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\y0data\database\600000000000003C_Uncompressed.EsoFileData");
                foreach(string path in Directory.EnumerateFiles(@"F:\Extracted\ESO\y0toc")) {
                    uint id = UInt32.Parse(Path.GetFileNameWithoutExtension(path));
                    string toPrint = id.ToString();
                    for(int i = 0; i < worlds.rows.Length; i++) {
                        if(worlds.rows[i].data.id == id) {
                            toPrint = $"{id} {worlds.rows[i].data.name}";
                            break;
                        }
                    }
                    Console.WriteLine(toPrint);
                }
                */

                /* (TextWriter writer = new StreamWriter(File.Open(@"F:\Extracted\ESO\y0fixturefiles.txt", FileMode.Create))) {
                    foreach (string path in Directory.EnumerateFiles(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\icdata\world", "*.dat", SearchOption.AllDirectories)) {
                        if (Path.GetFileName(path).StartsWith("4000")) {
                            string name = Util.WorldFileDesc(UInt64.Parse(Path.GetFileNameWithoutExtension(path), System.Globalization.NumberStyles.HexNumber));
                            if (name.Contains("fixture")) File.Copy(path, @"F:\Extracted\ESO\fixturefile\ic\" + name);
                        }
                    }
                //}
                */

                /*
                HashSet<string> y0 = new HashSet<string>();
                foreach (string path in Directory.EnumerateFiles(@"F:\Extracted\ESO\fixturefile\tu")) y0.Add(Path.GetFileName(path));
                foreach(string path in Directory.EnumerateFiles(@"F:\Extracted\ESO\fixturefile\ic")) {
                    string name = Path.GetFileName(path);
                    if(y0.Contains(name)) {
                        FileInfo newInfo = new FileInfo(path);
                        FileInfo oldInfo = new FileInfo(@"F:\Extracted\ESO\fixturefile\tu\" + name);
                        if(Math.Abs(newInfo.Length - oldInfo.Length) > 1023) {
                            Console.WriteLine($"{name} {(newInfo.Length - oldInfo.Length) / 1024}");
                        }
                    } else {
                        FileInfo newInfo = new FileInfo(path);
                        Console.WriteLine($"{name} {newInfo.Length / 1024} (NEW)");
                    }
                }
                */

                
                var paths = Util.LoadWorldFiles(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\y0\world");
                //@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\y0\world"
                //CopyCellFiles(426, paths);

                for (uint i = 50; i < 1300; i++) {
                    if (paths.ContainsKey(Util.WorldTocID(i))) {
                        Console.WriteLine(i);
                        ExportTerrainCols(i, paths);
                    }
                }
                

                //ExportTerrainCols(575, paths);
                /*
                var heights = f.GetHeights();
                for(int i = 0; i < 65; i++) {
                    Console.Write(heights[i, 0]);
                    Console.Write(' ');
                }
                */

            }

        static void ExportZoneColors() {
            int cellHeight = 32;
            int cellWidth = 384;
            Def zones = new Def(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\badlandsdata3\000\a\6000000000000032_Uncompressed.EsoFileData", typeof(DefZone));
            MagickImage image = new MagickImage(MagickColors.White, cellWidth, cellHeight * zones.rows.Length);
            for (int i = 0; i < zones.rows.Length; i++) { //zones.rows.Length
                DefZone zone = (DefZone)zones.rows[i].data;

                image.Draw(new Drawables()
                    .StrokeColor(MagickColors.Transparent)
                    .FillColor(MagickColor.FromRgb((byte)(zone.color[0] * 255), (byte)(zone.color[1] * 255), (byte)(zone.color[2] * 255)))
                    .Rectangle(0, i * cellHeight, cellWidth, i * cellHeight + cellHeight)
                    .FontPointSize(24)
                    .StrokeWidth(.5)
                    .StrokeColor(MagickColors.Black)
                    .Font("Arial", FontStyleType.Any, FontWeight.Bold, FontStretch.Any)
                    .FillColor(MagickColors.White)
                    .Text(8, i * cellHeight + 26, zone.name));
                Console.WriteLine($"{zone.name} {(byte)(zone.color[0] * 255)} {(byte)(zone.color[1] * 255)} {(byte)(zone.color[2] * 255)}");
            }
            image.Write("test.png");
        }

        static void ExportTerrainCols(uint worldID, Dictionary<UInt64, string> paths, int sectionID = 1, int sectionSize = 128) {
            Toc t = Toc.Read(paths[Util.WorldTocID(worldID)]);
            Layer l = t.layers[1];
            MagickImageCollection images = new MagickImageCollection();
            //MagickReadSettings settings = new MagickReadSettings() { Width = 512, Height = 512, BackgroundColor = MagickColors.Black, ColorSpace = ColorSpace.RGB };
            for (uint y = 0; y < l.cellsY; y++) {
                for (uint x = 0; x < l.cellsX; x++) {
                    if (paths.ContainsKey(Util.WorldCellID(worldID, 1, x, y))) {
                        TerrainFile f = new TerrainFile(new BinaryReader(File.OpenRead(paths[Util.WorldCellID(worldID, 1, x, y)])));
                        if (sectionID == 8 && f.layers[7] != null) {
                            sectionID = 7;
                        }
                        if (f.layers[sectionID] == null) {
                            images.Add(new MagickImage(MagickColors.Transparent, sectionSize, sectionSize));
                            continue;
                        }
                        byte[] data = f.GetLayerBytes(sectionID);
                        PixelReadSettings settings = new PixelReadSettings(f.layers[sectionID].rows.Length, f.layers[sectionID].rows.Length, StorageType.Char, PixelMapping.RGBA);
                        MagickImage image = new MagickImage(data, settings);
                        image.Alpha(AlphaOption.Opaque);
                        images.Add(image);
                    } else images.Add(new MagickImage(MagickColors.Pink, sectionSize, sectionSize));
                }
            }

            var montage = images.Montage(new MontageSettings() { Geometry = new MagickGeometry(sectionSize), TileGeometry = new MagickGeometry((int)l.cellsX, (int)l.cellsY), Gravity = Gravity.Southwest, BackgroundColor = MagickColors.Transparent });
            //montage.BackgroundColor = MagickColors.Transparent;
            Console.WriteLine("saving...");
            montage.Write(string.Format(@"F:\Extracted\ESO\terrain\cols\{0:0000}_cols_{1}x{2}.png", worldID, montage.Width, montage.Height));
            //int resize = Math.Max(NextPow2(montage.Width) + 1, NextPow2(montage.Height) + 1);
            //montage.Extent(resize, resize, Gravity.Southwest);

            //montage.Write(string.Format(@"F:\Extracted\ESO\heights\{0:0000}_height_{1}x{2}.gray", worldID, montage.Width, montage.Height));

            for (int i = images.Count - 1; i >= 0; i--) images[i].Dispose();
            images.Dispose();


        }

        static void CopyToc(string worldPath, string outPath) {
            foreach (string path in Directory.EnumerateFiles(worldPath, "44*.dat", SearchOption.AllDirectories)) {
                File.Copy(path, outPath + Util.WorldFileDesc(UInt64.Parse(Path.GetFileNameWithoutExtension(path), System.Globalization.NumberStyles.HexNumber)));
            }
        }

        static void DefRowNameExport(string folder, string outFolder) {
            foreach(string path in Directory.EnumerateFiles(folder, "*.EsoFileData")) {
                Console.WriteLine(Path.GetFileNameWithoutExtension(path));
                Def d = new Def(path);
                using (TextWriter w = new StreamWriter(File.Open(outFolder + Path.GetFileNameWithoutExtension(path) + ".txt", FileMode.Create))) {
                    for(int i = 0; i < d.rows.Length; i++) {
                        if(d.rows[i].data.name.Length > 0)
                        w.WriteLine(d.rows[i].data.id + "\t" + d.rows[i].data.name);
                    }
                }
            }
        }

        static void ListPOI() {
            Dictionary<uint, string> poiNames = new Dictionary<uint, string>();
            Dictionary<uint, string> objectiveText = new Dictionary<uint, string>();
            Dictionary<uint, string> objectiveCompleteText = new Dictionary<uint, string>();

            using (TextReader r = new StreamReader(File.OpenRead(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\badlandsdata3\gamedata\lang\en.lang.csv"))) {
                while(r.Peek() != -1) {
                    string[] words = r.ReadLine().Split(new char[] { '"' }, StringSplitOptions.RemoveEmptyEntries);
                    if (words[0] == "10860933") {
                        poiNames[UInt32.Parse(words[4])] = words[8];
                        //Console.WriteLine(words[2] + words[4]);
                    } else if (words[0] == "129979412") {
                        objectiveText[UInt32.Parse(words[4])] = words[8];
                        //Console.WriteLine(words[2] + words[4]);
                    } else if (words[0] == "108566804") {
                        objectiveCompleteText[UInt32.Parse(words[4])] = words[8];
                        //Console.WriteLine(words[2] + words[4]);
                    } 
                }
            }
            Def pois = new Def(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\badlandsdata3\000\a\600000000000004A_Uncompressed.EsoFileData", typeof(DefPointOfInterest));
            using (TextWriter w = new StreamWriter(File.Open("poitext.csv", FileMode.Create))) {
                for(int i = 0; i < pois.rows.Length; i++) {
                    var poi = (DefPointOfInterest)pois.rows[i].data;
                    uint id = poi.id;
                    w.WriteLine($"{id}\t{poi.type}\t{poiNames[id]}");
                    //if (objectiveText.ContainsKey(id) && objectiveCompleteText.ContainsKey(id)) {
                    //    w.WriteLine($"{id}\t{poi.type}\t{poiNames[id]}\t{objectiveText[id]}\t{objectiveCompleteText[id]}");
                    //}
                }
            }
   
            
        }

        

        static void PrintBVH(uint worldID, Dictionary<UInt64, string> paths) {
            Toc t = Toc.Read(paths[Util.WorldTocID(worldID)]);
            Layer l = t.layers[21];
            for (uint y = 0; y < l.cellsY; y++) {
                for (uint x = 0; x < l.cellsX; x++) {
                    if (!paths.ContainsKey(Util.WorldCellID(worldID, 21, x, y))) continue;
                    FixtureFile f = new FixtureFile(new BinaryReader(File.OpenRead(paths[Util.WorldCellID(worldID, 21, x, y)])));
                    Console.WriteLine($"{ x},{y}:\n");
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
            montage.Write(string.Format(@"F:\Extracted\ESO\heights\{0:0000}_height_{1}x{2}.png", worldID, montage.Width, montage.Height));
            int resize = Math.Max(NextPow2(montage.Width) + 1, NextPow2(montage.Height) + 1);
            montage.Extent(resize, resize, Gravity.Southwest);
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
