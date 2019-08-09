using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration.Actions {
    public class Pipe : Action {
        public Pipe connection;
        public Vector2 direction;

        void Start() {
            Debug.Assert(direction != Vector2.zero);
        }

        public override void act_on(PiggyController piggy) {
            if (!connection)
                GetComponent<Explode>().explode();
            else if ((direction * -1) == (Vector2)piggy.direction) {
                piggy.transform.position = connection.transform.position + new Vector3(0.5f, -0.5f);
                piggy.direction = connection.direction;
                GetComponent<Explode>().explode();
            } else {
                GetComponent<Explode>().explode();
                piggy.GetComponent<Explode>().explode();
            }
        }

        public override void place_on(Collider2D collider) {
            if (collider)
                GetComponent<Explode>().explode();
        }
    }

}