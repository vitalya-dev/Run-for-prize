using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NewGeneration {
    public class LevelManager : MonoBehaviour {
        public GameObject level;
        private GameObject level_backup;

        public static int f = 0;

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

        private int __reset_progress_counter = 0;
        public void reset_progress() {
            if (++__reset_progress_counter % 2 == 0) {
                PlayerPrefs.DeleteKey("Current Level Build Index");
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            }
        }

        public void complete(int i) {
            Scene current_scene = SceneManager.GetActiveScene();
            if (current_scene.buildIndex + i >= SceneManager.sceneCountInBuildSettings)
                quit();
            else
                SceneManager.LoadSceneAsync(current_scene.buildIndex + i);
        }

        public void complete() {
            complete(1);
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