using System.Collections;
using UnityEngine;

public class ExplodeController : MonoBehaviour {
	public AudioClip explode_clip;
	public GameObject bomb_prefab;

	public void Explode() {
		/* ================================================================================================= */
		if (explode_clip)
			FindObjectOfType<SoundManager>().PlayClipAt(explode_clip, this.transform.position, 0.7f, false);
		/* ================================================================================================= */
		GameObject bomb = Instantiate(bomb_prefab, transform.position + new Vector3(0, 0, -5), Quaternion.identity) as GameObject;
		GameObject.Destroy(bomb.gameObject, bomb.GetComponent<ParticleSystem>().startLifetime);
		/* ================================================================================================= */
		gameObject.SetActive(false);
		/* ================================================================================================= */
		FindObjectOfType<ScoreManager>().Scored();
	}
}