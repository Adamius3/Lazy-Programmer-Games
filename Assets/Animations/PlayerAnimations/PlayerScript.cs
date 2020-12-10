using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Coded by:
 * Timothy Garcia 300898955
 */

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 5f;

    private Animator anim;

    private float xAxis;
    private float yAxis;
    private Rigidbody2D rb2d;
    private bool isJumpPressed;
    private float jumpForce = 850;
    private int groundMask;
    private bool isGrounded;
    private string currentAnimaton;
    private bool isAttackPressed;
    private bool isAttacking;

    [SerializeField]
    private float attackDelay = 0.3f;

    const string PLAYER_IDLE = "Player_idle";
    const string PLAYER_RUN = "Player_run";
    const string PLAYER_JUMP = "Player_jump";
    const string PLAYER_ATTACK = "Player_attack";
    const string PLAYER_ATTACKRUN = "Player_attackRun";

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        groundMask = 1 << LayerMask.NameToLayer("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");

        //space jump key pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumpPressed = true;
        }

        //space Attack key pressed?
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            isAttackPressed = true;
        }
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundMask);

        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //------------------------------------------

        //Check update movement based on input
        Vector2 vel = new Vector2(0, rb2d.velocity.y);

        if (xAxis < 0)
        {
            vel.x = -walkSpeed;
            transform.localScale = new Vector2(-1, 1);
        }
        else if (xAxis > 0)
        {
            vel.x = walkSpeed;
            transform.localScale = new Vector2(1, 1);

        }
        else
        {
            vel.x = 0;

        }

        if (isGrounded && !isAttacking)
        {
            if (xAxis != 0)
            {
                ChangeAnimationState(PLAYER_RUN);
            }
            else
            {
                ChangeAnimationState(PLAYER_IDLE);
            }
        }

        if (isJumpPressed && isGrounded)
        {
            rb2d.AddForce(new Vector2(0, jumpForce));
            isJumpPressed = false;
            ChangeAnimationState(PLAYER_JUMP);
        }


        //assign the new velocity to the rigidbody
        rb2d.velocity = vel;


        //attack
        if (isAttackPressed)
        {
            isAttackPressed = false;

            if (!isAttacking)
            {
                isAttacking = true;

                if (isGrounded)
                {
                    ChangeAnimationState(PLAYER_ATTACK);
                }
                if(xAxis != 0)
                {
                    ChangeAnimationState(PLAYER_JUMP);
                }
                Invoke("AttackComplete", attackDelay);
            }
        }
    }

    void AttackComplete()
    {
        isAttacking = false;
    }

    //=====================================================
    // mini animation manager
    //=====================================================
    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        anim.Play(newAnimation);
        currentAnimaton = newAnimation;
    }

}
