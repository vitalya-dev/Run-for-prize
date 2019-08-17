using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration {
    [RequireComponent(typeof(BasicTranslation))]
    public class CannonBall : MonoBehaviour {
        public Vector2 direction;
        public float speed;

        public LayerMask collisionMask;

        public Collider2D collisionZ {
            get {
                GetComponent<Collider2D>().enabled = false;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 0.0f, collisionMask);
                GetComponent<Collider2D>().enabled = true;
                return hit.collider;
            }
        }

        // Update is called once per frame
        void Update() {
            var trnsl_comp = GetComponent<BasicTranslation>();

            if (!trnsl_comp.moving) {
                if (collisionZ) {
                    if (collisionZ.GetComponent<Explode>())
                        collisionZ.GetComponent<Explode>().explode();
                    GetComponent<Explode>().explode();
                } else {
                    trnsl_comp.move(direction, 1 / (speed * 2), Space.Self);
                }
            }

        }
    }
}