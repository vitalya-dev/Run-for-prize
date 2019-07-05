using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration.Actions {
    public class FlipX : Action {
        public string[] flip_objects;
        public float flip_duration;

        public override void act_on(PiggyController piggy) {
            StartCoroutine(act_on_coroutine(piggy));
        }

        private IEnumerator act_on_coroutine(PiggyController piggy) {
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
            GetComponent<Explode>().explode();
            /* ================================================================== */
            piggy.state = state_backup;
        }

        public override void place_on(Collider2D collider) {
            if (collider)
                GetComponent<Explode>().explode();
        }

    }
}