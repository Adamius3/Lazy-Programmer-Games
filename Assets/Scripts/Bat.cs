using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    private int chealth = 10;
    public Animator animator;


    public float speed = 3f;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) < 9)
        {

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);





        }
        animator.SetFloat("Speed", Mathf.Abs(speed));

        if (chealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage(int damage)
    {
        chealth -= damage;
        gameObject.GetComponent<Animation>().Play("DamageIndicator");


    }
}
