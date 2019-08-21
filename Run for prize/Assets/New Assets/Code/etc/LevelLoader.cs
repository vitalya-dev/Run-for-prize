using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {
    public int level_to_load;


    void Start() {
        GetComponent<Button>().onClick.AddListener(load_level);
    }

    private void load_level() {
        if (PlayerPrefs.GetInt("Current Level", 1) >= level_to_load) 
            Debug.Log("Load: " + level_to_load);
        else
            Debug.Log("Ooops its to early");
    }

    // Уровень это три компонента. Загружаем всегда интро. Тоесть первый уровень -
    // 0 сцена. Второй уровень 3 сцена. Третий уровень 6 сцена.
    // Номер сцена / 3 + 1 - текущий уровень. Если он больше того который хранится - сохраняем. 
}