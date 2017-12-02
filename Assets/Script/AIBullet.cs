using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIBullet : MonoBehaviour {
	private Transform myTransform;
	private ScoreCount scoreCount;
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
		GameObject gameObject = GameObject.FindGameObjectWithTag ("ScoreText");
		if (gameObject != null) {
			scoreCount = gameObject.GetComponent<ScoreCount>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Move Towards Target
		myTransform.position += direction * moveSpeed * Time.deltaTime;
	}

	bool touch = false;
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player" && !touch)
		{
			touch = true;
			SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
			scoreCount.updateLife(false);
		}
		else if(col.gameObject.tag != "Indestructible"){
			Destroy(col.gameObject);
		}
		Destroy(gameObject);
	}
}
