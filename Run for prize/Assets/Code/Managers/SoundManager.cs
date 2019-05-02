using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	
	public void PauseMusic(bool trigger) {
		if (trigger)
			GetComponent<AudioSource>().Pause();
		else
			GetComponent<AudioSource>().Play();
	}

	public AudioSource PlayClipAt(AudioClip clip, Vector3 position, float volume = 1f) {
		if (clip != null) {
			/* ==================================================== */
			GameObject o = new GameObject("SoundFX" + clip.name);
			o.transform.position = position;
			Destroy(o, clip.length);
			/* ==================================================== */
			AudioSource music = o.AddComponent<AudioSource>();
			music.clip = clip;
			music.volume = volume;
			music.Play();
			/* ==================================================== */
			return music;
		} else {
			return null;
		}
	}
}