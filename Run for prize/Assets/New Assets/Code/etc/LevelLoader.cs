using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {
    public int level_to_load;

    void Start() {
        GetComponent<Button>().onClick.AddListener(load_level);
    }

    private void load_level() {
        if (PlayerPrefs.GetInt("Current Level", 10) >= level_to_load)
            SceneManager.LoadSceneAsync(level_to_load * 3);
        else
            Debug.Log("Ooops its to early");
    }
}