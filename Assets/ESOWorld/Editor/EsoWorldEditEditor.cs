using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EsoWorldEdit))]
public class EsoWorldEditEditor : Editor
{
    SerializedProperty modelPath;
    SerializedProperty worldPath;
    SerializedProperty databasePath;
    SerializedProperty worldID;
    string worldName;

    private void OnEnable() {
        modelPath = serializedObject.FindProperty("modelPath");
        worldPath = serializedObject.FindProperty("worldPath");
        databasePath = serializedObject.FindProperty("databasePath");
        worldID = serializedObject.FindProperty("worldID");
        worldName = "";
    }

    public override void OnInspectorGUI() {

        float defaultLabelWidth = EditorGUIUtility.labelWidth;
        EditorGUIUtility.labelWidth = 100;

        serializedObject.Update();

        EsoWorldEdit e = (EsoWorldEdit)target;

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PropertyField(worldPath);

        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.IntField(e.worldPathCount, GUILayout.Width(64));
        EditorGUI.EndDisabledGroup();

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.PropertyField(modelPath);
        EditorGUILayout.PropertyField(databasePath);

        if(GUILayout.Button("Build Data")) {
            e.BuildWorldPaths();
            e.BuildWorldNames();
        }

        EditorGUILayout.PropertyField(worldID);

        if (e.worldNames != null) 
            if(e.worldNames.ContainsKey((uint)worldID.intValue))
                worldName = e.worldNames[(uint)worldID.intValue];

        GUILayout.Label(worldName);

        if (GUILayout.Button("Import Meshes")) {
            e.ImportMeshes();
        }

        if (GUILayout.Button("Import Terrain")) {
            e.ImportTerrain();
        }

        if (GUILayout.Button("Import Fixtures")) {
            e.LoadFixtures();
        }

        if (GUILayout.Button("Import Water")) {
            e.ImportWater();
        }

        serializedObject.ApplyModifiedProperties();

        EditorGUIUtility.labelWidth = defaultLabelWidth;
        //DrawDefaultInspector();
    }
}
