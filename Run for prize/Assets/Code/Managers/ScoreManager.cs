using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	public Text score_text;
	int score = 0;

	void Start() {
		score_text.text = score.ToString();
	}

	public void Scored() {
		score += 1;
		score_text.text = score.ToString();
	}

	public void Restart() {
		score = 0;
		score_text.text = score.ToString();
	}	

}
