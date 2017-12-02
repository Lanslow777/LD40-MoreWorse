using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreCount : MonoBehaviour {

	int score = 0;
	int life = 3;
	public GUIText ScoreText;
	public GUIText LifeText;
	public int scoreToLife;

	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt ("Score", 0);
		life = PlayerPrefs.GetInt ("Life", 3);
		ScoreText.text = "Score : " + score;
		LifeText.text = "Life : " + life;
	}

	public void updateScore (int addScore){
		score += addScore;
		PlayerPrefs.SetInt ("Score", score);
		ScoreText.text = "Score : " + score;
		PlayerPrefs.SetFloat ("VitMax", PlayerPrefs.GetFloat ("VitMax", 10f)-1);
		PlayerPrefs.SetFloat ("JumpMax", PlayerPrefs.GetFloat ("JumpMax", 400f)-10);
		if (score != 0 && score % scoreToLife == 0)
						updateLife (true);
	}

	public void updateLife (bool addLife){
		if (addLife)
						life++;
				else
						life--;
		PlayerPrefs.SetInt ("Life", life);
		LifeText.text = "Life : " + life;
				if(life == 0) SceneManager.LoadScene ("EndScene");//Application.LoadLevel ("EndScene");
	}
}
