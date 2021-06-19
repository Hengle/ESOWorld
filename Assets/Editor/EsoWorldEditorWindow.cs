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

public class EsoWorldEditorWindow : EditorWindow
{
    uint worldID;
    int pathCount;
    Dictionary<ulong, string> paths;

    [MenuItem("Window/ESOWorld")]
    static void Init() {
        EsoWorldEditorWindow window = (EsoWorldEditorWindow)EditorWindow.GetWindow(typeof(EsoWorldEditorWindow));
        window.Show();
    }

    private void OnGUI() {
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Load Paths")) {
            paths = Util.LoadWorldFiles();
            pathCount = paths.Count;
        }
        EditorGUILayout.IntField(pathCount);
        EditorGUILayout.EndHorizontal();
        worldID = (uint)EditorGUILayout.IntField("World:", (int)worldID);
        if (GUILayout.Button("Import Models")) {
            GatherMeshes(worldID);
        }
        if (GUILayout.Button("Import Fixtures")) {
            Test(worldID);
        }
    }


    void Test(uint worldID) {
        if(paths == null || paths.Count < 100) paths = Util.LoadWorldFiles();

        GameObject fixturePrefab = Resources.Load<GameObject>("FixturePrefab");
        Material mat = Resources.Load<Material>("FixtureMat");
        Material clnmat = Resources.Load<Material>("CLNMat");

        //unneccecary?
        Dictionary<uint, string> meshnames = new Dictionary<uint, string>();
        foreach (string line in File.ReadAllLines(@"F:\Extracted\ESO\meshids.txt")) {
            string[] words = line.Split(' ');
            meshnames[UInt32.Parse(words[0])] = words[1];
        }

        Toc t = Toc.Read(paths[Util.WorldTocID(worldID)]);
        Layer l = t.layers[21];
        for (uint y = 0; y < l.cellsY; y++) {
            for (uint x = 0; x < l.cellsX; x++) {
                if (paths.ContainsKey(Util.WorldCellID(worldID, 21, x, y))) {
                    FixtureFile fixtures = FixtureFile.Open(paths[Util.WorldCellID(worldID, 21, x, y)]);
                    if (fixtures.fixtures.Length == 0) continue;
                    Transform cell = new GameObject($"CELL {x},{y}:").transform;
                    cell.position = new Vector3(fixtures.fixtures[0].offsetX / 100, 0, fixtures.fixtures[0].offsetY / -100);
                    for (int i = 0; i < fixtures.fixtures.Length; i++) {
                        if(meshnames.ContainsKey(fixtures.fixtures[i].model)) {
                            if (meshnames[fixtures.fixtures[i].model].StartsWith("VEG_") || meshnames[fixtures.fixtures[i].model].StartsWith("TRE_")
                                || meshnames[fixtures.fixtures[i].model].Contains("_INC_")) continue;
                        }
                        var prefab = Resources.Load(fixtures.fixtures[i].model.ToString());
                        if (prefab == null) prefab = fixturePrefab;
                        GameObject o = (GameObject) Instantiate(prefab, cell);
                        o.transform.localPosition = new Vector3(fixtures.fixtures[i].posX, fixtures.fixtures[i].posY, fixtures.fixtures[i].posZ * -1);
                        o.transform.localRotation = Quaternion.Euler(
                            (float)(fixtures.fixtures[i].rotX*180/Math.PI), 
                            (float)(fixtures.fixtures[i].rotY*-180/Math.PI+180d),
                            (float)(fixtures.fixtures[i].rotZ*-180/Math.PI));
                        o.name = fixtures.fixtures[i].id.ToString();
                        //o.name = meshnames.ContainsKey(fixtures.fixtures[i].model) ? $"{meshnames[fixtures.fixtures[i].model]}_{fixtures.fixtures[i].id}" : $"UNKNOWN_{fixtures.fixtures[i].id}";
                        foreach (var renderer in o.GetComponentsInChildren<MeshRenderer>()) {
                            if(renderer.gameObject.name.StartsWith("CLN")) renderer.sharedMaterial = clnmat;
                            else renderer.sharedMaterial = mat;
                        }
                    }
                } else
                    Debug.Log("MISSING FIXTURE FILE");
            }
        }
    }

    void GatherMeshes(uint worldID) {
        if (paths == null)  paths = Util.LoadWorldFiles();


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
            if (!File.Exists($@"F:\Anna\Files\Unity\esoworldedit\Assets\Resources\{model}.obj") &&
                File.Exists($@"F:\Extracted\ESO\Granny\{model}.gr2")) {
                args.Append($" \"F:\\Extracted\\ESO\\Granny\\{model}.gr2\"");
                exported++;
                if (exported >= 512) break;
            }
        }
        Debug.Log($"Exporting {exported} models");
        ProcessStartInfo info = new ProcessStartInfo() {
            FileName = @"F:\Anna\Visual Studio\gr2obj\x64\Release\gr2obj.exe",
            Arguments = args.ToString()
        };
        Process gr2obj = Process.Start(info);
        gr2obj.WaitForExit();
        foreach(string file in Directory.EnumerateFiles(@"F:\Anna\Files\Unity\esoworldedit\", "*.obj", SearchOption.TopDirectoryOnly)) {
            if (!File.Exists($@"F:\Anna\Files\Unity\esoworldedit\Assets\Resources\{Path.GetFileName(file)}"))
                File.Move(file, $@"F:\Anna\Files\Unity\esoworldedit\Assets\Resources\{Path.GetFileName(file)}");
            else File.Delete(file);
        }
        AssetDatabase.Refresh();

    }
}
