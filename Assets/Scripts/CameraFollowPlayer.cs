using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Coded by:
 * Timothy Garcia
 * 
 * Code for the camera to follow player
 */
public class CameraFollowPlayer : MonoBehaviour {

    public Transform target;  //Target the camera is following
    public float smoothing; //dampening effect

    Vector3 offset;
    float lowY;

	// Use this for initialization
	void Start () 
    {
        offset = transform.position - target.position;
        lowY = transform.position.y;
	}
	
	//Follows player
	void FixedUpdate () 
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        if (transform.position.y < lowY) transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
	}
}
