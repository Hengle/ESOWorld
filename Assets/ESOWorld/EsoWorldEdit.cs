using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ESOWorld;
using System.IO;
using System;
using System.Text;
using System.Diagnostics;
using Debug = UnityEngine.Debug;


public class EsoWorldEdit : MonoBehaviour
{

    public string modelPath;


    public string worldPath;
    public int worldPathCount;

    public string meshNamePath;
    public string databasePath;

    public uint worldID;

    Dictionary<ulong, string> paths;
    Dictionary<uint, string> meshnames;

    public Dictionary<uint, string> worldNames;



    //[MenuItem("Window/ESOWorld")]
    //static void Init() {
    //    EsoWorldEditorWindow window = (EsoWorldEditorWindow)EditorWindow.GetWindow(typeof(EsoWorldEditorWindow));
    //    window.Show();
    //}
    /*
    private void OnGUI() {
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Load Paths")) {
            paths = Util.LoadWorldFiles(@"E:\Extracted\ESO\Release\atpts\world");
            pathCount = paths.Count;
        }
        EditorGUILayout.IntField(pathCount);
        EditorGUILayout.EndHorizontal();
        rokmat = (Material)EditorGUILayout.ObjectField(rokmat, typeof(Material));
        worldID = (uint)EditorGUILayout.IntField("World:", (int)worldID);
        if (GUILayout.Button("Load Terrain")) {
            LoadTerrain(worldID);
        }
        if (GUILayout.Button("Import Models")) {
            GatherMeshes(worldID);
        }
        if (GUILayout.Button("Load Fixtures")) {
            LoadFixtures(worldID);
        }
        if (GUILayout.Button("Load Volumes")) {
            LoadVolumes(worldID);
        }
        if (GUILayout.Button("BVH Test")) {
            BVHTest();
        }
        if (GUILayout.Button("Persistent Test")) {
            LoadPersistentFixtures(worldID);
        }
        if (GUILayout.Button("Load Water")) {
            LoadWater(worldID);
        }
    }
    */

    public void BuildWorldNames() {
        worldNames = new Dictionary<uint, string>();
        if (databasePath == null) return;
        string defPath = Path.Combine(databasePath, "600000000000003C_Uncompressed.EsoFileData");
        if (!File.Exists(defPath)) {
            Debug.LogError(defPath + " does not exist");
            return;
        }
        Def d = new Def(defPath);
        foreach(var row in d.rows) {
            worldNames[row.data.id] = row.data.name;
        }
    }

    public void ImportTerrain() { LoadTerrain(worldID); }

