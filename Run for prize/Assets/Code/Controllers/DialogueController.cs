using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueController : MonoBehaviour {
    public GameObject[] lines;
    public float pause_starte;
    public float pause_between;
    public float pause_ende;

    public UnityEvent finish_callback;

    void Start() {
        StartCoroutine(say_it());
    }

    private IEnumerator say_it() {
        for (int i = 0; i < lines.Length; i++) {
            if (i == 0)
                yield return new WaitForSeconds(pause_starte);
            else
                yield return new WaitForSeconds(pause_between);
            lines[i].SetActive(true);
        }
        yield return new WaitForSeconds(pause_ende);
        finish_callback.Invoke();

    }
}