using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration.Actions {
    public abstract class Action : MonoBehaviour {
        public enum Type {
            FLY,
            FIXED
        }
        public Type type = Type.FLY;
        public abstract void act_on(PiggyController piggy);
    }
}