using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	public Text score_text;
	int score = 0;

	void Start() {
		if (score_text)
			score_text.text = score.ToString();
	}

	public void Scored() {
		score += 1;
		if (score_text)
			score_text.text = score.ToString();
	}

	public void Restart() {
		score = 0;
		if (score_text)
			score_text.text = score.ToString();
	}

}