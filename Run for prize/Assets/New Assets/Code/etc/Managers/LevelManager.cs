using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NewGeneration {
    public class LevelManager : MonoBehaviour {
        public GameObject level;
        private GameObject level_backup;

        void Awake() {
            if (level) {
                level_backup = Instantiate(level, level.transform.position, Quaternion.identity);
                level_backup.name = level.name;
                level_backup.SetActive(false);
            }
        }

        public void restart() {
            if (level_backup) {
                GameObject.DestroyImmediate(level);
                /////////////////////////////////////////////////
                level = Instantiate(level_backup);
                level.name = level_backup.name;
                level.SetActive(true);
                /////////////////////////////////////////////////
            }
        }

        public void complete() {
            Scene current_scene = SceneManager.GetActiveScene();
            if (current_scene.buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
                quit();
            else
                SceneManager.LoadSceneAsync(current_scene.buildIndex + 1);
        }

        public void play_pause() {
            Time.timeScale = 1 - Time.timeScale;
        }

        public void quit() {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}