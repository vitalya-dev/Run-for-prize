using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NewGeneration {
    public class LevelManager : MonoBehaviour {
        public GameObject level;
        private GameObject level_backup;

        void Awake() {
            if (level == null) {
                throw new MissingComponentException("Level not set");
            }
            level_backup = Instantiate(level, level.transform.position, Quaternion.identity);
            level_backup.name = level.name;
            level_backup.SetActive(false);
        }

        public void restart() {
            GameObject.DestroyImmediate(level);
            /////////////////////////////////////////////////
            level = Instantiate(level_backup);
            level.name = level_backup.name;
            level.SetActive(true);
            /////////////////////////////////////////////////
        }

        public void complete() {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        }
    }
}