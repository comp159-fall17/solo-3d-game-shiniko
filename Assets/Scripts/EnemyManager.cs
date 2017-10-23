using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
	public Transform player;
	public GameObject enemyPrefab;
	public float speed;
	public int totalEnemies;
	public int enemyRange;

	private List<GameObject> listOfEnemies;
	private int tempTotalEnemies;

	// Use this for initialization
	void Start () {
		listOfEnemies = new List<GameObject> ();
		totalEnemies = tempTotalEnemies;
	}
	
	// Update is called once per frame
	void Update () {
		if (listOfEnemies.Count == 0) {
			startWave ();
		}
		Debug.Log (listOfEnemies.Count);
	}

	void startWave(){
		tempTotalEnemies = totalEnemies;
		for (int i = 0; i < totalEnemies; i++) {
			createEnemy ();
		}
		increaseTotalEnemies ();
	}

	void increaseTotalEnemies(){
		totalEnemies += 2;
	}
	void createEnemy(){
		Vector3 enemyPos = transform.position;

		//Generate a Random offset based on current pos of attached enemy object
		enemyPos.x += RandomOffset(enemyRange);
		enemyPos.y += RandomOffset (enemyRange);
		enemyPos.z += RandomOffset (enemyRange);

		//Check that enemies are not spawning within 5 units of each other
		while ((Mathf.Abs (enemyPos.x - player.transform.position.x) < 5) && (Mathf.Abs (enemyPos.z - player.transform.position.z) < 5) && (Mathf.Abs (enemyPos.y - player.transform.position.y) < 5)) {
			//Generate a Random offset based on current pos of attached enemy object
			enemyPos.x += RandomOffset(enemyRange);
			enemyPos.y += RandomOffset(enemyRange);
			enemyPos.z += RandomOffset (enemyRange);
		}

		//Create a new Enemy at enemypos with the same orientation as the main camera
		GameObject enemy = (GameObject)Instantiate (enemyPrefab,enemyPos,Camera.main.transform.rotation);
		enemy.GetComponent<EnemyController> ().setSpeed (speed);
		enemy.GetComponent<EnemyController> ().setPlayer (player);
		listOfEnemies.Add (enemy);
	}

	private float RandomOffset(float offsetSize){
		return Random.Range (-offsetSize/2.0f,offsetSize/2.0f);
	}

	public void removeEnemy(){
		listOfEnemies.RemoveAt (tempTotalEnemies - 1);
		tempTotalEnemies -= 1;
	}

}
