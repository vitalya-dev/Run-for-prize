using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration.Actions {
    public class EvilFly : Fly {
        public override void act_on(PiggyController piggy) {
            piggy.state = PiggyController.State.EVILFLY;
            GetComponent<Explode>().explode();
        }
    }
}