using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CollectByPlayer : MonoBehaviour {

	public enum TypeObject{
		Collectable,
		Bonus,
		Boost
	};

	public int score;
	public TypeObject type;
	ScoreCount scoreCount;

	void Start(){
		GameObject gameObject = GameObject.FindGameObjectWithTag ("ScoreText");
		if (gameObject != null) {
			scoreCount = gameObject.GetComponent<ScoreCount>();
		}
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player") 
		{
			scoreCount.updateScore(score);
			Destroy(gameObject);
			if (type != TypeObject.Bonus && IsLastCollectable ()) {
				PlayerPrefs.Save ();
				SceneManager.LoadScene ("TestScene");
				//Application.LoadLevel ("TestScene");
			}
		}
	}

	bool IsLastCollectable(){
		List<GameObject> itemList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Item"));
		bool lastItem = false;
		foreach (GameObject item in itemList) {
			if(item.name.Contains("TestBonus") || item.name.Contains("CollectBoost")){
				if(lastItem) return false;
				lastItem = true;
			}
		}
		return true;
	}
}
