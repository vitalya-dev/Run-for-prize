using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration {
    public class Explode : MonoBehaviour {
        public AudioClip explode_clip;
        public GameObject bomb_prefab;

        void Start() {
            if (!bomb_prefab)
                throw new MissingReferenceException("Bomb prefab not set");
        }

        public void explode() {
            // /* ================================================================================================= */
            // if (explode_clip)
            //     FindObjectOfType<SoundManager>().PlayClipAt(explode_clip, this.transform.position, 0.7f, false);
            // /* ================================================================================================= */
            GameObject bomb = Instantiate(
                bomb_prefab,
                transform.position + new Vector3(0, 0, -5),
                Quaternion.identity
            )as GameObject;
            GameObject.Destroy(bomb, bomb.GetComponent<ParticleSystem>().main.startLifetime.constant);
            /* ================================================================================================= */
            GameObject.Destroy(gameObject);
        }
    }
}