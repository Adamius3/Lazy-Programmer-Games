using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 jump;
    public float thrust = 10.0f;
    public float jumpThrust = 2.0f;

    public Rigidbody2D rb;

    public bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);        // Old Code: transform.position = new Vector3(0.0f, 2.0f, 0.0f);
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground") { grounded = true; }     
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && grounded == true)
        {

            rb.AddForce(jump * jumpThrust, ForceMode2D.Impulse);
            grounded = false;
            Debug.Log("W pressed");

        }
    }
  
    void FixedUpdate()
    {
       
        if (Input.GetKey(KeyCode.D)) 
        {
            rb.AddForce(transform.right * thrust);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(transform.up * -thrust);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(transform.right * -thrust);
        }
    }
}
