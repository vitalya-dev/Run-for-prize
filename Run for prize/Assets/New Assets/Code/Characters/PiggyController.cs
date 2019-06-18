using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace NewGeneration {

    [RequireComponent(typeof(BasicRotation))]
    [RequireComponent(typeof(BasicTranslation))]
    [RequireComponent(typeof(Roll))]
    public class PiggyController : MonoBehaviour {
        public GUIStyle gizmo_style = new GUIStyle();

        public enum State { FLY, FALL, ROLL, IDLE, COLLIDE, INVALID }
        [SerializeField]
        private State state = State.IDLE;
        public string state_as_string {
            get {
                return state.ToString();
            }
            set {
                state = (State)System.Enum.Parse(typeof(State), value);
            }
        }

        public UnityEvent fly_callback;
        public UnityEvent fall_callback;
        public UnityEvent roll_callback;
        public UnityEvent idle_callback;
        public UnityEvent collide_callback;
        public UnityEvent invalid_callback;

        public Vector2 face {
            get {
                return transform.right;
            }
            set {
                transform.rotation = Quaternion.LookRotation(transform.forward, new Vector2(-value.y, value.x));
            }
        }

        public Vector3 roll_axis;

        public float speed = 1;

        public LayerMask collisionMask;
        public Collider2D collisionBelow {
            get {
                GetComponent<Collider2D>().enabled = false;
                RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.down, Vector2.zero, 0.0f, collisionMask);
                GetComponent<Collider2D>().enabled = true;
                return hit.collider;
            }
        }

        public Collider2D collisionZ {
            get {
                GetComponent<Collider2D>().enabled = false;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 0.0f, collisionMask);
                GetComponent<Collider2D>().enabled = true;
                return hit.collider;
            }
        }

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            // face = new Vector2(direction.x, direction.y);
            switch (state) {
                case State.FALL:
                    GetComponent<Animator>().Play(state.ToString());
                    var trans_comp = GetComponent<BasicTranslation>();
                    if (!trans_comp.moving) {
                        if (collisionBelow && collisionBelow.tag == "Ground") {
                            set_state(State.ROLL);
                        } else if (collisionBelow && collisionBelow.tag == "Wall") {
                            set_state(State.COLLIDE);
                        } else
                            trans_comp.move(new Vector3(0, -1, 0), 1 / (speed * 2), Space.Self);
                    }
                    break;
                case State.IDLE:
                    GetComponent<Animator>().Play(state.ToString());
                    break;
                case State.ROLL:
                    GetComponent<Animator>().Play(state.ToString());
                    if (Mathf.Abs(roll_axis.y) > 0 || roll_axis.magnitude < 1) {
                        set_state(State.INVALID);
                    } else {
                        var roll_comp = GetComponent<Roll>();
                        if (!roll_comp.rolling) {
                            if (!collisionBelow) {
                                set_state(State.FALL);
                            } else {
                                roll_comp.roll(roll_axis.normalized, 1 / speed, Space.Self);
                            }
                        }
                    }
                    break;
            }
        }

        public void set_state(State new_state) {
            state = new_state;
            switch (state) {
                case State.FALL:
                    fall_callback.Invoke();
                    break;
                case State.IDLE:
                    idle_callback.Invoke();
                    break;
                case State.ROLL:
                    roll_callback.Invoke();
                    break;
                case State.COLLIDE:
                    collide_callback.Invoke();
                    break;
            }
        }

        void OnDrawGizmos() {
            Handles.Label(transform.position + new Vector3(0, 0.7f, 0), state.ToString(), gizmo_style);
        }
    }
}