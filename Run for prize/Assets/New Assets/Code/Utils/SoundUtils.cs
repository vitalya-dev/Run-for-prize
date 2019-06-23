using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration {
    public class SoundUtils {
        public static void play_clip(AudioClip clip, float volume) {
            GameObject o = new GameObject("SoundFX" + clip.name);
            GameObject.Destroy(o, clip.length);
            /* ==================================================== */
            AudioSource audio_source = o.AddComponent<AudioSource>();
            audio_source.clip = clip;
            audio_source.volume = volume;
            audio_source.Play();
        }
    }
}