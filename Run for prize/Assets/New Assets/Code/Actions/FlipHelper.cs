using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration.Actions {
    public class FlipHelper : MonoBehaviour {
        public void flip_y(PiggyController piggy, string[] flip_objects, float flip_duration) {
            StartCoroutine(flip_coroutine(piggy, flip_objects, new Vector3(0, 180, 0), flip_duration));
        }

        public void flip_x(PiggyController piggy, string[] flip_objects, float flip_duration) {
            StartCoroutine(flip_coroutine(piggy, flip_objects, new Vector3(180, 0, 0), flip_duration));
        }

        private IEnumerator flip_object(GameObject o, Vector3 angle, float flip_duration) {
            Quaternion start_rot = o.transform.rotation;
            Quaternion dest_rot = start_rot * Quaternion.Euler(angle);
            float time_flow = 0;
            while (time_flow / flip_duration < 1) {
                time_flow += Time.deltaTime;
                o.transform.rotation = Quaternion.Slerp(start_rot, dest_rot, time_flow / flip_duration);
                yield return null;
            }
        }

        private IEnumerator flip_coroutine(PiggyController piggy, string[] flip_objects, Vector3 angle, float flip_duration) {
            var state_backup = piggy.state;
            piggy.state = PiggyController.State.WAIT;
            /* ================================================================== */
            List<GameObject> flip_gameobjects = new List<GameObject>();
            foreach (var o in flip_objects) {
                StartCoroutine(flip_object(GameObject.Find(o), angle, flip_duration - 0.01f));
            }
            /* ================================================================== */
            yield return new WaitForSeconds(flip_duration);
            /* ================================================================== */
            piggy.state = state_backup;
            /* ================================================================== */
            GameObject.Destroy(gameObject);
        }
    }
}