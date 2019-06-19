using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration.Actions {
    public abstract class Action : MonoBehaviour {
        public abstract void act_on(PiggyController piggy);
    }
}