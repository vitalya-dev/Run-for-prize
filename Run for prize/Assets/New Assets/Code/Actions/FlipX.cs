using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration.Actions {
    public class FlipX : Action {
        public string[] flip_objects;
        public float flip_duration;

        public override void act_on(PiggyController piggy) {
            /* ================================================================ */
            GameObject flip_x_helper = new GameObject("FlipXHelper");
            flip_x_helper.AddComponent<FlipXHelper>();
            flip_x_helper.GetComponent<FlipXHelper>().flip(piggy, flip_objects, flip_duration);
            /* ================================================================ */
            GetComponent<Explode>().explode();
        }

        public override void place_on(Collider2D collider) {
            if (collider)
                GetComponent<Explode>().explode();
        }
    }

}