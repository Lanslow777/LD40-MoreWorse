using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScriptShooter : MonoBehaviour {
	public Transform target;
	public int rechargeTime;

	private Transform myTransform;
	WorldGenerator generator;

	// Use this for initialization
	void Awake() {
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag ("Player");
		target = go.transform;

		GameObject gameObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameObject != null) {
			generator = gameObject.GetComponent<WorldGenerator>();
		}
	}

	int fireTime = 0;
	// Update is called once per frame
	void Update () {
		Vector3 dir = target.position - myTransform.position;
		dir.z = 0.0f; // Only needed if objects don't share 'z' value

		if ((dir.x < 0 && transform.localScale.x > 0) || (dir.x > 0 && transform.localScale.x < 0)) {
			Vector3 temp = transform.localScale;
			temp.x *= -1;
			transform.localScale = temp;
		}

		fireTime++;
		if (fireTime == rechargeTime) {
			fireTime = 0;
			generator.SpawnBullet (transform, target);
		}
	}
}
