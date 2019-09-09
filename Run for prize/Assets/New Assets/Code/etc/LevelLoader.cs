﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace NewGeneration {
    public class LevelLoader : MonoBehaviour {
        public string level_to_load;

        public Sprite active_thumb;
        public Sprite inactive_thumb;

        void Start() {
            if (LevelUtils.get_level_build_index(level_to_load) <= PlayerPrefs.GetInt("Current Level Build Index", 0))
                GetComponent<Image>().sprite = active_thumb;
            else
                GetComponent<Image>().sprite = inactive_thumb;
            GetComponent<Button>().onClick.AddListener(load_level);
        }

        private void load_level() {
            if (LevelUtils.get_level_build_index(level_to_load) <= PlayerPrefs.GetInt("Current Level Build Index", 0))
                SceneManager.LoadSceneAsync(LevelUtils.get_level_build_index(level_to_load));
        }
    }
}