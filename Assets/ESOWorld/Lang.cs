using System;
using System.Collections.Generic;
using System.IO;

namespace ESOWorld {
    public class Lang {

        public enum Entry {


            //--------------------------------------------- WORLD

            Zone = 162658389,
            Zone_LoadScreenText = 70901198,
            Zone_LoadScreenText2 = 200374766,
            Subzone = 162946485,

            PointOfInterest =  10860933,
            Objective_Text = 129979412,
            Objective_CompleteText = 108566804,

            Map = 267200725,
            MapLocation = 146361138,
            MapLocation_Subheader = 51188660,
            MapLocationTooltipCategory = 76200101,
            MapKeySection = 65447205,
            MapKeySection2 = 260523861,
            ToolTip = 81344020,


            Graveyard = 28666901,
            Door_Label = 164009093,


            InteractableObject = 87370069,
            InteractableObject2 = 219936053,
            InteractableObject_Prompt = 74865733,
            InteractableObject_DialogueText = 211899940,
            InteractableObject_ActionText = 108533454,
            InteractableObject_DialogueExit = 109216308, //?

            SimpleInteractableObject = 19398485,
            SimpleInteractableObject2 = 207758933,
            SimpleInteractableObject_Prompt = 70307621,
            SimpleInteractableObject_ActionText = 8158238,
            Clickable = 39619172,
            ObjectState = 59991493,

            Monster = 8290981,
            Monster_Service = 99527054,
            Monster_InteractPrompt = 12912341,
            Monster_InteractPrompt2 = 263004526,
            Monster_GreetingDialogue = 165399380,
            Monster_Location = 207398837,
            Appearance = 191999749,





            //--------------------------------------------- CHARACTER


            Race = 143563989,
            Race2 = 224972965,
            Race_Description = 220262196,

            WeaponSet = 143811061,

            Class = 45378037,
            Class2 = 60155541,
            Class_Description = 256705124,

            SkillLine = 96962005,
            SkillLine2 = 108643301,
            SkillLine_XPDescription = 84281828,
            SkillLine_UnlockDescription = 172689156,

            SkillAdvisorBuild = 232566869,
            SkillAdvisorBuild_Description = 139757006,
            Template = 239939829,

            Ability = 198758357,
            Ability_Description = 132143172,
            Ability_Description2 = 206046340,
            Ability_MorphDescription = 50040644,
            Ability_Subheader = 196014052,
            AbilityProgressionLine = 17915077,

            ChampionSkill_Description = 102906708,
            ChampionSkill_Cluster = 87722757,
            ChampionTree = 153008933,

            //--------------------------------------------- ITEM & CRAFTING




            Item = 242841733,
            Item_Subheader = 148355781,
            Item_Description = 228378404,

            ItemTag = 41262789,
            ItemMaterial = 41983653,
            ItemMaterial_ID = 61533042,
            ItemMaterial_ID2 = 214390738,
            ItemTemplate_ID = 68494373,
            ItemProperty = 124119973,

            Set = 38727365,
            SetCategory = 121975845,
            ItemVisualStyle = 98383029,

            QuestItem = 267697733,
            QuestItemDescription = 139139780,

            Currency = 44699029,
            Currency_Plural = 151600453,
            Currency_Lower = 162144901,
            Currency_LowerPlural = 34157141,
            Currency_Description = 24991438,


            FurnitureCategory = 11547061,
            FurnitureData_Tags = 40741187,

            SmithingPattern = 200697509,
            CraftComponentTrait = 156152165,
            RecipeList = 57008677,
            SmithingResearch = 217370677,

            Siege = 124318053,


            TreasureMap = 39160885,

            Book = 51188213,
            Book_Contents = 21337012,
            BookCollection = 236931909,
            BookCollection_Description = 8379076,
            BookCollectionCategory = 112758405,

            //--------------------------------------------- SYSTEM


            MarketProduct = 112701171,
            MarketProduct_SkillLineDescription = 132595845,
            MarketProductBundle = 70328405,
            MarketProductBundle_Description = 263796174,
            MarketProductPromo = 217086453,
            MarketProductPromo_Description = 123229230,
            MarketProductCategory = 173340693,

            MotifPreview3 = 241484741,


            Holiday = 125518133,
            HolidayAnnouncement = 99281989,
            HolidayAnnouncement_Description = 249464990,

            InstantUnlockReward = 42041397,
            InstantUnlockReward_Description = 129382708,
            InstantUnlockReward_SkyshardDescription = 83548836,


            LootCrate = 124362421,
            LootCrate_Description = 249673710,
            LootCrateTierTemplate = 158979221,


            SystemMail = 219317028,
            SystemMail_Title = 191189508,
            SystemMail_Sender = 33425332,

            ChapterUpgrade_Description = 226966585, //181

