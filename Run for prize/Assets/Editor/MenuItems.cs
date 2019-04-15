using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class MenuItems {

	[MenuItem("Run For Prize/Add Level")]
	public static void LevelAdd() {
		GameObject level_meta = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Level.prefab", typeof(GameObject)) as GameObject;

		GameObject level = PrefabUtility.InstantiatePrefab(level_meta) as GameObject;
		level.transform.position = Vector3.zero;
		Selection.activeGameObject = level;
	}

	[MenuItem("Run For Prize/Show Palette")]
	public static void PalleteShow() {
		PaletteWindow.ShowPalette();
	}
}