using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour {
    private Vector3 init_pos;

    // Start is called before the first frame update
    void Start() {
        init_pos = transform.position;
    }

    // Update is called once per frame
    void Update() {
        /* ====================================================================== */
        Vector2 flow = Camera.main.ScreenToViewportPoint(Input.mousePosition) - new Vector3(0.5f, 0.5f);
        /* ====================================================================== */
        transform.position = init_pos;
        transform.Translate(flow.x, flow.y, 0);
    }
}