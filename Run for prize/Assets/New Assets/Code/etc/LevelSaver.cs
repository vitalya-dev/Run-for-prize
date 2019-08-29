using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSaver : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        int current_level = SceneManager.GetActiveScene().buildIndex / 3;
        if (current_level > PlayerPrefs.GetInt("Current Level", 1))
            PlayerPrefs.SetInt("Current Level", current_level);
    }

    // Update is called once per frame
    void Update() {

    }
}