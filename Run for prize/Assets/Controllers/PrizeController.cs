using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeController : MonoBehaviour {
	public GameObject particle_prefab;

	public void prized() {
		for (int i = 0; i < 200; i++) {
			GameObject particle = Instantiate(particle_prefab, transform.position, Quaternion.identity);
			particle.transform.Translate(new Vector3(0, 0, 1));
			particle.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 1f)) * Random.Range(200, 1000));
		}

		GameObject.Destroy(gameObject);
	}
}
