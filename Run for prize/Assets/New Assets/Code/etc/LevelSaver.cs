using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSaver : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        int current_level = SceneManager.GetActiveScene().buildIndex;
        if (current_level > PlayerPrefs.GetInt("Current Level", 0))
            PlayerPrefs.SetInt("Current Level", current_level);
    }
}