using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EnemyController : MonoBehaviour {
	private Transform player;
	private float speed;

	private GameObject gameObj;
	private EnemyManager thisGameObj;

	// Use this for initialization
	void Start () {
		//speed = 1;
		gameObj = GameObject.FindGameObjectWithTag ("EnemyManager");
		thisGameObj = gameObj.GetComponent<EnemyManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, player.position, speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Ammo") {
			thisGameObj.removeEnemy ();
			Destroy (this.gameObject);
		}

		if (other.gameObject.tag == "Player") {
			thisGameObj.gameOver ();
		}	
	}

	public void setSpeed(float s){
		speed = s;
	}

	public void setPlayer(Transform p){
		player = p;
	}

	public void destroyEnemy(){
		Destroy (this.gameObject);
	}
}
