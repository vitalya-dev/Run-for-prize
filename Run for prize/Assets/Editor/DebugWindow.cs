using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DebugWindow : EditorWindow {
    private string current_level_string_format = "Current Level: _$";

    [MenuItem("Piggy On My Mind/Show Debug Window")]
    public static void ShowWindow() {
        GetWindow<DebugWindow>(false, "Debug", true);
    }

    void OnGUI() {
        GUILayout.Label(
            current_level_string_format.Replace(
                "_$",
                PlayerPrefs.GetInt("Current Level Build Index", 0).ToString()
            )
        );
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Reset")) {
            PlayerPrefs.DeleteKey("Current Level Build Index");
        }
        if (GUILayout.Button("UP")) {
            int val = PlayerPrefs.GetInt("Current Level Build Index", 0) + 1;
            PlayerPrefs.SetInt("Current Level Build Index", val);
        }
        if (GUILayout.Button("Down")) {
            int val = PlayerPrefs.GetInt("Current Level Build Index", 0) - 1;
            val = Mathf.Clamp(val, 0, int.MaxValue);
            PlayerPrefs.SetInt("Current Level Build Index", val);
        }
        GUILayout.EndHorizontal();
    }
}