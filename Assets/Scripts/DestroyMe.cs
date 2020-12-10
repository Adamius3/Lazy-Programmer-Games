using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour {


    public float aliveTime;


    // Use this for initialization
	//Destroy gameObject after a certain amount of time
    void Awake () {

        Destroy(gameObject, aliveTime);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
