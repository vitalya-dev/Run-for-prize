using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration.Actions {
    public class ChangeDirection : Action {
        public Vector2 direction;
        public override void act_on(PiggyController piggy) {
            piggy.direction = direction;
            GetComponent<Explode>().explode();
        }
    }
}