using System.Collections;
using System.Collections.Generic;

namespace NewGeneration {
    [System.Serializable]
    public class SpaceAndTime {
        public float x;
        public float y;
        public float z;
        public float t;
        public int relativeTo; // World 0 Self 1
    }
}