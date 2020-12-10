using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Coded by:
 * Timothy Garcia 300898955
 */
public class RestartGame : MonoBehaviour {

    public float restartTime;
    bool restartNow = false;
    float resetTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (restartNow && resetTime <= Time.time)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
	}

    //Method to restart after a certain amount of time
    public void RestartTheGame()
    {
        restartNow = true;
        resetTime = Time.time + restartTime;
    }
}
