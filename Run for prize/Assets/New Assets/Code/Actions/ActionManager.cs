using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration {
    using Action = NewGeneration.Actions.Action;

    public class ActionManager : MonoBehaviour {
        private GameObject placed;
        [SerializeField]
        private List<Action> actions;

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
        }
    }
}