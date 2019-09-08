using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace NewGeneration {
    public class LevelLoader : MonoBehaviour {
        public int level_to_load;

        public Sprite active_thumb;
        public Sprite inactive_thumb;

        void Start() {
            if (level_to_load <= PlayerPrefs.GetInt("Current Level", 1))
                GetComponent<Image>().sprite = active_thumb;
            else
                GetComponent<Image>().sprite = inactive_thumb;
            GetComponent<Button>().onClick.AddListener(load_level);
        }

        private void load_level() {
            Scene scene_to_load = SceneUtils.findAllScenes("+")[level_to_load];
            if (scene_to_load.buildIndex <= PlayerPrefs.GetInt("Current Level", 0))
                SceneManager.LoadSceneAsync(scene_to_load.buildIndex);
        }
    }
}