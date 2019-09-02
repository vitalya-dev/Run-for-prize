using UnityEditor;
using UnityEditor.SceneManagement;

public class MenuItems {

    [MenuItem("Piggy On My Mind/Show Debug Scene")]
    public static void show_debug_scene() {
        // SceneAsset global = AssetDatabase.LoadAssetAtPath(
        //     "Assets/New Assets/Levels/Debug/Gameplay/Debug (Gameplay).unity",
        //     typeof(SceneAsset)) as SceneAsset;
        EditorSceneManager.OpenScene("Assets/New Assets/Levels/Debug/Gameplay/Debug (Gameplay).unity", OpenSceneMode.Additive);
    }
}