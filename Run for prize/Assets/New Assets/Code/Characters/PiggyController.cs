using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

using Action = NewGeneration.Actions.Action;

namespace NewGeneration {

    [RequireComponent(typeof(BasicRotation))]
    [RequireComponent(typeof(BasicTranslation))]
    [RequireComponent(typeof(Roll))]
    public class PiggyController : MonoBehaviour {
        public GUIStyle gizmo_style = new GUIStyle();

        public enum State { FLY, FALL, ROLL, IDLE, COLLIDE, INVALID }

        [SerializeField]
        private State _state = State.IDLE;

        public State state {
            get {
                return _state;
            }
            set {
                _state = value;
                switch (_state) {
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
        }
        public string state_as_string {
            get {
                return _state.ToString();
            }
            set {
                _state = (State)System.Enum.Parse(typeof(State), value);
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

        public Vector3 direction;

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
            switch (_state) {
                case State.FALL:
                    GetComponent<Animator>().Play(_state.ToString());
                    var trans_comp = GetComponent<BasicTranslation>();
                    if (!trans_comp.moving) {
                        if (collisionBelow && collisionBelow.tag == "Ground") {
                            state = State.ROLL;
                        } else if (collisionBelow && collisionBelow.tag == "Wall") {
                            state = State.COLLIDE;
                        } else
                            trans_comp.move(new Vector3(0, -1, 0), 1 / (speed * 2), Space.Self);
                    }
                    break;
                case State.IDLE:
                    GetComponent<Animator>().Play(state.ToString());
                    break;
                case State.FLY:
                    GetComponent<Animator>().Play(state.ToString());
                    face = direction;
                    var trnsl_comp = GetComponent<BasicTranslation>();
                    if (!trnsl_comp.moving) {
                        if (collisionZ) {
                            if (collisionZ.GetComponent<NewGeneration.Actions.Action>()) {
                                var action = collisionZ.GetComponent<NewGeneration.Actions.Action>();
                                action.act_on(this);
                            } else
                                state = State.COLLIDE;
                        } else
                            trnsl_comp.move(direction, 1 / (speed * 2), Space.Self);
                    }
                    break;
                case State.ROLL:
                    GetComponent<Animator>().Play(_state.ToString());
                    if (Mathf.Abs(direction.y) > 0 || direction.magnitude < 1) {
                        state = State.INVALID;
                    } else {
                        var roll_comp = GetComponent<Roll>();
                        if (!roll_comp.rolling) {
                            if (collisionZ) {
                                if (collisionZ.GetComponent<NewGeneration.Actions.Action>()) {
                                    var action = collisionZ.GetComponent<NewGeneration.Actions.Action>();
                                    action.act_on(this);
                                } else
                                    state = State.COLLIDE;
                            } else if (!collisionBelow) {
                                state = State.FALL;
                            } else {
                                roll_comp.roll(direction.normalized, 1 / speed, Space.Self);
                            }
                        }
                    }
                    break;
            }
        }

        void OnDrawGizmos() {
            Handles.Label(transform.position + new Vector3(0, 0.7f, 0), _state.ToString(), gizmo_style);
        }
    }
}