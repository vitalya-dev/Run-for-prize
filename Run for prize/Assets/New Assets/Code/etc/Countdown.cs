using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Countdown : MonoBehaviour {
    public Sprite[] elements;
    public float time_scale;
    public UnityEvent finish_callback;
    public UnityEvent start_callback;

    void Start() {
        StartCoroutine(count_routine());
    }

    private IEnumerator count_routine() {
        start_callback.Invoke();
        /* ================================================================= */
        for (int i = 1; i <= elements.Length; i++) {
            /* ========================================================== */
            GetComponent<SpriteRenderer>().sprite = elements[elements.Length - i];
            transform.localScale = new Vector3(1, 1, 1);
            /* ========================================================== */
            yield return new WaitForSeconds(1 * time_scale);
            /* ========================================================== */
        }
        GetComponent<SpriteRenderer>().sprite = null;
        /* ================================================================= */
        finish_callback.Invoke();
    }

}