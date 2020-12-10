using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    		
	}

    //Triggers the WinGame() method from PlayerHealth script on contact
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealth playerWins = other.gameObject.GetComponent<PlayerHealth>();
            playerWins.WinGame();
        }
    }
}
