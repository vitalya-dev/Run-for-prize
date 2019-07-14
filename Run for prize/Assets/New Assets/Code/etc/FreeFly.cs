using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration {
    public class FreeFly : MonoBehaviour {
        public Vector2 direction;
        public float speed;

        void Start() {
            direction = direction.normalized;
        }
        void Update() {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}