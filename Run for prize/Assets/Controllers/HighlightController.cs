using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
public class HighlightController : MonoBehaviour {
	public Sprite normalSprite;
	public Sprite highlightSprite;

	public bool highlight;

	// Update is called once per frame
	void Update() {
		if (highlight)
			GetComponent<SpriteRenderer>().sprite = highlightSprite;
		else
			GetComponent<SpriteRenderer>().sprite = normalSprite;
	}
}