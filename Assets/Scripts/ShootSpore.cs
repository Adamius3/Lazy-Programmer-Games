using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Coded by:
 * Timothy Garcia
 * 
 * Code to control Cannon plant object to shoot out spores
 */
public class ShootSpore : MonoBehaviour 
{
    //Cannon plant spore spawn and animation variables
    public GameObject theProjectile;
    public float shootTime;
    public int chanceShoot;
    public Transform shootFrom;
    public EnemyHealth enemyDeath;
    float nextShootTime;
    Animator cannonAnim;

	// Use this for initialization
	void Start () {
        cannonAnim = GetComponentInChildren<Animator>();
        nextShootTime = 0f;
		
	}


    // Update is called once per frame
    //Method to insantiate a spore gameObject when player activates a trigger within Cannon plant
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && nextShootTime < Time.time && enemyDeath.death == false )
        {
            nextShootTime = Time.time + shootTime;
            if(Random.Range(0,10) >= chanceShoot)
            {
                Instantiate(theProjectile, shootFrom.position, Quaternion.identity);
                cannonAnim.SetTrigger("cannonShoot");
            }
        }        
    }
}
