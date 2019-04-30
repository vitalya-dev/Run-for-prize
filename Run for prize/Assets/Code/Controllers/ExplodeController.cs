using System.Collections;
using UnityEngine;

public class ExplodeController : MonoBehaviour {
	public GameObject bomb_prefab;

	public void Explode() {
		GameObject bomb = Instantiate(bomb_prefab, transform.position, Quaternion.identity) as GameObject;

		GameObject.Destroy(bomb.gameObject, bomb.GetComponent<ParticleSystem>().startLifetime);
		gameObject.SetActive(false);

		FindObjectOfType<ScoreManager>().Scored();
		
	}
}