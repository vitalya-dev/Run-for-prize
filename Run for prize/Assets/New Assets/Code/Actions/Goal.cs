using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration.Actions {
    public class Goal : Action {
        public override void act_on(PiggyController piggy) {
            piggy.state = PiggyController.State.IDLE;
            GetComponent<Explode>().explode();
        }
    }
}
