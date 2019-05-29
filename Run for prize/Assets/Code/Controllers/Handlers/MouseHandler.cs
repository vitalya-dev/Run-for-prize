using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MouseHandler : HandlerHelper {
	public UnityEvent lmb_callback = new UnityEvent();
	public UnityEvent rmb_callback = new UnityEvent();

	void Update() {
		if (Input.GetMouseButtonDown(0))
			lmb_callback.Invoke();
		if (Input.GetMouseButtonDown(1))
			rmb_callback.Invoke();
	}
}