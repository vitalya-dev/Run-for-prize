using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioClip[] tracks;

	void Start() {
		if (tracks.Length > 0) {
			int i = Random.Range(0, tracks.Length);
			PlayClipAt(tracks[i], transform.position);
		}
	}

	public void PauseMusic() {
		
	}

	public AudioSource PlayClipAt(AudioClip track, Vector3 position, float volume = 1f) {
		if (track != null) {
			/* ==================================================== */
			GameObject o = new GameObject("SoundFX" + track.name);
			o.transform.position = position;
			Destroy(o, track.length);
			/* ==================================================== */
			AudioSource music = o.AddComponent<AudioSource>();
			music.clip = track;
			music.volume = volume;
			music.Play();
			/* ==================================================== */
			return music;
		} else {
			return null;
		}
	}
}