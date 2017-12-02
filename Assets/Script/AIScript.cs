using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AIScript : MonoBehaviour {

	public int frameBeforeStart;
	//public ChangeMusic changeMusic;
	private ScoreCount scoreCount;

	// Use this for initialization
	public Transform target;
	public int moveSpeed;

	private Transform myTransform;

	// Use this for initialization
	void Awake() {
		myTransform = transform;
	}

	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		target = go.transform;
		GameObject gameObject = GameObject.FindGameObjectWithTag ("ScoreText");
		if (gameObject != null) {
			scoreCount = gameObject.GetComponent<ScoreCount>();
		}
	}

	// Update is called once per frame
	void Update () {    
			Vector3 dir = target.position - myTransform.position;
			dir.z = 0.0f; // Only needed if objects don't share 'z' value

		if ((dir.x < 0 && transform.localScale.x > 0) || (dir.x > 0 && transform.localScale.x < 0)) {
			Vector3 temp = transform.localScale;
			temp.x *= -1;
			transform.localScale = temp;
		}
			//Move Towards Target
			myTransform.position += (target.position - myTransform.position).normalized * moveSpeed * Time.deltaTime;
	}

	void OnDrawGizmos(){
		var scale = 2.0f;
		
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position, transform.position + transform.forward * scale);
		
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, transform.position + transform.right * scale);
		}

	void OnCollisionEnter2D(Collision2D col){
	if (col.gameObject.tag == "Player")
		{
			SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
			scoreCount.updateLife(false);
		}
	}
	
	// Update is called once per frame
	/*void Update () {
		if (frameBeforeStart != 0) {
						frameBeforeStart--;
		} else if(!changeMusic.freezeGame){
			//if (changeMusic.Boost)
			//	GetComponent<Renderer>().material.color = Color.white;
			//else
				GetComponent<Renderer>().material.color = Color.red;
						if (recentTurn) {
								frameBeforeTurn--;
								if (frameBeforeTurn == 0)
										recentTurn = false;
						}
			if(teleport && !chasePlayer){
				if(frameBeforeTeleport == 0){
					Teleport();
					frameBeforeTeleport = FramePerTeleport;
				}
				else frameBeforeTeleport--;
			}

						List<RaycastHit> hits = new List<RaycastHit> ();
						RaycastHit hitForward;
						RaycastHit hitBack;
						RaycastHit hitRight;
						RaycastHit hitLeft;
						if (Physics.Raycast (transform.position, transform.forward, out hitForward))
								hits.Add (hitForward);
						if (Physics.Raycast (transform.position, -transform.forward, out hitBack))
								hits.Add (hitBack);
						if (Physics.Raycast (transform.position, transform.right, out hitRight))
								hits.Add (hitRight);
			if (Physics.Raycast (transform.position, -transform.right, out hitLeft))
								hits.Add (hitLeft);
						bool moveDone = false;

						//Chase Player
						foreach (RaycastHit ray in hits) {
								if (ray.collider.tag.Equals ("Player")) { //See the player go to the player
										if(changeMusic.Boost){
												if(ray.Equals(hitForward))transform.position += (-transform.forward * chaseDpF);
												else transform.position += (transform.forward * chaseDpF);
										}else{
											if (ray.Equals (hitForward))
													transform.position += (transform.forward * chaseDpF);
											if (ray.Equals (hitBack))
													transform.position += (-transform.forward * chaseDpF);
											if (ray.Equals (hitRight))
													transform.position += (transform.right * chaseDpF);
											if (ray.Equals (hitLeft))
													transform.position += (-transform.right * chaseDpF);
											chasePlayer = true;
											moveDone = true;
										//}
										break;
								} 
						}


						if (!moveDone) {
				chasePlayer = false;
								if (turnLeft && !recentTurn && hitLeft.collider != null) {
										if ((hitLeft.collider.tag.Equals ("Untagged") && hitLeft.distance > 1.1f) || hitLeft.collider.tag.Equals ("Item")) {
												transform.Rotate (0, -90, 0);
												recentTurn = true;
												frameBeforeTurn = 120;
						moveDone = true;
										}
								} else if (!turnLeft && !recentTurn && hitRight.collider != null) {
										if ((hitRight.collider.tag.Equals ("Untagged") && hitRight.distance > 1.1f) || hitRight.collider.tag.Equals ("Item")) {
												transform.Rotate (0, 90, 0);
												recentTurn = true;
												frameBeforeTurn = 120;
						moveDone = true;
										}
								}
				if(!moveDone){
				if (hitForward.distance > 1.0f || !hitForward.collider.tag.Equals("Untagged"))
										transform.position += (transform.forward * patrolDpF);
					else if((hitBack.distance > 1.5f || !hitBack.collider.tag.Equals("Untagged")) && !recentTurn){
												transform.Rotate (0, 180, 0);
						recentTurn = true;
						frameBeforeTurn = 120;}
				else transform.Rotate (0, 90, 0);
				}

						}
				}
		}*/
}
