﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class CollectByPlayer : MonoBehaviour {

	public enum TypeObject{
		Collectable,
		Bonus,
		Boost
	};

	public int score;
	public TypeObject type;
	ScoreCount scoreCount;
	WorldGenerator generator;
	bool touch = false;

	void Start(){
		GameObject gameObject = GameObject.FindGameObjectWithTag ("ScoreText");
		if (gameObject != null) {
			scoreCount = gameObject.GetComponent<ScoreCount>();
		}
		gameObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameObject != null) {
			generator = gameObject.GetComponent<WorldGenerator>();
		}
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player" & !touch) 
		{
			touch = true;
			scoreCount.updateScore(score);
			Destroy(gameObject);
			if (type == TypeObject.Bonus) {
				PlayerPrefs.SetFloat ("VitMax", PlayerPrefs.GetFloat ("VitMax", 10f) - 1);
				PlayerPrefs.SetFloat ("JumpMax", PlayerPrefs.GetFloat ("JumpMax", 400f) - 10);
			}
			else if(type == TypeObject.Boost){
				PlayerPrefs.SetFloat ("VitMax", PlayerPrefs.GetFloat ("VitMax", 10f) + 1);
				PlayerPrefs.SetFloat ("JumpMax", PlayerPrefs.GetFloat ("JumpMax", 400f) + 10);
			}


			/*if (type != TypeObject.Bonus && IsLastCollectable ()) {
				PlayerPrefs.Save ();
				SceneManager.LoadScene ("TestScene");
				//Application.LoadLevel ("TestScene");
			}*/
		}
	}
		
	public void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player" & !touch) 
		{
			bool gift = false;
			touch = true;
			scoreCount.updateScore(score);
			Destroy(gameObject);
			if (type == TypeObject.Bonus) {
				PlayerPrefs.SetFloat ("VitMax", Math.Max(PlayerPrefs.GetFloat ("VitMax", 10f) - 1, 1));
				PlayerPrefs.SetFloat ("JumpMax", Math.Max(PlayerPrefs.GetFloat ("JumpMax", 400f) - 10, 10));
				gift = true;
			}
			else if(type == TypeObject.Boost){
				PlayerPrefs.SetFloat ("VitMax", PlayerPrefs.GetFloat ("VitMax", 10f) + 1);
				PlayerPrefs.SetFloat ("JumpMax", PlayerPrefs.GetFloat ("JumpMax", 400f) + 10);
			}

			generator.SpawnObject ((UnityEngine.Random.Range (0, 100) % 2 == 0), gift);
			generator.SpawnObject ((UnityEngine.Random.Range (0, 100) % 2 == 0), false);
			/*if (type != TypeObject.Bonus && IsLastCollectable ()) {
				PlayerPrefs.Save ();
				SceneManager.LoadScene ("TestScene");
				//Application.LoadLevel ("TestScene");
			}*/
		}
	}

	/*bool IsLastCollectable(){
		List<GameObject> itemList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Item"));
		bool lastItem = false;
		foreach (GameObject item in itemList) {
			if(item.name.Contains("TestBonus") || item.name.Contains("CollectBoost")){
				if(lastItem) return false;
				lastItem = true;
			}
		}
		return true;
	}*/
}
