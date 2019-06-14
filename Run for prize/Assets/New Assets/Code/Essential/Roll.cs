using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration {
    [RequireComponent(typeof(BasicRotation))]
    [RequireComponent(typeof(BasicTranslation))]
    public class Roll : MonoBehaviour {
        public bool rolling {
            get {
                return GetComponent<BasicTranslation>().moving || GetComponent<BasicRotation>().rotating;
            }
        }

        public void roll(string input_json) {
            SpaceAndTime input = JsonUtility.FromJson<SpaceAndTime>(input_json);
            roll(new Vector3(input.x, input.y, input.z), input.t, (Space)input.relativeTo);
        }

        public void roll(Vector3 dest, float time, Space relativeTo) {
            if (!rolling)
                StartCoroutine(roll_routine(dest, time, relativeTo));
        }

        private IEnumerator roll_routine(Vector3 dest, float time, Space relativeTo) {
            /* *********************** */
            float distance = 0;
            float speed = 0;
            Vector3  dir = Vector3.zero;
            /* *********************** */
            if (relativeTo == Space.World) {
                distance = Vector3.Distance(dest, transform.position);
                speed = time / distance;
                dir = (dest - transform.position).normalized;
            } else if (relativeTo == Space.Self) {
                distance = dest.magnitude;
                speed = time / distance;
                dir = dest.normalized;
            }
            /* *********************** */
            for (int i = 0; i < distance; i++) {
                GetComponent<Rotationable>().rotate(new Vector3(0, 0, 90 * (-dir.x)), speed);
                GetComponent<BasicTranslation>().move(dir, speed, Space.Self);
                yield return new WaitForSeconds(speed + 0.1f);
            }
        }
    }
}