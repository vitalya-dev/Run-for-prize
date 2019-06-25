using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NewGeneration {
    public class GameManager : MonoBehaviour {
        public List<Object> scenes;
        // called first
        void OnEnable() {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        // called second
        void OnSceneLoaded(Scene scene, LoadSceneMode mode) {

        }

        void OnSceneUnloaded(Scene scene) {
            int scene_index =  scenes.FindIndex(s => s.name == scene.name);
            if (scene_index != -1) {
                scene_index += 1;
                SceneManager.LoadSceneAsync(scenes[scene_index].name, LoadSceneMode.Additive);
            }
        }
    }
}