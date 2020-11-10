using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public GameObject spawnPoint;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Destroy(other.gameObject);
        if(other.transform.tag == "Death") {

            this.transform.position = spawnPoint.transform.position;
               
        }
    }
}
