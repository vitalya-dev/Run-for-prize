using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration {
    public class Highlight : MonoBehaviour {
        public ActionManager action_manager;

        void Start() {
            if (action_manager == null) 
                throw new UnityException("Action manager not set");
            gameObject.AddComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update() {
            /* ************************************************** */
            var sprite_renderer = GetComponent<SpriteRenderer>();
            if (action_manager.current_action) {
                sprite_renderer.sprite = action_manager.current_action.GetComponent<SpriteRenderer>().sprite;
                sprite_renderer.color = new Color(1, 1, 1, .5f);
            }
            else
                sprite_renderer.sprite = null;
            /* ************************************************** */
            Vector3 pos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
            pos = new Vector3(
                Mathf.Floor(pos.x),
                Mathf.Ceil(pos.y),
                transform.position.z
            );
            transform.position = pos;
            /* ************************************************** */
        }
    }
}