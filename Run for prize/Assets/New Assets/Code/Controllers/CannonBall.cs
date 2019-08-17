using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration {
    [RequireComponent(typeof(BasicTranslation))]
    public class CannonBall : MonoBehaviour {
        public Vector2 direction;
        public float speed;
        
        // Update is called once per frame
        void Update() {
            var trnsl_comp = GetComponent<BasicTranslation>();
            trnsl_comp.move(direction, 1 / (speed * 2), Space.Self);
        }
    }
}