﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Coded by:
 * Timothy Garcia 300898955
 * Code to control the force of the spore that spawns from cannon plant.
 */
public class SporeController : MonoBehaviour {

    public float sporeSpeedHigh;
    public float sporeSpeedLow;
    public float sporeAngle;
    public float sporeTorqueAngle;
    Rigidbody2D sporeRB;

	// Use this for initialization
	void Start () {
        sporeRB = GetComponent<Rigidbody2D>();
        sporeRB.AddForce(new Vector2(Random.Range(-sporeAngle, sporeAngle), Random.Range(sporeSpeedLow, sporeSpeedHigh)), ForceMode2D.Impulse);
        sporeRB.AddTorque((Random.Range(-sporeTorqueAngle, sporeTorqueAngle)));
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
