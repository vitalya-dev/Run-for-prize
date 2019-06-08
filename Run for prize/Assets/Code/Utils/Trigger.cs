using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour {
    public UnityEvent trigger_callback;

    void OnEnable() {
        trigger_callback.Invoke();
    }

    private void OnDrawGizmos() {
        Gizmos.DrawIcon(transform.position, "Trigger.jpg", true);
    }
}