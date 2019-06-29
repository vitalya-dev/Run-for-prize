using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class InputHandler : HandlerHelper {
	public UnityEvent spacekey_callback = new UnityEvent();
	public UnityEvent rkey_callback = new UnityEvent();
	public UnityEvent esc_callback = new UnityEvent();


	void Update() {
		if (Input.GetKeyDown(KeyCode.Space))
			spacekey_callback.Invoke();
		/* ################################################################## */
		if (Input.GetKeyDown(KeyCode.R))
			rkey_callback.Invoke();
		/* ################################################################## */
		if (Input.GetKeyDown(KeyCode.Escape)) {
			esc_callback.Invoke();
		}
	}
}