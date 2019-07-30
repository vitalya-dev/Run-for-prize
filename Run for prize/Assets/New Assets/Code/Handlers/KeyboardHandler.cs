using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace NewGeneration {
    public class KeyboardHandler : MonoBehaviour {
        public UnityEvent esc_callback = new UnityEvent();
        public UnityEvent space_callback = new UnityEvent();

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.Escape))
                esc_callback.Invoke();
            if (Input.GetKeyDown(KeyCode.Space))
                space_callback.Invoke();
        }
    }
}