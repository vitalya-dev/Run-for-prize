using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration {
    public class JSONWrapper : MonoBehaviour {
        public void setPosition(string position) {
            SpaceAndTime input = JsonUtility.FromJson<SpaceAndTime>(position);
            transform.position = new Vector3(input.x, input.y, input.z);
        }
    }
}