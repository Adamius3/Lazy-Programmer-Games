using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* 
 * Coded by:
 * Timothy Garcia
 * 
 * Code for health drop gameObject
 */
public class HealthPickup : MonoBehaviour {

    public float healthAmount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Method to add health to player when player collides with health gameObject
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealth theHealth = other.gameObject.GetComponent<PlayerHealth>();
            theHealth.AddHealth(healthAmount);
            Destroy(gameObject);
        }
    }
}
