using UnityEngine;
using System.Collections;

/*
 * Coded by:
 * Timothy Garcia 300898955
 * 
 * Code to control door opening animation
 */
public class DoorScript : MonoBehaviour 
{
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Method for door opening animation
	public void DoorOpens()
	{
		anim.SetBool ("Opens", true);
		}

	public void DoorCloses()
	{
		anim.SetBool ("Opens", true);
	}

	void CollEnable()
	{
		GetComponent<Collider2D>().enabled = true;
	}

	void CollDisable()
	{
		GetComponent<Collider2D>().enabled = false;
	}



}
