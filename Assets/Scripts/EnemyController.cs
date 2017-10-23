using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EnemyController : MonoBehaviour {
	public Transform player;

	private float speed;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player").transform;
		speed = 1;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, player.position, speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Ammo") {
			Destroy (this.gameObject);
		}

		if (other.gameObject.tag == "Player") {
			other.GetComponent<RigidbodyFirstPersonController> ().gameOver ();
		}	
	}

	public void setSpeed(float s){
		speed = s;
	}
}
