using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NewGeneration {
    public class Error : MonoBehaviour {
        // Start is called before the first frame update
        void Start() {
            throw new UnityException("Should't be there: " + SceneManager.GetActiveScene().name);
        }
    }
}