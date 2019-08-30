using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugSceneManager : MonoBehaviour {
    public Text current_level;
    private string current_level_string_format;

    void Start() {
        current_level_string_format = current_level.text;
    }

    void Update() {
        current_level.text = current_level_string_format.Replace("_$", PlayerPrefs.GetInt("Current Level", 1).ToString());
    }

    public void reset_current_level() {
        PlayerPrefs.DeleteKey("Current Level");
    }

    public void change_current_level(int delta) {
        int val = PlayerPrefs.GetInt("Current Level", 1) + delta;
        val = Mathf.Clamp(val, 1, int.MaxValue);
        /* ------------------------------------------------------------------- */
        PlayerPrefs.SetInt("Current Level", val);
    }

}