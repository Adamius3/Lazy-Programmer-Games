using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Coded by:
 * Timothy Garcia 300898955
 * Code to damage enemies 
 */
public class RocketHit : MonoBehaviour {

    public int weaponDamage;

    ProjectileController myPC;

    public GameObject explosionEffect;

	// Use this for initialization
	void Awake () {
        myPC = GetComponentInParent<ProjectileController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Code to damage Boar and Bat enemy with layer Shootable and instantiate projectile collision animation
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if(other.tag == "Enemy")
            {
                EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.addDamage(weaponDamage);
            }
            if(other.tag == "BatEnemy")
            {
                Bat batDamaged = other.gameObject.GetComponent<Bat>();
                batDamaged.Damage(weaponDamage);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.tag == "Enemy")
            {
                EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }

    }
}
