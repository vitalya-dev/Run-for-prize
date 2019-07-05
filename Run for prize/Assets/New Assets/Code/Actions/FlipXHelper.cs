using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration.Actions {
    public class FlipXHelper : MonoBehaviour {
        public void flip(PiggyController piggy, string[] flip_objects, float flip_duration) {
            StartCoroutine(flip_coroutine(piggy, flip_objects, flip_duration));
        }

        private IEnumerator flip_coroutine(PiggyController piggy, string[] flip_objects, float flip_duration) {
            var state_backup = piggy.state;
            piggy.state = PiggyController.State.WAIT;
            /* ================================================================== */
            List<GameObject> flip_gameobjects = new List<GameObject>();
            foreach (var o in flip_objects)
                flip_gameobjects.Add(GameObject.Find(o));
            /* ================================================================== */
            float time_flow = 0;
            while (time_flow / flip_duration < 1) {
                time_flow += Time.deltaTime;
                foreach (var o in flip_gameobjects)
                    o.transform.rotation = Quaternion.Euler(0, Mathf.Lerp(0, 180, time_flow / flip_duration), 0);
                yield return null;
            }
            /* ================================================================== */
            piggy.state = state_backup;
            /* ================================================================== */
            GameObject.Destroy(gameObject);
        }
    }
}