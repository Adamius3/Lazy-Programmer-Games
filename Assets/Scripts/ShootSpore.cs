using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpore : MonoBehaviour {

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
