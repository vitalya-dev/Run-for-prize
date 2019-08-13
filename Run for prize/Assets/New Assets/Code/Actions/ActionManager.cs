using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

namespace NewGeneration {
    using Action = NewGeneration.Actions.Action;

    public class ActionManager : MonoBehaviour {
        public UnityEvent place_on_callback;

        private GameObject placed;
        [SerializeField]
        private List<Action> actions = new List<Action>();

        public static int attemp_number = 0;

        public Action current_action {
            get {
                return actions.Count > 0 ? actions[0] : null;
            }
        }

        void Start() {
            attemp_number += 1;

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
                if (i == 0)
                    randomIndex = attemp_number % list.Count;
                /*===========================================*/
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }
        }

        public void place_action(Vector3 mouse_position) {
            if (actions.Count > 0 && gameObject.activeSelf) {
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
                RaycastHit2D hit = Physics2D.Raycast(
                    Camera.main.ScreenPointToRay(mouse_position).origin,
                    Vector2.zero,
                    Mathf.Infinity
                );
                /* ============================ */
                action.transform.position = pos;
                action.gameObject.SetActive(true);
                action.place_on(hit.collider);
                /* ============================ */
                place_on_callback.Invoke();
            }
        }
    }
}