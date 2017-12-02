﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIBullet : MonoBehaviour {
	private Transform myTransform;
	private Vector3 direction;
	private bool goal;
	public Vector3 target;
	public int moveSpeed;

	// Use this for initialization
	void Awake() {
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {
		direction = (target - myTransform.position).normalized;
	}
	
	// Update is called once per frame
	void Update () {
		//Move Towards Target
		myTransform.position += direction * moveSpeed * Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player")
		{
			SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
		}
		else if(col.gameObject.tag != "Indestructible"){
			Destroy(col.gameObject);
		}
		Destroy(gameObject);
	}
}
