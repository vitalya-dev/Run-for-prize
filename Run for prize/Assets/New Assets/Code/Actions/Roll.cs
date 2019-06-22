using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration.Actions {
    public class Roll : Action {
        public override void act_on(PiggyController piggy) {
            piggy.state = PiggyController.State.ROLL;
            GetComponent<Explode>().explode();
        }
    }
}