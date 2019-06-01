using System.Collections;
using UnityEngine;

public class SoundFader : MonoBehaviour {

	public void fadein(float fadetime) {
		StartCoroutine(fadein_coroutine(GetComponent<AudioSource>(), fadetime));
	}

	private IEnumerator fadein_coroutine(AudioSource audioSource, float fadetime) {
		float init_volume = audioSource.volume;

		while (audioSource.volume > 0) {
			audioSource.volume -= init_volume * Time.deltaTime / fadetime;
			yield return null;
		}
		audioSource.Stop();
	}

	public void fadeout(float fadetime) {
		GetComponent<AudioSource>().Play(); 
		StartCoroutine(fadeout_coroutine(GetComponent<AudioSource>(), fadetime, 1));
	}

	private IEnumerator fadeout_coroutine(AudioSource audioSource, float fadetime, float final_volume) {
		float delta_volume = final_volume - audioSource.volume;

		while (audioSource.volume < 1) {
			audioSource.volume += delta_volume * (Time.deltaTime / fadetime);
			yield return null;
		}
	}
}