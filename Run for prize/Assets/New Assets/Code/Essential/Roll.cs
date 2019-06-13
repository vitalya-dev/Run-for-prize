using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration {
    [RequireComponent(typeof(BasicRotation))]
    [RequireComponent(typeof(BasicTranslation))]
    public class Roll : MonoBehaviour {
        public bool rolling {
            get {
                return GetComponent<Translation>().moving || GetComponent<BasicRotation>().rotating;
            }
        }

        public void roll(string input_json) {
            SpaceAndTime input = JsonUtility.FromJson<SpaceAndTime>(input_json);
            roll(new Vector3(input.x, input.y, input.z), input.t);
        }

        public void roll(Vector3 dest, float time) {
            if (!rolling)
                StartCoroutine(roll_routine(dest, time));
        }

        private IEnumerator roll_routine(Vector3 dest, float time) {
            float distance = Vector3.Distance(dest, transform.position);
            float speed = time / distance;
            Vector3 dir = (dest - transform.position).normalized;

            for (int i = 0; i < distance; i++) {
                GetComponent<Rotationable>().rotate(new Vector3(0, 0, 90 * (-dir.x)), speed);
                GetComponent<BasicTranslation>().move(transform.position + dir, speed);
                yield return new WaitForSeconds(speed);
            }
        }
    }
}