using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace NewGeneration {
    public class ScenePicker : MonoBehaviour {
        [SerializeField]
        public string scenePath;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(NewGeneration.ScenePicker))]
public class ScenePickerEditor : Editor {
    public override void OnInspectorGUI() {
        Debug.Log("foo");
        var picker = target as NewGeneration.ScenePicker;
        var oldScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(picker.scenePath);

        serializedObject.Update();

        EditorGUI.BeginChangeCheck();
        var newScene = EditorGUILayout.ObjectField("scene", oldScene, typeof(SceneAsset), false)as SceneAsset;

        if (EditorGUI.EndChangeCheck()) {
            var newPath = AssetDatabase.GetAssetPath(newScene);
            var scenePathProperty = serializedObject.FindProperty("scenePath");
            scenePathProperty.stringValue = newPath;
        }
        serializedObject.ApplyModifiedProperties();
    }
}

#endif