using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/*Timothy Garcia 300898955
 *Sarmad Siddiqi
*/
public class Bat : MonoBehaviour
{
    //Damage variables and animations
    public Animator animator;
    public float damage;
    public float damageRate;
    public float pushBackForce;
    float nextDamage;

    //Health Variables
    public float enemyMaxHealth;
    public GameObject enemyDeathFX;
    public Slider enemySlider;
    public bool death = false;
    public bool drops;
    public GameObject theDrop;
    float currentHealth;

    public AudioClip deathKnell;
    public float speed = 3f;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        currentHealth = enemyMaxHealth;
        enemySlider.maxValue = currentHealth;
        enemySlider.value = currentHealth;
    }

    // Update is called once per frame
    // Animates the bat and moves toward the Player
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) < 9)
        {

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        animator.SetFloat("Speed", Mathf.Abs(speed));
    }

    //Damage method that calls the Dead() method when health drops to 0 or below.
    public void Damage(int damage)
    {
        enemySlider.gameObject.SetActive(true);
        currentHealth -= damage;
        enemySlider.value = currentHealth;

        if (currentHealth <= 0) Dead(); //Calls the Dead() method
    }

    //Dead method when bat gets killed by player
    void Dead()
    {
        death = true;
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathKnell, transform.position);
        Instantiate(enemyDeathFX, transform.position, transform.rotation); 
        if (drops) Instantiate(theDrop, transform.position, transform.rotation); //Method to spawn a drop when killed
    }

    //Damages player on contact
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && nextDamage < Time.time)
        {
            PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
            thePlayerHealth.AddDamage(damage);
            nextDamage = Time.time + damageRate;

            pushBack(other.transform);
        }
    }

    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
