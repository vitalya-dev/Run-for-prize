using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration {
    using Action = NewGeneration.Actions.Action;

    public class ActionManager : MonoBehaviour {
        private GameObject placed;
        [SerializeField]
        private List<Action> actions;

        public Action current_action {
            get {
                return actions.Count > 0 ? actions[0] : null;
            }
        }

        void Start() {
            placed = new GameObject("Placed");
            placed.transform.parent = this.transform.parent;
            placed.transform.localPosition = new Vector3(0, 0, 0);

            foreach (var i in GameObject.FindGameObjectsWithTag("Action")) {
                var action = i.GetComponent<Action>();
                /* ============================================================= */
                if (action.type == Action.Type.FLY) {
                    actions.Add(action);
                }
                /* ============================================================= */
                action.transform.parent = placed.transform;
                /* ============================================================= */
                if (action.type == Action.Type.FLY) {
                    action.gameObject.SetActive(false);
                }
            }

            shuffle(actions);
        }

        private void shuffle<T>(List<T> list) {
            for (int i = 0; i < list.Count; i++) {
                /*===========================================*/
                T temp = list[i];
                int randomIndex = Random.Range(i, list.Count);
                /*===========================================*/
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }
        }

        public void place_action(Vector3 mouse_position) {
            if (actions.Count > 0) {
                RaycastHit2D hit = Physics2D.Raycast(
                    Camera.main.ScreenPointToRay(mouse_position).origin,
                    Vector2.zero,
                    Mathf.Infinity
                );
                if (!hit.collider) {
                    /* ============================ */
                    Action action = actions[0];
                    actions.RemoveAt(0);
                    /* ============================ */
                    Vector3 pos = Camera.main.ScreenPointToRay(mouse_position).origin;
                    pos = new Vector3(
                        Mathf.Floor(pos.x),
                        Mathf.Ceil(pos.y),
                        Mathf.Round(action.transform.position.z)
                    );
                    action.transform.position = pos;
                    /* ============================ */
                    action.gameObject.SetActive(true);
                }
            }
        }
    }
}