using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace NewGeneration {
    public class Explode : MonoBehaviour {
        public AudioClip explode_clip;
        public GameObject bomb_prefab;
        public UnityEvent explode_callback;

        void Start() {
            if (!bomb_prefab)
                throw new MissingReferenceException("Bomb prefab not set");
        }

        public void explode() {
            // /* ================================================================================================= */
            if (explode_clip)
                SoundUtils.play_clip(explode_clip, 0.3f);
            // /* ================================================================================================= */
            GameObject bomb = Instantiate(
                bomb_prefab,
                transform.position + new Vector3(0, 0, -5),
                Quaternion.identity
            )as GameObject;
            GameObject.Destroy(bomb, bomb.GetComponent<ParticleSystem>().main.startLifetime.constant);
            /* ================================================================================================= */
            GameObject.Destroy(gameObject);
            /* ================================================================================================= */
            explode_callback.Invoke();
        }
    }
}