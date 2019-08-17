using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration.Actions {
    public class Cannon : Action {
        public Vector2 direction;
        public GameObject cannon_ball_prefab;

        void Start() {
            if (!cannon_ball_prefab)
                throw new UnityException("Cannon Ball prefab not set");
        }

        public override void act_on(PiggyController piggy) {
            GetComponent<Explode>().explode();
            GameObject cannon_ball = Instantiate(
                cannon_ball_prefab,
                transform.position + new Vector3(0.5f, -0.5f) + (Vector3)direction,
                Quaternion.identity, transform.parent) as GameObject;
        }

        public override void place_on(Collider2D collider) {
            base.place_on(collider);
            if (collider)
                GetComponent<Explode>().explode();
        }
    }
}