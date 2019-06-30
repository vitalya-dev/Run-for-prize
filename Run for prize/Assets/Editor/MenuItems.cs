using UnityEditor;

using UnityEditor.SceneManagement;

public class MenuItems {

    [MenuItem("Run For Piggy/Add Level")]
    public static void AddGlobal() {
        SceneAsset global = AssetDatabase.LoadAssetAtPath("Assets/New Assets/Scenes/GLOBAL.unity", typeof(SceneAsset))as SceneAsset;
        EditorSceneManager.OpenScene("Assets/New Assets/Scenes/GLOBAL.unity", OpenSceneMode.Additive);
    }
}