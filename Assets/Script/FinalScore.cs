using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

	public Text textMesh;

	// Use this for initialization
	void Start () {
		textMesh.text = "Score : " + PlayerPrefs.GetInt ("Score", 0);
	}
}
