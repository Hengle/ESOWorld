using System;
using System.Collections.Generic;
using ESOWorld;
using ImageMagick;
using System.IO;

namespace ESOWorldTests {
    class Program {

        struct Size {
            public uint x;
            public uint y;
        }

        static void Main(string[] args) {

            //CreateZoneMap(@"F:\Extracted\ESO\screenshots\screenshot_220129_224108.png", @"F:\Extracted\ESO\screenshots\screenshot_220129_224142.png", "", "goldcoast_base.png");
            //DefRowNameExport(@"F:\Extracted\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\atpts\000", @"F:\Extracted\ESO\defnames\atpts\");

            //DefIdCheck();

            /*
            foreach(var file in Directory.EnumerateFiles(@"F:\Extracted\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\foadata\000", "*.EsoIdData")) {
                DefIndexFile indexFile = DefIndexFile.Read(file);
                Console.WriteLine(Path.GetFileNameWithoutExtension(file) + "\t" + indexFile);
            }
            Console.WriteLine();

            foreach (var file in Directory.EnumerateFiles(@"F:\Extracted\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlnewlife\000", "*.EsoIdData")) {
                DefIndexFile indexFile = DefIndexFile.Read(file);
                Console.WriteLine(Path.GetFileNameWithoutExtension(file) + "\t" + indexFile);
            }
            */

            //foreach(var file in Directory.EnumerateFiles(@"F:\Extracted\ESO\defnames\dlnewlife")) {
            //    string[] lines = File.ReadAllLines(file);
            //    if(lines.Length != 0)
            //    Console.WriteLine($"{Path.GetFileNameWithoutExtension(file)}\t{lines[lines.Length-1]}");
            //}


            Lang a = new Lang(@"F:\Extracted\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\atpts\gamedata\lang\en.lang");
            //DefRowNameExport(@"F:\Extracted\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\hiannounce\000\", @"F:\Extracted\ESO\defnames\hiannounce\");
            Lang b = new Lang(@"F:\Extracted\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\hiannounce\gamedata\lang\en.lang");
            Lang.Compare(a, b, "compatpts.txt");

            //a.ToCsv(@"F:\Extracted\ESO\dllang.csv");


            //Lang b = new Lang(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlr2\gamedata\lang\en.lang");
            //Lang.Compare(a, b);

            //ListUnusedZosft(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dl2m.txt", @"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\zosft.txt");
            //CreateHiddenWorldspaceList(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlrelease2.txt", @"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlhiddenworldspacenew.txt");
            //FixtureSizeMap(1233, 32, @"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlhiddenworldspacenew.txt", true);
            //FixtureSizeMap(31, 20);

            /*
            Dictionary<uint, Size> worldSizes = new Dictionary<uint, Size>();
            foreach (string line in File.ReadAllLines(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlhiddenworld.txt")) {
                Util.WorldFileData file = new Util.WorldFileData( UInt64.Parse(line.Split('\t')[0], System.Globalization.NumberStyles.HexNumber));
                if(file.type == 1 && file.layer == 1) {
                    if(!worldSizes.ContainsKey(file.worldID)) {
                        worldSizes[file.worldID] = new Size() { x = file.x, y = file.y };
					} else {
                        if (worldSizes[file.worldID].x < file.x) worldSizes[file.worldID] = new Size() { x = file.x, y = worldSizes[file.worldID].y };
                        if (worldSizes[file.worldID].y < file.y) worldSizes[file.worldID] = new Size() { y = file.y, x = worldSizes[file.worldID].x };
                    }
				}
            }
            foreach(uint world in worldSizes.Keys) {
                Console.WriteLine($"{world}|{worldSizes[world].x * 100}|{worldSizes[world].y * 100}");
			}
            */




            //foreach (string line in File.ReadAllLines(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlhiddenworld.txt")) {
            //    string[] words = line.Split('\t');
            //    Console.WriteLine($"{Util.WorldFileDesc(UInt64.Parse(words[0], System.Globalization.NumberStyles.HexNumber))}|{words[2]}");
            //}

            /*
            foreach (string line in File.ReadAllLines(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\zosftdl.txt")) {
                string[] words = line.Split('|');
                if (words.Length != 2) {
                    Console.WriteLine($"NOT 2 WORDS {line}");
                    continue;
                }
                if (!File.Exists(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlpts" + words[1]))  Console.WriteLine($"{uint.Parse(words[0], System.Globalization.NumberStyles.HexNumber)}|{words[1]}");
            }
            */
            //Lang wfl = new Lang(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\wfpts\gamedata\lang\en.lang");
            //wfl.ToCsv("wfcsv.txt");
            //Lang y0l = new Lang(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\y0\gamedata\lang\en.lang");
            //y0l.ToCsv("y0csv.txt");

            //ExportZoneLoadscreens();
            /*
            Def mats = new Def(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\wfpts\database\6000000000000050_Uncompressed.EsoFileData", typeof(DefItemPartMaterial));
            using(TextWriter w = new StreamWriter(File.Open("equipmenttex.txt", FileMode.Create))) {
                for (int i = 0; i < mats.rows.Length; i++) {
                    DefItemPartMaterial mat = (DefItemPartMaterial)mats.rows[i].data;
                    string name = mat.name.Length == 30 ? mat.name + "..." : mat.name;
                    if (mat.id1 != 0) w.WriteLine($"{mat.id1} {name}_diff");
                    if (mat.id2 != 0) w.WriteLine($"{mat.id2} {name}_norm");
                    if (mat.id3 != 0) w.WriteLine($"{mat.id3} {name}_spec");
                    if (mat.id4 != 0) w.WriteLine($"{mat.id4} {name}_tint");
                }
            }
            *//*
            
            Lang l = new Lang(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlpts\gamedata\lang\en.lang");
            Def zones = new Def(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlpts\000\6000000000000032_Uncompressed.EsoFileData", typeof(DefZone));
            Def worlds = new Def(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlpts\000\600000000000003C_Uncompressed.EsoFileData");
            for (int i = 0; i < zones.rows.Length; i++) { //zones.rows.Length
                DefZone zone = (DefZone)zones.rows[i].data;
                Console.WriteLine($"{zone.id}|{worlds.Get(zone.worldID).id}|{zone.loadingScreenID}|{zone.name}|{l.GetName(zone.id, Lang.Entry.Zone)}|{worlds.GetName(zone.parentWorldID)}|{l.GetName(zone.id, Lang.Entry.ZoneLoadScreenText)}");
                //Console.WriteLine($"{zone.id}|{l.GetName(zone.id, Lang.Entry.Zone)}|{l.GetName(zone.id, Lang.Entry.ZoneLoadScreenText)});
            }
            */

            /*
            Lang l = new Lang(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\newlang\gamedata\lang\en.lang");
            Def sets = new Def(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\badlandsdata3\000\a\6000000000000016_Uncompressed.EsoFileData", typeof(DefSet));
            for(int i = 0; i < sets.rows.Length; i++) {
                DefSet set = (DefSet)sets.rows[i].data;
                string name = l.GetName(set.id, Lang.Entry.Set);
                string type = set.type.ToString();
                if (set.category == 86) type = "Mythic";
                else if (set.category == 83 || set.category == 84 || set.category == 85) type = "PVP";
                //Console.Write($"{set.id}^{name}^{set.type}^{set.category}^{l.GetName(set.category, Lang.Entry.SetCategory)}^");
                Console.WriteLine($"{set.id}^{type}^{set.category}");

                string effect = set.GetEffectDescription(1, l, $"{set.id}^{type}^{set.category}^{l.GetName(set.category, Lang.Entry.SetCategory)}^{name}^1 item: ");
                if (effect != "") Console.Write(effect);
                
                for (int pieces = 2; pieces < 6; pieces++) {
                    effect = set.GetEffectDescription(pieces, l, $"{set.id}^{type}^{set.category}^{l.GetName(set.category, Lang.Entry.SetCategory)}^{name}^{pieces} items: ");
                    if (effect != "") Console.Write(effect);
                }
                //Console.WriteLine();
            }
            */

            /*
            Lang l = new Lang(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlpts\gamedata\lang\en.lang");
            Def zones = new Def(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlpts\000\6000000000000032_Uncompressed.EsoFileData", typeof(DefZone));
            Def worlds = new Def(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlpts\000\600000000000003C_Uncompressed.EsoFileData", typeof(DefWorld));
            Def maps = new Def(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlpts\000\6000000000000048_Uncompressed.EsoFileData", typeof(DefMap));
            
            for (int i = 0; i < maps.rows.Length; i++) {
                DefMap map =  (DefMap) maps.rows[i].data;
                if (map.zoneID == 0) continue;
                var zoneRow = zones.Get(map.zoneID);
                if (zoneRow == null) continue;
                DefZone zone = (DefZone)zoneRow.data;
                DefWorld world = (DefWorld)worlds.Get(zone.worldID).data;

                uint fullRes = map.tilesX * map.tileRes;
                Console.WriteLine($"{l.GetName(zone.id, Lang.Entry.Zone)}|{world.width}|{world.height}|{(zone.offsetX - map.offsetX)*fullRes*2f/map.sizeX}|{(zone.offsetY - map.offsetY)*fullRes*2f/map.sizeY}|{fullRes*2*zone.scaleX/map.sizeX}|{fullRes*2*zone.scaleY/map.sizeY}");
            }
            */

            //for (int i = 0; i < zones.rows.Length; i++) { //zones.rows.Length
            //    DefZone zone = (DefZone)zones.rows[i].data;
            //    DefWorld world = (DefWorld)worlds.Get(zone.worldID).data;
            //    Console.WriteLine($"{zone.id}|{world.id}|{zone.name}|{l.GetName(zone.id, Lang.Entry.Zone)}|{worlds.GetName(zone.parentWorldID)}|{world.width}|{world.height}|{zone.scaleX}|{zone.scaleY}|{zone.offsetX/100}|{zone.offsetY/100}");
            //Console.WriteLine($"{zone.id}|{worlds.Get(zone.worldID).id}|{zone.name}|{l.GetName(zone.id, Lang.Entry.Zone)}|{worlds.GetName(zone.parentWorldID)}");
            //}

            //Console.WriteLine(Util.WorldCellFilename(43, 21, 6, 12));
            //var paths = Util.LoadWorldFiles();
            //HeightMontage(43, paths);

            //var paths = Util.LoadWorldFiles();
            //HeightMontage(475, paths);

            //Def zones = new Def(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\badlandsdata3\000\a\6000000000000032_Uncompressed.EsoFileData", typeof(DefZone));

            //var paths = Util.LoadWorldFiles(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlpts\world\");
            //LodMontage(1173, paths);
            //LodMontage(1193, paths);


            /*
            Def quests = new Def(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlpts\000\600000000000000A_Uncompressed.EsoFileData", typeof(DefQuest));

            TextWriter w = new StreamWriter(File.Open("quests.csv", FileMode.Create));
            Lang l = new Lang(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlpts\gamedata\lang\en.lang");
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


            /*

            ListPOI();

            HashSet<uint> hiddenIDs = new HashSet<uint>();
            foreach (string line in File.ReadAllLines(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\hiddentoc.txt")) {
                hiddenIDs.Add((uint)(ulong.Parse(line, System.Globalization.NumberStyles.HexNumber) & 0xffffffff));

            }

            Def tilemaps = new Def(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlpts\000\6000000000000044_Uncompressed.EsoFileData", typeof(DefDataWorldTileMap));
            using(TextWriter w = new StreamWriter(File.Open(@"F:\Extracted\ESO\y0tilemaps.txt", FileMode.Create))) {
                for(int i = 0; i < tilemaps.rows.Length; i++) {
                    DefDataWorldTileMap tilemap = (DefDataWorldTileMap)tilemaps.rows[i].data;
                    if (hiddenIDs.Contains(tilemap.worldID)) Console.WriteLine($"{tilemap.worldID}|{tilemap.name}");
                    //if(tilemap.name.Length > 0) w.WriteLine($"{tilemap.type}|{tilemap.id}|{tilemap.name}");
                }
            }
            */

            //Console.WriteLine( Util.WorldCellFilename(494, 21, 9, 9));


            /*            
            Dictionary<uint, List<string>> book2bookcaselookup = new Dictionary<uint, List<string>>();
            Lang l = new Lang(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlpts\gamedata\lang\en.lang");
            Def clickables = new Def(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlpts\000\60000000000000b0_Uncompressed.EsoFileData", typeof(DefClickable));
            for (int i = 0; i < clickables.rows.Length; i++) {
                DefClickable clickable = (DefClickable)clickables.rows[i].data;
                if (clickable.books.Length < 2) continue;
                //Console.Write(clickable.name + "|");
                //Array.Sort(clickable.books);
                for(int j = 0; j < clickable.books.Length; j++) {
                    //Console.Write(l.GetName(clickable.books[j], Lang.Entry.BookTitle) + "|");

                    if (!book2bookcaselookup.ContainsKey(clickable.books[j])) book2bookcaselookup[clickable.books[j]] = new List<string>();

                    string shortName = clickable.name.Substring(0, clickable.name.Length - 2);
                    for (int k = 0; k < book2bookcaselookup[clickable.books[j]].Count; k++)
                        if (book2bookcaselookup[clickable.books[j]][k].StartsWith(shortName))
                            goto End;
					
                    book2bookcaselookup[clickable.books[j]].Add(clickable.name);
                    End:;
				}
                //Console.WriteLine();
            }
            
           

            foreach (uint bookId in book2bookcaselookup.Keys) {
                Console.Write($"{bookId}|{l.GetName(bookId, Lang.Entry.BookTitle)}|");
                //foreach (string clickable in book2bookcaselookup[bookId]) Console.Write(clickable + "|");
                Console.WriteLine();
			}
            */

            /*
            
            HashSet<string> bgsbooks = new HashSet<string>(File.ReadAllLines(@"E:\Anna\Desktop\bgsbooks2.txt"));
            HashSet<string> mwbooks = new HashSet<string>(File.ReadAllLines(@"E:\Anna\Desktop\uespbook\tes3.txt"));
            HashSet<string> obbooks = new HashSet<string>(File.ReadAllLines(@"E:\Anna\Desktop\uespbook\tes4.txt"));
            HashSet<string> skbooks = new HashSet<string>(File.ReadAllLines(@"E:\Anna\Desktop\uespbook\tes5.txt"));

            //foreach (string line in File.ReadAllLines(@"E:\Anna\Desktop\bgsbooks2.txt")) bgsbooks.Add(line);
            HashSet<string> esoBooks = new HashSet<string>(File.ReadAllLines(@"E:\Anna\Desktop\esoextra.txt"));
            HashSet<string> esoOOGBooks = new HashSet<string>(File.ReadAllLines(@"E:\Anna\Desktop\esooog.txt"));

            HashSet<string> esoLorespace = new HashSet<string>(File.ReadAllLines(@"E:\Anna\Desktop\uespbook\esolorespace.txt"));

            var zosft = ReadZosft();
            Lang l = new Lang(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlnewlife\gamedata\lang\en.lang");
            Def books = new Def(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlnewlife\000\6000000000000097_Uncompressed.EsoFileData", typeof(DefBook));
            for (int i = 0; i < books.rows.Length; i++) {
                DefBook book = (DefBook)books.rows[i].data;
                esoBooks.Add(l.GetName(book.id, Lang.Entry.BookTitle));
                //continue;
                //if (!l.GetName(book.id, Lang.Entry.BookTitle).StartsWith("Crafting Motif")) {
                string icon = zosft.ContainsKey(book.iconAsset) ? zosft[book.iconAsset] : "UNK";
                string title = l.GetName(book.id, Lang.Entry.BookTitle);
                string lorespace = esoLorespace.Contains(title) ? "Y" : "N";
                if (lorespace == "Y") esoLorespace.Remove(title);
                Console.WriteLine($"{lorespace}|{book.id}|{book.monsterID}|{book.fontOrBackground}|{icon}|{book.isLorebook}|{book.hideTitle}|{title}|{book.name}|{book.updateTag}|{l.GetName(book.collectionID, Lang.Entry.BookCollection)}");

                //}
            }
            foreach (string title in esoLorespace) Console.WriteLine($"Y||||||{title}");
            */

            /*
            foreach(string line in File.ReadAllLines(@"E:\Anna\Desktop\books2.txt")) {
                string prefix = "0NK";
                if (bgsbooks.Contains(line)) prefix = "2DF";
                else if (mwbooks.Contains(line)) prefix = "3MW";
                else if (obbooks.Contains(line)) prefix = "4OB";
                else if (skbooks.Contains(line)) prefix = "5SK";
                else if (esoBooks.Contains(line)) prefix = "6ON";
                else if (esoOOGBooks.Contains(line)) prefix = "7WB";
                Console.WriteLine($"{prefix}|{line}");
            }
            */

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

            /*
            var paths = Util.LoadWorldFiles(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlpts\world");
            //@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\y0\world"
            //CopyCellFiles(426, paths);

            for (uint i = 1171; i < 1300; i++) {
                if (paths.ContainsKey(Util.WorldTocID(i))) {
                    Console.WriteLine(i);
                    ExportTerrainCols(i, paths);
                }
            }
            */

            //ExportTerrainCols(575, paths);
            /*
            var heights = f.GetHeights();
            for(int i = 0; i < 65; i++) {
                Console.Write(heights[i, 0]);
                Console.Write(' ');
            }
            */

            //CreateZoneMap(@"F:\Extracted\ESO\screenshots\wslight.png", @"F:\Extracted\ESO\screenshots\wsmask.png", "", "testskr.tga");





        }


