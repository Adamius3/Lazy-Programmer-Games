using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Timothy Garcia 300898955
 */

public class PlayerHealth : MonoBehaviour 
{
    //Player health and damage effects
    public float fullHealth;
    public GameObject deathFX;
    public AudioClip playerHurt;
    float currentHealth;

    public RestartGame theGameManager;
    PlayerController controlMovement;
    public AudioClip playerDeathSound;
    AudioSource playerAS;

    //HUD Variables
    public Slider healthSlider;
    public Image damageScreen;
    public Text gameOverScreen;
    public Text winGameScreen;

    bool damaged = false;
    Color damagedColour = new Color(0f, 0f, 0f, 0.5f);
    float smoothColour = 5f;

	// Use this for initialization
	void Start () 
    {
        currentHealth = fullHealth;
        controlMovement = GetComponent<PlayerController>();

        //HUD Initialization
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;

        damaged = false;

        playerAS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (damaged)
        {
            damageScreen.color = damagedColour;
        }
        else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColour * Time.deltaTime);
        }
        damaged = false;
	}

    //Method to damage player and call MakeDead() method when health is 0 or below
    public void AddDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;

        playerAS.clip = playerHurt;
        playerAS.Play();

 //     playerAS.PlayOneShot(playerHurt);

        healthSlider.value = currentHealth;
        damaged = true;

        if (currentHealth <= 0)
        {
            MakeDead();
        }
    }


    //Method to show health slider and to limit amount of health received from health drops to not go over max health.
    public void AddHealth(float healthAmount)
    {
        currentHealth += healthAmount;
        if (currentHealth > fullHealth) currentHealth = fullHealth;
        healthSlider.value = currentHealth;
    }

    //Method to destroy player gameObject and restart level using RestartTheGame() method from RestartGame script
    public void MakeDead()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(playerDeathSound, transform.position);
        damageScreen.color = damagedColour;

        Animator gameOverAnimator = gameOverScreen.GetComponent<Animator>();
        gameOverAnimator.SetTrigger("gameOver");
        theGameManager.RestartTheGame();
    }

    //Method to call the RestartTheGame() method from RestartGame script
    public void WinGame()
    {
        Destroy(gameObject);
        theGameManager.RestartTheGame();
        Animator winGameAnimator = winGameScreen.GetComponent<Animator>();
        winGameAnimator.SetTrigger("gameOver");
    }
}
