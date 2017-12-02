using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class WorldGenerator : MonoBehaviour
{
	public int Iterations = 5;
	public int CollectablePerBoost;
	public GameObject MalusPrefab;
	public GameObject BonusPrefab;


	void Start()
	{
		/*Iterations = PlayerPrefs.GetInt("Size", 20);
		int nbBad = PlayerPrefs.GetInt("Ennemies", 5);
		for (int i = 0; i < nbBad-1; i++) {
			var newModulePrefab = GameObject.FindGameObjectWithTag("BadGuy");
			GameObject newModule =(GameObject) Instantiate(newModulePrefab);
			newModule.transform.position = new Vector3(0, 1f, 0.3f);
			AIScript script = (AIScript)newModule.GetComponent("AIScript");
			script.turnLeft = (Random.Range(0, 100) % 2 == 0);
			script.teleport = (Random.Range(0, 100) % 2 == 0);
				}*/
	}

	int bonusPop = 0;
	void Update(){
		/*if (bonusPop > 3000) {
			List<GameObject> mazeList = new List<GameObject>(GameObject.FindGameObjectsWithTag("MazeComponent"));
			List<GameObject> itemList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Item"));
			GameObject bonus = (GameObject)Instantiate(BonusPrefab);
			bonus.transform.position = mazeList[Random.Range(0, mazeList.Count)].transform.position + Vector3.up;
			foreach(GameObject obj in itemList){
				if(obj.transform.position == bonus.transform.position){
					GameObject.Destroy(bonus);
					break;
				}
			}
			bonusPop = 0;
				} else
						bonusPop++;*/
		}
		
	public void SpawnObject(bool bonus){
		GameObject newModulePrefab;
		if(bonus) newModulePrefab = BonusPrefab;
		else newModulePrefab = MalusPrefab;
		GameObject newModule =(GameObject) Instantiate(newModulePrefab);
		newModule.transform.position = new Vector2(Random.Range (-13, 13), 8);
	}
}
