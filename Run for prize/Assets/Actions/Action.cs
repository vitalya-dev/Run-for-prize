using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour {
	public string places;

	public void StartDrag() {
		foreach (var s in GameObject.FindGameObjectsWithTag(places)) {
			if (s.GetComponent<HighlightController>() != null)
				s.GetComponent<HighlightController>().highlight = true;
			if (s.GetComponent<Animator>() != null)
				s.GetComponent<Animator>().enabled = false;
		}
	}

	public void StopDrag() {
		foreach (var s in GameObject.FindGameObjectsWithTag(places)) {
			if (s.GetComponent<HighlightController>() != null)
				s.GetComponent<HighlightController>().highlight = false;
			if (s.GetComponent<Animator>() != null)
				s.GetComponent<Animator>().enabled = true;
		}
	}

	public virtual bool canBePlaced(Vector3 place) {
		return raycast4tag(place, Vector2.zero, Mathf.Infinity, places);
	}

	protected RaycastHit2D raycast4tag(Vector2 origin, Vector2 direction, float distance, string tag) {
		RaycastHit2D hit = new RaycastHit2D();

		GetComponent<Collider2D>().enabled = false;
		RaycastHit2D[] hits = Physics2D.RaycastAll(origin, direction, distance);
		if (hits.Length != 0 && hits[0].collider.tag == tag)
			hit = hits[0];
		GetComponent<Collider2D>().enabled = true;

		return hit;
	}
}