        static void CreateHiddenWorldspaceList(string mnfdump, string output) {
            using(TextWriter writer = new StreamWriter(File.Create(output))) {
                foreach (string line in File.ReadAllLines(mnfdump)) {
                    if (line.Contains("hiddenWorldspace")) {
                        string[] words = line.Split('\t');
                        writer.WriteLine($"{Util.WorldFileDesc(ulong.Parse(words[0], System.Globalization.NumberStyles.HexNumber))}|{words[2]}");
					}
                }
            }

		}

        static void CreateZoneMap(string lightingPath, string maskPath, string lodPath, string outName) {

            
            MagickColor colorWater = MagickColor.FromRgb(47, 50, 56);



            MagickImage mask = new MagickImage(maskPath);
            int imageWidth = mask.Width; int imageHeight = mask.Height;
            //mask.FilterType = FilterType.Triangle;
            //mask.Resize(imageWidth, imageHeight);
            MagickImageCollection masks = new MagickImageCollection(mask.Separate(Channels.RGB));



            MagickImage lighting = new MagickImage(lightingPath);
            //lighting.FilterType = FilterType.Triangle;
            //lighting.Resize(imageWidth, imageHeight);




            Console.WriteLine("loaded images...");

            lighting.Level(20, 255);
            MagickImage finalImage = new MagickImage(lodPath);
           
            MagickImage water = new MagickImage(colorWater, imageWidth, imageHeight);
            water.Composite(masks[2], CompositeOperator.CopyAlpha);
            Console.WriteLine("water...");


            MagickImage buildings = new MagickImage(MagickColors.White, imageWidth, imageHeight);
            buildings.Composite(masks[0], CompositeOperator.CopyAlpha);

            MagickImage shadows = new MagickImage(MagickColors.Black, imageWidth, imageHeight);
            shadows.Composite(masks[0], CompositeOperator.CopyAlpha);
            Console.WriteLine("blurring...");
            shadows.Blur(0, 4.5, Channels.Alpha);

            Console.WriteLine("buildings...");


            finalImage.Composite(water, CompositeOperator.Over);
            finalImage.Composite(shadows, CompositeOperator.Over);
            //finalImage.Composite(shadows, CompositeOperator.Over);
            finalImage.Composite(buildings, CompositeOperator.Over);

            finalImage.Composite(lighting, CompositeOperator.Multiply);


            Console.WriteLine("saving...");
            finalImage.Write(outName);
            Console.WriteLine("done.");


        }

