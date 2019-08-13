using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace NewGeneration.Actions {
    public abstract class Action : MonoBehaviour {

        public UnityEvent place_on_callback;

        public GUIStyle gizmo_style = new GUIStyle();

        public enum Type {
            FLY,
            FIXED
        }
        public Type type = Type.FLY;
        public abstract void act_on(PiggyController piggy);
        public virtual void place_on(Collider2D collider) {
            Debug.Log("foo");
            place_on_callback.Invoke();
        }

        void OnDrawGizmos() {
#if UNITY_EDITOR
            Handles.Label(transform.position + new Vector3(0, 0.7f, 0), type.ToString(), gizmo_style);
#endif
        }
    }
}