    void LoadTerrain(uint worldID) {
        Toc t = Toc.Read(paths[Util.WorldTocID(worldID)]);
        Layer l = t.layers[1];

        int terrainRes = Math.Max(Util.NextPow2(64 * l.cellsX) + 1, Util.NextPow2(64 * l.cellsY) + 1);
        if(terrainRes > 4097) {
            Debug.LogError($"TERRAIN TOO BIG {terrainRes}");
            return;
		}

        float[,] fullHeights = new float[terrainRes, terrainRes];

        float maxHeight = 0;
        for (uint y = 0; y < l.cellsY; y++) {
            for (uint x = 0; x < l.cellsX; x++) {
                if (paths.ContainsKey(Util.WorldCellID(worldID, 1, x, y))) {
                    float[] heights = ReadTerrainHeights(paths[Util.WorldCellID(worldID, 1, x, y)]);
                    for (int u = 0; u < 64; u++) {
                        for (int v = 0; v < 64; v++) {
                            //aaaaaaaaaaahhhhh
                            fullHeights[terrainRes - u - 1 - y * 64, v + x * 64] = heights[u + v * 65];
                            if (heights[u + v * 65] > maxHeight) maxHeight = heights[u + v * 65];
                        }
                    }
                }
            }
        }

        //normalise heights
        for(int x = 0; x < terrainRes; x++) {
            for (int y = 0; y < terrainRes; y++) {
                fullHeights[x, y] = fullHeights[x, y] / maxHeight;
            }
        }

        TerrainData terrainData = new TerrainData();
        terrainData.heightmapResolution = terrainRes;
        terrainData.size = new Vector3(terrainRes * 100 / 64, maxHeight, terrainRes * 100 / 64);
        terrainData.SetHeights(0, 0, fullHeights);

        Terrain terrain = new GameObject($"{worldID}_TERRAIN").AddComponent<Terrain>();
        terrain.materialTemplate = Resources.Load<Material>("ROKMat");
        terrain.terrainData = terrainData;
        terrain.transform.position = new Vector3(0, 0, terrainRes * 100 / -64);
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

    public void ImportWater() { LoadWater(worldID); }
    void LoadWater(uint worldID) {
        GameObject waterPrefab = Resources.Load<GameObject>("WaterPrefab"); 
        Def tilemaps = new Def(Path.Combine(databasePath, "6000000000000044_Uncompressed.EsoFileData"), typeof(DefDataWorldTileMap));
        Def waterVolumes = new Def(Path.Combine(databasePath, "6000000000000045_Uncompressed.EsoFileData"), typeof(DefDataWaterVolume));
        for (int i = 0; i < tilemaps.rows.Length; i++) {
            DefDataWorldTileMap tilemap = (DefDataWorldTileMap)tilemaps.rows[i].data;
            if (tilemap.worldID != worldID || tilemap.type != 6 || tilemap.layers.Length == 0) continue;
            for (int l = 0; l < tilemap.layers.Length; l++) {
                var waterVolume = waterVolumes.Get(tilemap.layers[l].key);
                if (waterVolume != null) {
                    float waterHeight = ((DefDataWaterVolume)waterVolume.data).height / 100f;
                    var water = Instantiate(waterPrefab, new Vector3(500 * tilemap.x + 250, waterHeight, -500 * tilemap.y - 250), Quaternion.identity);
                    water.name = $"WATER {tilemap.x},{tilemap.y}";
                    //Console.WriteLine($"{tilemap.name} {tilemap.worldID} {tilemap.x} {tilemap.y} {tilemap.cellSizeX} {waterHeight}");
                }
            }
        }
    }

    void LoadVolumes(uint worldID) {
        GameObject fixturePrefab = Resources.Load<GameObject>("VolumePrefab");
        Toc t = Toc.Read(paths[Util.WorldTocID(worldID)]);
        Layer l = t.layers[21];
        for (uint y = 0; y < l.cellsY; y++) {
            for (uint x = 0; x < l.cellsX; x++) {
                if (paths.ContainsKey(Util.WorldCellID(worldID, 21, x, y))) {
                    FixtureFile fixtures = FixtureFile.Open(paths[Util.WorldCellID(worldID, 21, x, y)]);
                    if (fixtures.volumes.Length == 0) continue;
                    Transform cell = new GameObject($"VOLUMES {x},{y}:").transform;
                    cell.position = new Vector3(fixtures.fixtures[0].fixture.offsetX / 100, 0, fixtures.fixtures[0].fixture.offsetY / -100);
                    for (int i = 0; i < fixtures.volumes.Length; i++) {
                        GameObject o = (GameObject)Instantiate(fixturePrefab, cell);
                        o.transform.localPosition = new Vector3(fixtures.volumes[i].fixture.posX, fixtures.volumes[i].fixture.posY, fixtures.volumes[i].fixture.posZ * -1);
                        o.transform.localRotation = Quaternion.Euler(
                            (float)(fixtures.volumes[i].fixture.rotX * 180 / Math.PI),
                            (float)(fixtures.volumes[i].fixture.rotY * -180 / Math.PI + 180d),
                            (float)(fixtures.volumes[i].fixture.rotZ * -180 / Math.PI));
                        o.transform.localScale = new Vector3(fixtures.volumes[i].x, fixtures.volumes[i].y, fixtures.volumes[i].z);
                        o.name = "volume_" + fixtures.volumes[i].fixture.id.ToString();
                    }
                }
            }
        }
    }

    void BVHTest() {
        FixtureFile f = new FixtureFile(new BinaryReader(File.OpenRead(@"F:\Extracted\ESO\139\fixtures_3_3.fft")));
        uint i = 0;
        CreateTree(f.bvh1.root);
        CreateTree(f.bvh2.root);
        CreateTree(f.bvh3.root);
        CreateTree(f.bvh4.root);
        Debug.Log(i);
    }

    void CreateTree(RTreeNode node, Transform parent = null) {
        GameObject fixturePrefab = Resources.Load<GameObject>("TreePrefab");
        Transform nodeObj = Instantiate(fixturePrefab, new Vector3((node.bbox[0] + node.bbox[3])/2, (node.bbox[1] + node.bbox[4]) / 2, (node.bbox[2] + node.bbox[5]) / -2), Quaternion.identity).transform;
        if (node.nodes.Length == 0) {
            nodeObj.name = node.levelsBelow.ToString();
            BoxCollider b = nodeObj.gameObject.AddComponent<BoxCollider>();
            b.size = new Vector3(node.bbox[3] - node.bbox[0], node.bbox[4] - node.bbox[1], node.bbox[5] - node.bbox[2]);
        }
        if (parent != null) nodeObj.SetParent(parent, true);
        for (int i = 0; i < node.nodes.Length; i++) CreateTree(node.nodes[i], nodeObj);
    }

    public void LoadFixtures() { LoadFixtures(worldID); }

    void LoadFixtures(uint worldID) {
        //if(paths == null || paths.Count < 100) paths = Util.LoadWorldFiles();

        //unneccecary?

        //if (meshnames == null) {
        meshnames = new Dictionary<uint, string>();
        foreach (string line in File.ReadAllLines(@"E:\Anna\Anna\Visual Studio\gr2obj\gr2obj\models.txt")) {
            int pos = line.IndexOf('\t');
            if (pos == -1) continue;
            uint id = UInt32.Parse(line.Substring(0, pos));
            string name = line.Substring(pos, line.Length - pos).Replace('\t', '|');
            meshnames[id] = name;
        }
       //}
        
        Transform worldObj = new GameObject(worldID.ToString()).transform;
        Toc t = Toc.Read(paths[Util.WorldTocID(worldID)]);
        Layer l = t.layers[21];
        for (uint y = 0; y < l.cellsY; y++) {
            for (uint x = 0; x < l.cellsX; x++) {
                if (paths.ContainsKey(Util.WorldCellID(worldID, 21, x, y))) {
                    FixtureFile fixtures = FixtureFile.Open(paths[Util.WorldCellID(worldID, 21, x, y)]);
                    if (fixtures == null || fixtures.fixtures == null || fixtures.fixtures.Length == 0) continue;
                    Transform cell = new GameObject($"CELL {x},{y}:").transform;
                    cell.position = new Vector3(fixtures.fixtures[0].fixture.offsetX / 100, 0, fixtures.fixtures[0].fixture.offsetY / -100);
                    cell.SetParent(worldObj, true);
                    ImportFixtures(fixtures, cell);
                } else
                    Debug.Log($"MISSING FIXTURE FILE {Util.WorldCellID(worldID, 21, x, y)}");
            }
        }
    }

    //delete later
    /*
    void LoadPersistentFixtures(uint worldID) {


        if (paths == null || paths.Count < 100) paths = Util.LoadWorldFiles();
        fixturePrefab = Resources.Load<GameObject>("FixturePrefab");
        //mat = Resources.Load<Material>("FixtureMat");
        //clnmat = Resources.Load<Material>("CLNMat");

        //unneccecary?
        
        if (meshnames == null) {
            meshnames = new Dictionary<uint, string>();
            foreach (string line in File.ReadAllLines(@"F:\Extracted\ESO\meshids.txt")) {
                string[] words = line.Split(' ');
                meshnames[UInt32.Parse(words[0])] = words[1];
            }
        }
        

        if(paths.ContainsKey(Util.WorldFileID(worldID, 1))) {
            FixtureFile fixtures = FixtureFile.Open(paths[Util.WorldFileID(worldID, 1)]);
            Transform cell = new GameObject("PERSISTENT CELL 1").transform;
            ImportFixtures(fixtures, cell, false);
        }
        if (paths.ContainsKey(Util.WorldFileID(worldID, 2))) {
            FixtureFile fixtures = FixtureFile.Open(paths[Util.WorldFileID(worldID, 2)]);
            Debug.Log(fixtures.fixtures.Length);
            Transform cell = new GameObject("PERSISTENT CELL 2").transform;
            ImportFixtures(fixtures, cell, false);
        }
    }
        */

    void ImportFixtures(FixtureFile fixtures, Transform cell, bool ignoreVeg = true) {

        GameObject fixturePrefab = Resources.Load<GameObject>("FixturePrefab");
        Material mat = Resources.Load<Material>("FixtureMat");
        Material clnmat = Resources.Load<Material>("CLNMat");
        Material rokmat = Resources.Load<Material>("ROKMat");

        for (int i = 0; i < fixtures.fixtures.Length; i++) {

            Material matToUse = mat;


            if (meshnames.ContainsKey(fixtures.fixtures[i].model) && ignoreVeg) {
                string name = meshnames[fixtures.fixtures[i].model];
                if (name.Contains("|VEG_") || name.Contains("|TRE_")) continue;
                if (name.Contains("|ROK_") || name.Contains("|PFX_ROK") || (name.Contains("|CAV_") && !name.Contains("|CAV_MIN"))) matToUse = rokmat;
                else if (name.Contains("|CLN_") || name.Contains("YellowBox")) matToUse = clnmat;
            }
            var prefab = Resources.Load(fixtures.fixtures[i].model.ToString());
            if (prefab == null) prefab = fixturePrefab;
            GameObject o = (GameObject)Instantiate(prefab, cell);
            o.transform.localPosition = new Vector3(fixtures.fixtures[i].fixture.posX, fixtures.fixtures[i].fixture.posY, fixtures.fixtures[i].fixture.posZ * -1);
            o.transform.localRotation = Quaternion.Euler(
                (float)(fixtures.fixtures[i].fixture.rotX * 180 / Math.PI),
                (float)(fixtures.fixtures[i].fixture.rotY * -180 / Math.PI + 180d),
                (float)(fixtures.fixtures[i].fixture.rotZ * -180 / Math.PI));
            //o.name = fixtures.fixtures[i].fixture.id.ToString();
            o.name = fixtures.fixtures[i].model.ToString();
            //o.name = meshnames.ContainsKey(fixtures.fixtures[i].model) ? fixtures.fixtures[i].model.ToString() : $"{fixtures.fixtures[i].fixture.id}_UNK{fixtures.fixtures[i].model}";
            //o.name = meshnames.ContainsKey(fixtures.fixtures[i].model) ? $"{meshnames[fixtures.fixtures[i].model]}_{fixtures.fixtures[i].id}" : $"UNKNOWN_{fixtures.fixtures[i].id}";
            foreach (var renderer in o.GetComponentsInChildren<MeshRenderer>()) renderer.sharedMaterial = matToUse;
        }
    }

    public void BuildWorldPaths() {
        paths = Util.LoadWorldFiles(worldPath);
        worldPathCount = paths.Count;
    }
    public void ImportMeshes() { ImportMeshes(worldID); }

    public void ImportMeshes(uint worldID) {
        if (paths == null) {
            Debug.LogError("no paths"); return;
        }

        HashSet<uint> models = new HashSet<uint>();


        Toc t = Toc.Read(paths[Util.WorldTocID(worldID)]);
        Layer l = t.layers[21];
        for (uint y = 0; y < l.cellsY; y++) {
            for (uint x = 0; x < l.cellsX; x++) {
                if (paths.ContainsKey(Util.WorldCellID(worldID, 21, x, y))) {
                    FixtureFile fixtures = FixtureFile.Open(paths[Util.WorldCellID(worldID, 21, x, y)]);
                    if (fixtures.fixtures.Length == 0) continue;
                    for (int i = 0; i < fixtures.fixtures.Length; i++) {
                        if (models.Contains(fixtures.fixtures[i].model)) continue;
                        models.Add(fixtures.fixtures[i].model);
                    }
                } else
                    Debug.Log("MISSING FIXTURE FILE");
            }
        }
        //Debug.Log(models.Count);



        StringBuilder args = new StringBuilder();
        int exported = 0;
        foreach(uint model in models) {
            if (!File.Exists(Path.Combine(Application.dataPath, $@"Resources\{model}.obj"))) {
                if (File.Exists(Path.Combine(modelPath, $"{model}.gr2"))) {
                    args.Append($" \"{Path.Combine(modelPath, $"{model}.gr2")}\"");
                    exported++;
                    if (exported >= 512) break;
                } else {
                    Debug.LogWarning($"{model}.gr2 missing");
                }
            }
        }
        if (exported == 0) {
            Debug.Log("No need");
            return;
        }
        Debug.Log($"Exporting {exported} models");
        ProcessStartInfo info = new ProcessStartInfo() {
            FileName = Path.Combine(Path.GetDirectoryName(Application.dataPath), @"res\gr2obj.exe"),
            Arguments = args.ToString()
        };
        Process gr2obj = Process.Start(info);
        gr2obj.WaitForExit();
        foreach(string file in Directory.EnumerateFiles(Path.GetDirectoryName(Application.dataPath), "*.obj", SearchOption.TopDirectoryOnly)) {
            if (!File.Exists(Path.Combine(Application.dataPath, $@"Resources\{Path.GetFileName(file)}")))
                File.Move(file, Path.Combine(Application.dataPath, $@"Resources\{Path.GetFileName(file)}"));
            else File.Delete(file);
        }
        AssetDatabase.Refresh();

    }
}
