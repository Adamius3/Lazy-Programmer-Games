using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Coded by:
 * Timothy Garcia 300898955
 * Code to speed and force of projectile
 */
public class ProjectileController : MonoBehaviour {

    public float projectileSpeed;

    Rigidbody2D myRB;
	
    // Use this for initialization
    // Method to control the rigidbody and add a force to go straight left or right(depending where player is facing)
	void Awake () {

        myRB = GetComponent<Rigidbody2D>();

        if(transform.localRotation.z>0)
            myRB.AddForce(new Vector2(-1, 0) * projectileSpeed,ForceMode2D.Impulse);
        else myRB.AddForce(new Vector2(1, 0) * projectileSpeed, ForceMode2D.Impulse);
    }
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void removeForce()
    {
        myRB.velocity = new Vector2(0, 0);
    }
}
