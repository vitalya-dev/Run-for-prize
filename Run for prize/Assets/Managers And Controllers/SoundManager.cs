using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioClip[] soundtrack;

	// Use this for initialization
	void Start() {
		if (soundtrack.Length > 0) {
			int i = Random.Range(0, soundtrack.Length);
			PlayClipAt(soundtrack[i], transform.position);
		}

	}

	public AudioSource PlayClipAt(AudioClip clip, Vector3 position, float volume = 1f) {
		if (clip != null) {
			GameObject o = new GameObject("SoundFX" + clip.name);
			o.transform.position = position;
			Destroy(o, clip.length);

			AudioSource music = o.AddComponent<AudioSource>();
			music.clip = clip;

			music.volume = volume;
			music.Play();

			return music;
		} else
			return null;
	}
}