﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBehavior : MonoBehaviour {

	public float lifetime = 7f;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		Destroy (this, lifetime);
		rb = GetComponent<Rigidbody> ();
		rb.AddForce (rb.transform.forward);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