            Collectible = 18173141,
            Collectible_Subheader = 96069573,
            Collectible_Description = 211640654,
            Collectible_Description2 = 52183620,
            Collectible_Tags = 171157587,
            Collectible_Tags2 = 224875171,

            CollectibleCategory = 79246725,
            Combination = 54595589,
            Reward = 216271813,

            PlayerEmote = 139475237,
            PlayerEmote_ChatCommand = 151638485,
            Dye = 208337109,

            HeraldryCrest = 238195765,
            HeraldryBackground = 210579221,
            HeraldryCategory = 59621621,
            

            Achievement_Label = 172030117,
            Achievement_Description = 188155806,
            Achievement_Title = 12529189,
            AchievementCategory = 115337253,
            Title = 87522148,
            Title2 = 186232436,
            Title_Name = 215700677,
            Title_Name2 = 221887989,



            ConsoleTrophyGroup = 51109077, //13a ???
            DLCTrophies = 203274254, //???

            Help_Title = 68561141,
            Help_Contents = 62156964,
            Help_Contents2 = 74148292,
            Help_Contents3 = 148453652,
            Help_Contents4 = 76647876,
            Help_Contents5 = 102023092,
            Help_Contents6 = 243094948,
            HelpCategory = 131421317,

            TeachableMoment_Title = 202153303,
            TeachableMoment_Title2 = 242643895,
            TeachableMoment = 26044436,
            TeachableMoment2 = 199723588,

            ActiveCombatTip = 224768149,
            ActiveCombatTip_Contents = 37288388,
            ActiveCombatTip_Contents2 = 252100948,

            LoadingTip = 235850260,
            LoadingTip2 = 168351172,

            DeathRecapHint = 86601028,

            Tutorial = 106474997,
            Tutorial_Contents = 155022052,
            Tutorial_Contents2 = 160227428,
            Tutorial_Contents3 = 112626580,

            ActivityFeed = 35111812,
            ActivityFeed2 = 191744852,

            LevelUp_Unlock = 19709733,
            LevelUp_UnlockDescription = 212113054,

            Skyshard_Description = 40552436, //official name?

            ErrorString = 41714900,
            DisplayAnnouncement = 39248996,
            DisplayAnnouncement_Subheader = 63937076,


            House_Description = 169578494,
            HouseTemplate_Subheader = 60008005,

            //Endeavor = 108643301,???
            Endeavor = 108965317,
            Endeavor_Description = 234260606,






            Raid = 111863941,

            BattleGround = 96678629,
            BattleGround_Description = 4922190,
            Medal = 58548677,
            Medal_Description = 246790420,
            LFG = 268015829,
            LFG_BattleGround = 225762485,
            LFGSet = 71931413,
            LFGSet_Description = 264355726,
            ObjectivePVP = 77659573,
            Keep = 157886597,
            KeepUpgrade = 191379205, //deprecated?
            KeepUpgrade_Description = 81761156, //deprecated?
            Campaign = 257983733,
            CampaignRuleset = 219429541,
            CampaignRuleset_Description = 144446238,

            GuildReputation = 37408565,
            GuildReputation_Title = 5759525, //unused?

            Mount = 127454222, //deprecated
            Mount2 = 204530069, //deprecated

            AdvancedStatsCategory = 130098181, //?

            OutfitSlotData = 9424005,

            Wave = 13753646,
            ClientTriggeredTrap = 14464837,
            AnchorObject = 26811173,
            SCTEventVisualInfo = 254784612,

            Antiquity = 73074773,
            Antiquity_Text =  15453358,
            Antiquity_TextAuthor = 90431749,
            AntiquityCategory = 49656629,
            AntiquitySet_Description = 121548292,



            Alliance = 116704773,
            ScriptedEvent = 168675493,

            //--------------------------------------------- QUESTS AND DIALOGUE


            Quest = 52420949,
            Quest_Journal = 265851556,
            Quest_CompanionRequirement = 76698596,

            QuestBestowal_StartDialogue = 66848564,
            QuestBestowal_StartPlayer = 249936564,
            QuestBestowal_Dialogue = 3952276,
            QuestBestowal_Player = 20958740,
            QuestBestowal_Journal = 205344756,

            QuestStep_Objective = 256430276,
            QuestStep_Journal = 103224356,

            QuestCondition_Objective = 7949764,
            QuestCondition_PlayerDeliverItem = 150525940,


            Conversation_Player = 228103012,
            Conversation_Dialogue = 200879108,
            Conversation_PlayerBranch = 204987124,
            Conversation_PlayerGoBack = 99155012,



            QuestEnding_Objective = 121487972,
            QuestEnding_Journal = 168415844,
            QuestEnding_Player = 232026500,
            QuestEnding_Dialogue = 116521668,
            QuestEnding_AmbientDialogue = 187173764,

            ZoneStoryQuestBranch_Objective = 66737390,



            ScriptActionText = 115740052,
            RandomStringTable_Dialogue  = 149328292,
            Greeting = 55049764, //uses multiple

