using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/* 
 * Coded by:
 * Timothy Garcia
 * 
 * Player Controller script the has the functions for movement and shooting
 */
public class PlayerController : MonoBehaviour {


    //movement variable
    public float maxSpeed;

    //jumping variables
    bool grounded = false;
    bool shooting = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    public Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight;

    //for shooting
    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0f;

	
    // Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        facingRight = true;
	}

    //update is called once per frame
    void Update()
    {
        if(grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("isGrounded",grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));
        }

        //player shooting
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            FireRocket();
            myAnim.SetBool("isShooting", true);
        }
        if(Input.GetAxisRaw("Fire1") <= 0)
        {
            myAnim.SetBool("isShooting", shooting);
        }
            
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //check if we are grounded, if no- then we are falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));
        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void FireRocket() 
    { 
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }else if (!facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EndFlag")
        { SceneManager.LoadScene("WinScene"); }
    }

}
