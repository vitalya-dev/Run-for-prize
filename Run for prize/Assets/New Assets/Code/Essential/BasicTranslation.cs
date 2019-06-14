﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGeneration {
    public class BasicTranslation : MonoBehaviour {
        private bool _moving = false;
        public bool moving {
            get {
                return _moving;
            }
        }

        public void move(string input_json) {
            SpaceAndTime input = JsonUtility.FromJson<SpaceAndTime>(input_json);
            move(new Vector3(input.x, input.y, input.z), input.t, (Space)input.relativeTo);
        }

        public void move(Vector3 dest, float time, Space relativeTo) {
            if (!moving) {
                _moving = true;
                if (relativeTo == Space.World)
                    StartCoroutine(move_routine(dest, time));
                else if (relativeTo == Space.Self)
                    StartCoroutine(move_routine(transform.position + dest, time));
            }
        }

        private IEnumerator move_routine(Vector3 dest, float time) {
            Vector3 start_pos = transform.position;
            float elapsed_time = 0;
            do {
                elapsed_time += Time.deltaTime;
                transform.position = Vector3.Lerp(start_pos, dest, elapsed_time / time);
                yield return null;
            } while (elapsed_time / time < 1);
            _moving = false;
        }
    }
}