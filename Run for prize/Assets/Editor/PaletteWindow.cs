using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PaletteWindow : EditorWindow {
	public static PaletteWindow instance;

	private List<GameObject> level_pieces;

	Vector2 scroll_position;

	GUISkin skin;

	public static void ShowPalette() {
		instance = (PaletteWindow) EditorWindow.GetWindow(typeof(PaletteWindow));
	}

	private void OnEnable() {
		Debug.Log("OnEnable called...");
		level_pieces = LoadGameObjects("Assets/Prefabs/Level Pieces", "t:Prefab");
		skin = (GUISkin) Resources.Load("GUI");
	}

	private void OnDisable() {
		Debug.Log("OnDisable called...");
	}

	private void OnDestroy() {
		Debug.Log("OnDestroy called...");
	}

	private void Update() {
		EditorUtility.SetDirty(this);
	}

	private void OnGUI() {
		if (!Selection.activeGameObject || Selection.activeGameObject.name != "Level") {
			EditorGUILayout.HelpBox("Select level", MessageType.Info);
			return;
		}
		/* @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ */
		List<GUIContent> contents = new List<GUIContent>();
		foreach (var piece in level_pieces) {
			GUIContent content = new GUIContent();
			content.image = AssetPreview.GetAssetPreview(piece);
			content.text = piece.name;
			contents.Add(content);
		}
		/* @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ */
		scroll_position = GUILayout.BeginScrollView(scroll_position);
		int index = GUILayout.SelectionGrid(-1, contents.ToArray(),
			Mathf.FloorToInt(position.width / skin.button.fixedWidth),
			skin.button
		);
		GUILayout.EndScrollView();
		/* @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ */
		if (index != -1) {
			GameObject piece = PrefabUtility.InstantiatePrefab(level_pieces[index]) as GameObject;
			piece.transform.parent = Selection.activeTransform;

		}
	}

	public static List<GameObject> LoadGameObjects(string path, string filter) {
		List<GameObject> objects = new List<GameObject>();
		foreach (var guid in AssetDatabase.FindAssets(filter, new string[] { path })) {
			string object_path = AssetDatabase.GUIDToAssetPath(guid);
			objects.Add(AssetDatabase.LoadAssetAtPath(object_path, typeof(GameObject)) as GameObject);
		}
		return objects;
	}
}