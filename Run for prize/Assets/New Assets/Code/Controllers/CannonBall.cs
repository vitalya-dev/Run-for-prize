using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration {
    [RequireComponent(typeof(BasicTranslation))]
    [RequireComponent(typeof(BasicRotation))]
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
            var rt_comp = GetComponent<BasicRotation>();

            if (!trnsl_comp.moving) {
                if (collisionZ) {
                    if (collisionZ.GetComponent<Explode>())
                        collisionZ.GetComponent<Explode>().explode();
                    GetComponent<Explode>().explode();
                } else {
                    trnsl_comp.move(direction, 1 / speed, Space.Self);
                    rt_comp.rotate(new Vector3(90 * direction.x, 0, 0), 1 / (speed));
                }
            }

        }
    }
}