using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace NewGeneration {
    public class Trigger : MonoBehaviour {
        public UnityEvent trigger_callback;

        [TextArea]
        public string json;

        void OnEnable() {
            trigger_callback.Invoke();
        }
    }
}