        static void ListUnusedZosft(string mnfdump, string zosftdump) {
            Dictionary<ulong, byte> mnf = new Dictionary<ulong, byte>();
            foreach (string line in File.ReadAllLines(mnfdump)) {
                string[] words = line.Split('\t');
                if (words[0].Length > 13) continue;
                mnf[ulong.Parse(words[0])] = byte.Parse(words[1]);
			}

            foreach (string line in File.ReadAllLines(zosftdump)) {
                string[] words = line.Split('|');
                ulong id = ulong.Parse(words[0], System.Globalization.NumberStyles.HexNumber);
                if (!mnf.ContainsKey(id)) Console.WriteLine("MISSING " + words[1]);
                else if (mnf[id] > 237) Console.WriteLine($"HIDDEN {words[1]} {mnf[id]}");
            }
		}

        static Dictionary<uint, string> ReadZosft(string path = @"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\zosftdl.txt") {
            Dictionary<uint, string> paths = new Dictionary<uint, string>();
            foreach (string line in File.ReadAllLines(path)) {
                string[] words = line.Split('|');
                if (words.Length != 2) {
                    Console.WriteLine($"NOT 2 WORDS {line}");
                    continue;
                }
                paths[UInt32.Parse(words[0], System.Globalization.NumberStyles.HexNumber)] = words[1];
            }
            return paths;
        }
        static void FixtureSizeMap (uint id, int size, string path, bool grass = false, string name = "") {

            int[] sizes = new int[size * size];

            int max = 0;
            foreach (string line in File.ReadAllLines(path)) {
                if (!grass && !line.StartsWith($"{id}_fixtures_")) continue;
                if (grass && !line.StartsWith($"{id}_grass_")) continue;
                int fileSize = int.Parse(line.Split('|')[1]);
                int x = int.Parse(line.Split('_')[2]);
                int y = int.Parse(line.Split('_', '.')[3]);
                sizes[x + size * y] = fileSize;
                if (fileSize > max) max = fileSize;
            }

            byte[] data = new byte[size * size];
            for (int i = 0; i < data.Length; i++) {
                data[i] = (byte)((sizes[i] * 255) / max);
            }

            MagickReadSettings settings = new MagickReadSettings() { Width = size, Height = size, Format = MagickFormat.Gray, Depth = 8 };
            MagickImage image = new MagickImage(data, settings);
            if (name == "") name = grass ? id.ToString() + "_grass" : id.ToString() + "_fixtures";
            image.Write($"{name}.png");
        }
        static void ExportZoneLoadscreens() {
            int cellHeight = 66;
            int cellWidth = 433;
            int cellsY = 64;
            Lang l = new Lang(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlpts\gamedata\lang\en.lang");
            Def zones = new Def(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlpts\000\6000000000000032_Uncompressed.EsoFileData", typeof(DefZone));
            MagickImage image = new MagickImage(MagickColors.Black, cellWidth * (zones.rows.Length / cellsY + 1), cellHeight * cellsY);
            //MagickImage zero = new MagickImage();
            int pos = 0;
            
            for (int i = 0; i < zones.rows.Length; i++) { //zones.rows.Length
                DefZone zone = (DefZone)zones.rows[i].data;
                if (zone.loadingScreenID == 0) continue;
                MagickImage loadscreen = new MagickImage($@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\wfpts\loadscreen\small\{zone.loadingScreenID}.png");
                loadscreen.Resize(105, 66);
                //MagickImage loadscreen = zone.loadingScreenID != 0 ?
                //    new MagickImage($@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\wfpts\loadscreen\small\{zone.loadingScreenID}.png") :
                //    zero;
                image.Draw(new Drawables()
                    .Composite(cellWidth * (pos / cellsY), cellHeight * (pos % cellsY), loadscreen)
                    .FontPointSize(20)
                    .Font("Arial", FontStyleType.Any, FontWeight.Bold, FontStretch.Any)
                    .FillColor(MagickColors.White)
                    .Text(cellWidth * (pos / cellsY) + 113, cellHeight * (pos % cellsY) + 38, l.GetName(zone.id, Lang.Entry.Zone)));
                Console.WriteLine(zone.name);
                pos++;
            }
            //image.Resize(image.Width / 2, image.Height / 2);
            image.Write("loadscreens.png");

            /*
            Dictionary<uint, List<DefZone>> loadscreens = new Dictionary<uint, List<DefZone>>();
            for (int i = 0; i < zones.rows.Length; i++) {
                DefZone zone = (DefZone)zones.rows[i].data;
                if (loadscreens.ContainsKey(zone.loadingScreenID)) loadscreens[zone.loadingScreenID].Add(zone);
                else {
                    loadscreens[zone.loadingScreenID] = new List<DefZone>();
                    loadscreens[zone.loadingScreenID].Add(zone);
                }
            }

            var loadscreensorted = new List<uint>(loadscreens.Keys);
            loadscreensorted.Sort();
            for (int load = 0; load < loadscreensorted.Count; load++) { //zones.rows.Length
                if (loadscreens[loadscreensorted[load]].Count < 2) continue;
                for(int i = 0; i < loadscreens[loadscreensorted[load]].Count; i++) {
                    DefZone zone = loadscreens[loadscreensorted[load]][i];
                    if (zone.loadingScreenID == 0) continue;
                    MagickImage loadscreen = new MagickImage($@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\wfpts\loadscreen\small\{zone.loadingScreenID}.png");
                    //MagickImage loadscreen = zone.loadingScreenID != 0 ?
                    //    new MagickImage($@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\wfpts\loadscreen\small\{zone.loadingScreenID}.png") :
                    //    zero;
                    image.Draw(new Drawables()
                        .Composite(cellWidth * (pos / 16), cellHeight * (pos % 16), loadscreen)
                        .FontPointSize(20)
                        .Font("Arial", FontStyleType.Any, FontWeight.Bold, FontStretch.Any)
                        .FillColor(MagickColors.White)
                        .Text(cellWidth * (pos / 16) + 113, cellHeight * (pos % 16) + 38, l.GetName(zone.id, Lang.Entry.Zone)));
                    Console.WriteLine(zone.name);
                    pos++;
                }

            }
            image.Write("loadscreens.png");
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

        static void DefRowNameExport(string folder, string outFolder, Lang l = null) {
            if (!Directory.Exists(outFolder)) Directory.CreateDirectory(outFolder);
            Dictionary<uint, string> defNames = new Dictionary<uint, string>();
            foreach (string line in File.ReadAllLines(@"F:\Extracted\ESO\deftypesdl.txt")) {
                Console.WriteLine(line.Split('\t')[0]);
                defNames[UInt32.Parse(line.Split(' ')[0])] = line.Split(' ')[1];
            }

            foreach (string path in Directory.EnumerateFiles(folder, "*.EsoFileData")) {
                if (!Path.GetFileName(path).Contains("Uncompressed")) continue;
                ulong id = UInt64.Parse(Path.GetFileName(path).Split('_')[0], System.Globalization.NumberStyles.HexNumber);
                uint shortID = (uint)(id & uint.MaxValue);
                string filename = defNames.ContainsKey(shortID) ? defNames[shortID] + "_" + Path.GetFileNameWithoutExtension(path) : Path.GetFileNameWithoutExtension(path);
                Console.WriteLine(filename);
                Def d = new Def(path); 
                if (d.rows.Length == 0) continue;
                Lang.Entry[] langEntryTypes = defNames.ContainsKey(shortID) && Lang.defLangEntries.ContainsKey(defNames[shortID]) ? Lang.defLangEntries[defNames[shortID]] : new Lang.Entry[0];
                using (TextWriter w = new StreamWriter(File.Open(outFolder + filename + ".txt", FileMode.Create))) {
                    for(int i = 0; i < d.rows.Length; i++) {
                        if(d.rows[i].data.name.Length > 0)
                        w.Write(d.rows[i].data.id + " | " + d.rows[i].data.name);
                        if (l != null) for (int entry = 0; entry < langEntryTypes.Length; entry++) if (l.HasName(d.rows[i].data.id, langEntryTypes[entry])) w.Write(" | " + l.GetName(d.rows[i].data.id, langEntryTypes[entry]));
                        w.WriteLine();
                    }
                }
            }
        }

        static void DefIdCheck(int searchDepth = 100) {

            Dictionary<uint, Dictionary<uint, string>> defRowNames = new Dictionary<uint, Dictionary<uint, string>>();

            //if (!Directory.Exists(outFolder)) Directory.CreateDirectory(outFolder);
            Dictionary<uint, string> defNames = new Dictionary<uint, string>();
            foreach (string line in File.ReadAllLines(@"F:\Extracted\ESO\deftypes.txt")) {
                Console.WriteLine(line.Split('\t')[0]);
                defNames[UInt32.Parse(line.Split('\t')[1], System.Globalization.NumberStyles.HexNumber)] = line.Split('\t')[0];
            }

            foreach (string path in Directory.EnumerateFiles(@"F:\Extracted\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlnewlife\000", "*_Uncompressed.EsoFileData")) {
                ulong id = UInt64.Parse(Path.GetFileName(path).Split('_')[0], System.Globalization.NumberStyles.HexNumber);
                uint shortID = (uint)(id & uint.MaxValue);
                Console.WriteLine(shortID);
                //string filename = defmanes.ContainsKey(shortID) ? defmanes[shortID] + "_" + Path.GetFileNameWithoutExtension(path) : Path.GetFileNameWithoutExtension(path);
                //Console.WriteLine(filename);
                Def d = new Def(path);
                defRowNames[shortID] = new Dictionary<uint, string>();
                for (int i = 0; i < Math.Min(d.rows.Length, searchDepth + 20); i++) {
                    defRowNames[shortID][d.rows[i].data.id] = d.rows[i].data.name;
                }
            }
            Console.WriteLine("Done");

            HashSet<uint> newDefIdsRemaining = new HashSet<uint>();
            foreach (uint id in defRowNames.Keys) newDefIdsRemaining.Add(id);

            foreach(string path in Directory.EnumerateFiles(@"F:\Extracted\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\foadata\000", "*_Uncompressed.EsoFileData")) {
                ulong id = UInt64.Parse(Path.GetFileName(path).Split('_')[0], System.Globalization.NumberStyles.HexNumber);
                uint shortID = (uint)(id & uint.MaxValue);

                Def def = new Def(path);

                int maxScore = 0;
                uint bestFit = uint.MaxValue;

                foreach (uint key in newDefIdsRemaining) {
                    int score = 0;
                    for(int i = 0; i < Math.Min(def.rows.Length, searchDepth); i++) {
                        if (defRowNames[key].ContainsKey(def.rows[i].data.id) && defRowNames[key][def.rows[i].data.id] == def.rows[i].data.name) score++; 
                    }
                    //Console.WriteLine($"{key} {score}");
                    if(score > maxScore && (score * 2) > Math.Min(def.rows.Length, searchDepth)) {
                        maxScore = score;
                        bestFit = key;
                    }
                }
                if(bestFit != uint.MaxValue) {
                    Console.WriteLine($"{bestFit} {shortID} " + (defNames.ContainsKey(shortID) ? defNames[shortID] : "unk"));
                    newDefIdsRemaining.Remove(bestFit);
                } else {
                    Console.WriteLine($"noMatch {shortID} " + (defNames.ContainsKey(shortID) ? defNames[shortID] : "unk"));
                }
                

                //break;
            }

            foreach (var id in newDefIdsRemaining) Console.WriteLine($"{id} noMatch unknown");
        }

        static void DefGlobalExport(string folder, string outFolder) {

            char[] replacechars = new char[] { ' ', '"' };

            foreach (string path in Directory.EnumerateFiles(folder, "*.EsoFileData")) {
                if (!Path.GetFileName(path).Contains("Uncompressed")) continue;

                Def d = new Def(path);
                if (d.rows.Length != 1) continue;

                string filename = "Global_" + d.rows[0].data.name.Replace(' ', '_').Replace('"', '_') + "_" + Path.GetFileNameWithoutExtension(path);
                Console.WriteLine(filename);

                File.Copy(path, outFolder + filename + ".dat", true);
            }
        }

        static void ListPOI() {
            Dictionary<uint, string> poiNames = new Dictionary<uint, string>();
            Dictionary<uint, string> objectiveText = new Dictionary<uint, string>();
            Dictionary<uint, string> objectiveCompleteText = new Dictionary<uint, string>();

            Lang l = new Lang(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlpts\gamedata\lang\en.lang");

            /*
            using (TextReader r = new StreamReader(File.OpenRead(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlpts\gamedata\lang\en.lang.csv"))) {
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
            */
            Def pois = new Def(@"F:\Junk\Backup\BethesdaGameStudioUtils\esoapps\EsoExtractData\x64\Release\dlpts\000\600000000000004A_Uncompressed.EsoFileData", typeof(DefPointOfInterest));
            using (TextWriter w = new StreamWriter(File.Open("poitext.csv", FileMode.Create))) {
                for(int i = 0; i < pois.rows.Length; i++) {
                    var poi = (DefPointOfInterest)pois.rows[i].data;
                    uint id = poi.id;
                    w.WriteLine($"{id}\t{poi.type}\t{poi.name}\t{l.GetName(id, Lang.Entry.PointOfInterest)}\t{l.GetName(id, Lang.Entry.Objective_Text)}\t{l.GetName(id, Lang.Entry.Objective_CompleteText)}");
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
            if(resize == 8193) {
                Console.WriteLine("8193 too big, resizing to 4097");
                montage.Scale(new Percentage(50));
                montage.Extent(4097, 4097, Gravity.Southwest);
            } else {
                montage.Extent(resize, resize, Gravity.Southwest);
            }
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

    /*SHOULDNT NEED THESE ANYMORE
            
            MagickReadSettings readSettings = new MagickReadSettings() { ColorSpace = ColorSpace.RGB };
            MagickImage testImage = new MagickImage(@"E:\Anna\Desktop\test.png", readSettings);

            MagickImageCollection images = new MagickImageCollection();
            MagickImage referenceImage = new MagickImage(@"E:\Anna\Desktop\test2.png");
            referenceImage.Draw(new Drawables().FillColor(MagickColors.Black).Gravity(Gravity.Northwest).FontPointSize(16).Text(2, 2, "GIMP Cubic"));
            images.Add(referenceImage);
            for (int i = 2; i < 31; i++) {
                FilterType filter = (FilterType)i;

                MagickImage test = new MagickImage(testImage);
                test.FilterType = filter;
                test.Resize(256, 256);
                test.Draw(new Drawables().FillColor(MagickColors.Black).Gravity(Gravity.Northwest).FontPointSize(16).Text(2, 2, filter.ToString())) ;
                Console.WriteLine(filter.ToString());
                images.Add(test);
                //MagickImageCollection magickImages = new MagickImageCollection(test.Separate(Channels.Red));


                //test.Write("filter/" + filter.ToString() + ".png");
			}
            var montage = images.Montage(new MontageSettings() { Geometry = new MagickGeometry(256) });
            montage.Write("filters.png");
            

     */
}