            GenericVo01 = 75236676,
            GenericVo02 = 75237444,
            GenericVo03 = 75238212,
            GenericVo04 = 75240772,
            GenericVo05 = 75241540,
            GenericVo06 = 75242308,
            GenericVo07 = 75244868,
            GenericVo08 = 75245636,
            GenericVo09 = 75246404,
            GenericVo10 = 75248964,
            GenericVo11 = 75249732,
            GenericVo12 = 75250500,
            GenericVo13 = 75253060,
            GenericVo14 = 75253828,
            GenericVo15 = 75254596,
            GenericVo16 = 75257156,
            GenericVo17 = 75257924,
            GenericVo18 = 75258692,
            GenericVo19 = 75261252,
            GenericVo20 = 75262020,
            GenericVo21 = 75262788,
            GenericVo22 = 75265348,
            GenericVo23 = 75266116,
            GenericVo24 = 75266884,
            GenericVo25 = 149979604,
            GenericVo26 = 149983700,
            GenericVo27 = 149987796,
            GenericVo28 = 149991892,
            GenericVo29 = 149995988,
            GenericVo30 = 150000084,
            GenericVo31 = 150004180,
            GenericVo32 = 150008276,
            GenericVo33 = 150045140,
            GenericVo34 = 150049236,
            GenericVo35 = 150053332,
            GenericVo36 = 150057428,
            GenericVo37 = 150061524,
            GenericVo38 = 150065620,
            GenericVo39 = 150069716,
            GenericVo40 = 150073812,
            GenericVo41 = 150962644,
            GenericVo42 = 150966740,
            GenericVo43 = 150970836,
            GenericVo44 = 150974932,
            GenericVo45 = 150979028,
            GenericVo46 = 150983124,
            GenericVo47 = 150987220,
            GenericVo48 = 150991316,



        }

        public static Dictionary<string, Entry[]> defLangEntries = new Dictionary<string, Entry[]> {
            {"ZoneDef", new Entry[] { Entry.Zone, Entry.Zone_LoadScreenText, Entry.Zone_LoadScreenText2 } }
        };


        long textOffset;
        BinaryReader reader;
        public Dictionary<ulong, uint> offsets; // type+id -> offset

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

        public static void Compare(Lang a, Lang b, string path) {
            int percent = a.offsets.Count / 100;
            int iter = 0;
            Console.WriteLine("--------10--------20--------30--------40--------50--------60--------70--------80--------90-------100");
            using (TextWriter writer = new StreamWriter(File.Open(path, FileMode.Create))) {
                foreach (ulong id in a.offsets.Keys) {
                    if (!b.offsets.ContainsKey(id))
                        writer.WriteLine("NEW | " + a.GetLongName(id));
                    else if (a.GetName(id) != b.GetName(id))
                        writer.WriteLine("MOD | " + a.GetLongName(id) + " | " + b.GetName(id).Replace("\n", "\\n"));
                    if (++iter % percent == 0) Console.Write('*');
                }
                writer.Flush();
                Console.WriteLine();
            }
            
        }

        public bool HasName(uint id, Entry type) {
            return offsets.ContainsKey(((ulong)type << 32) + id);
        }

        string GetName(ulong key) {
            if (offsets.ContainsKey(key)) {
                reader.BaseStream.Seek(offsets[key] + textOffset, SeekOrigin.Begin);
                return reader.ReadStringNullTerminated(256);
            }
            return "";
        }

        public string GetName(uint id, Entry type, bool returnID = true) {
            string name = GetName(((ulong)type << 32) + id);
            return (name == "" && returnID) ? id.ToString() : name;
        }

        public string GetLongName(ulong id) {
            int entryType = (int)(id >> 32);
            if (Enum.IsDefined(typeof(Entry), entryType)) {
                return $"{((Entry)entryType)} | {id & uint.MaxValue} | {GetName(id).Replace("\n", "\\n")}";
            } else {
                return $"unk{entryType} | {id & uint.MaxValue} | {GetName(id).Replace("\n", "\\n")}";
            }
        }

        ~Lang() {
            if(reader != null) reader.Close();
        }

        public void ToCsv(string path) {
           
            using (TextWriter w = new StreamWriter(File.Open(path, FileMode.Create))) {
                int iter = 0;
                int percentMax = offsets.Count / 100;
                int percent = 0;
                foreach (ulong id in offsets.Keys) {
                    int shortid = (int)(id >> 32);
                    if (Enum.IsDefined(typeof(Entry), shortid)) w.Write((Entry)shortid);
                    else w.Write(shortid);
                    w.WriteLine($"\t{id & uint.MaxValue}\t{GetName(id).Replace("\n", "\\n")}");
                    if (++iter % percentMax == 0) Console.WriteLine($"{++percent}%");
                }
                w.Flush();
            }
        }
    }
}
