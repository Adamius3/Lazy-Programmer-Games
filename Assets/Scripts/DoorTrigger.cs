using UnityEngine;
using System.Collections;

/*
 * Coded by:
 * Timothy Garcia 300898955
 * 
 * Code to control door opening function
 */
public class DoorTrigger : MonoBehaviour {

	public DoorScript door;

	public bool ignoreTrigger;



	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
  
	//Method to call DoorOpens() method from DoorScript script when triggered
	void OnTriggerEnter2D(Collider2D other){

		if (ignoreTrigger)
						return;

		if (other.tag == "Player Projectile")
						door.DoorOpens();
      

		}

	void OnTriggerExit2D(Collider2D other){


		if (ignoreTrigger)
			return;

		if (other.tag == "Player Projectile")
			door.DoorCloses();
		
	}


	public void Toggle(bool state)
	{
		if (state)
			door.DoorOpens();
		else
			door.DoorCloses();
		}


	void OnDrawGizmos()
	{
		if (!ignoreTrigger) {
			BoxCollider2D box = GetComponent<BoxCollider2D>();

			Gizmos.DrawWireCube(transform.position, new Vector2(box.size.x,box.size.y));

				}


	}
}
