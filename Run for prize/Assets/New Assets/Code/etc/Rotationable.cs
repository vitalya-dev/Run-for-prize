using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration {
    public abstract class Rotationable : MonoBehaviour {
        public abstract void rotate(Vector3 angle, float time);
    }
}