using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        if (level_to_load <= PlayerPrefs.GetInt("Current Level", 1))
            SceneManager.LoadSceneAsync(level_to_load * 3);
    }
}