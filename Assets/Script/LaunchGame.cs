using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaunchGame : MonoBehaviour {

	public bool launch;
	public Text text;

	void OnMouseOver () {
		//GetComponent<Renderer>().material.color = Color.yellow;
		text.color = Color.yellow;
	}

	void OnMouseExit () {
		//GetComponent<Renderer>().material.color = Color.white;
		text.color = Color.white;
	}

	void OnMouseDown(){
		if (launch) {
						PlayerPrefs.SetInt ("Score", 0);
						PlayerPrefs.SetInt ("Life", 3);
						PlayerPrefs.Save ();
						SceneManager.LoadScene ("TheHouse");
				} else {
			Application.Quit();
				}
	}
}
