using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace NewGeneration {
    [ExecuteInEditMode]
    public class Snap : MonoBehaviour {
        public float snap_x = 0;
        public float snap_y = 0;
        // Start is called before the first frame update
        void Start() {
            if (Application.isPlaying)
                enabled = false;
        }

        // Update is called once per frame
        void Update() {
#if UNITY_EDITOR
            if (Selection.activeGameObject == gameObject)
                transform.position = new Vector3(
                    Mathf.FloorToInt(transform.position.x) + snap_x,
                    Mathf.FloorToInt(transform.position.y) + snap_y,
                    Mathf.RoundToInt(transform.position.z)
                );
#endif
        }
    }
}