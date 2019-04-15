using System.Collections;
using UnityEngine;

public class ExplodeController : MonoBehaviour {

	public ParticleSystem explosion_prefab;

	public void Explode() {
		ParticleSystem explosion = Instantiate(explosion_prefab);
		explosion.Play();

		GameObject.Destroy(explosion.gameObject, explosion.startLifetime);
		GameObject.Destroy(gameObject);
	}
}