using System.Collections;
using UnityEngine;

public class ArrowAction : Action {
	[SerializeField]
	private Vector2 _from_direction;
	[SerializeField]
	private Vector2 _to_direction;

	public Vector2 from_direction {
		get {
			return new Vector2(_from_direction.x * transform.parent.right.x, _from_direction.y * transform.parent.up.y);
		}
		set {
			_from_direction = value;
		}
	}

	public Vector2 to_direction {
		get {
			return new Vector2(_to_direction.x * transform.parent.right.x, _to_direction.y * transform.parent.up.y);
		}
		set {
			_to_direction = value;
		}
	}
}