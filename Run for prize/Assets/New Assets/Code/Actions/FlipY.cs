using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration.Actions {
    public class FlipY : Action {
        public string[] flip_objects;
        public float flip_duration;

        public override void act_on(PiggyController piggy) {
            /* ================================================================ */
            GameObject flip_x_helper = new GameObject("FlipHelper");
            flip_x_helper.AddComponent<FlipHelper>();
            flip_x_helper.GetComponent<FlipHelper>().flip_y(piggy, flip_objects, flip_duration);
            /* ================================================================ */
            GetComponent<Explode>().explode();
        }

        public override void place_on(Collider2D collider) {
            if (collider)
                GetComponent<Explode>().explode();
        }
    }
}