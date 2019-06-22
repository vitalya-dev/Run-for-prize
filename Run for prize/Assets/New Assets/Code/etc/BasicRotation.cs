using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration {
    public class BasicRotation : Rotationable {
        private bool _rotating = false;
        public bool rotating {
            get {
                return _rotating;
            }
        }

        override public void rotate(Vector3 angle, float time) {
            if (!rotating) {
                _rotating = true;
                StartCoroutine(rotate_routine(angle, time));
            }
        }

        private IEnumerator rotate_routine(Vector3 angle, float time) {
            Quaternion start_rot = transform.rotation;
            Quaternion dest_rot = start_rot * Quaternion.Euler(angle);
            float elapsed_time = 0;
            do {
                elapsed_time += Time.deltaTime;
                transform.rotation = Quaternion.Slerp(start_rot, dest_rot, elapsed_time / time);
                yield return null;
            } while (elapsed_time / time < 1);
            _rotating = false;
        }
    }
}