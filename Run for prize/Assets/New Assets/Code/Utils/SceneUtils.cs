using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NewGeneration {
    public class SceneUtils {
        public static Scene[] findAllScenes(string pattern) {
            List<Scene> scenes = new List<Scene>();
            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++) {
                Scene scene = SceneManager.GetSceneByBuildIndex(i);
                if (scene.name.EndsWith("+"))
                    scenes.Add(scene);
            }
            return scenes.ToArray();
        }
    }
}