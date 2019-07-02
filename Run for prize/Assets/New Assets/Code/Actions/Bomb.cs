using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration.Actions {
    public class Bomb : Action {
        public override void act_on(PiggyController piggy) {
            piggy.state = PiggyController.State.FLY;
            GetComponent<Explode>().explode();
        }

        public override void place_on(Collider2D collider) {
            if (collider && collider.GetComponent<Explode>()) {
                collider.GetComponent<Explode>().explode();
                GetComponent<Explode>().explode();
            } else {
                 GetComponent<Explode>().explode();
            }
        }
    }
}