using UnityEngine;
using System.Collections;


/* 
 * Coded by:
 * Timothy Garcia
 * 
 * Script for button to trigger the door opening
 */
public class SwitchScript : MonoBehaviour 
{
	public DoorTrigger[] doorTrig;

	Animator anim;
	public bool target;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

    void OnTriggerStay2D()
	{
		anim.SetBool ("targetShot", true);
		foreach (DoorTrigger trigger in doorTrig)
		{
			trigger.Toggle(true);
		}
	}


	void OnTriggerExit2D()
	{
		if(target)
			return;
        anim.SetBool ("targetShot", true);

		foreach (DoorTrigger trigger in doorTrig) {
            
            trigger.Toggle(false);
			
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;

		foreach (DoorTrigger trigger in doorTrig) {
			
			Gizmos.DrawLine(transform.position,trigger.transform.position);
		}


		}


}
