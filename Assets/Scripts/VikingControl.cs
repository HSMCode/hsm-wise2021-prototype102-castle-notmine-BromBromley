using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VikingControl : MonoBehaviour
{ 
    public int maxShield = 100;
    public int currentShield;

    public int maxHealth = 100;
    public int currentHealth;

    public ShieldBar shieldBar;
    public HealthBar healthBar;

    private bool redField = false;
    private bool blueField = false;
    private bool greenField = false;
    private bool ActiveSpace = false;

    private AudioSource audio;
    private Animator animator;

    private ParticleSystem shieldParticle1System;
    private ParticleSystem shieldParticle2System;

    private int moveSpeed = 3;

    void Start()
    {
        currentShield = maxShield;
        shieldBar.SetMaxShield(maxShield);
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        Time.fixedDeltaTime = 0.075f;

        audio = GetComponent<AudioSource>();

        animator = GetComponent<Animator>();

        shieldParticle1System = GameObject.Find("ShieldParticles01").GetComponent<ParticleSystem>();
        shieldParticle2System = GameObject.Find("ShieldParticles02").GetComponent<ParticleSystem>();

    }
 
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    
        // Activate Shield while holding Spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivateShield();
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            DeactivateShield();
        }

        if (currentHealth < 1)
        {
            GameOverMessage.reachedMidgard = false;
            FindObjectOfType<GameManagerScript>().GameOver();
        }
    }

    private void FixedUpdate()
    {
        if (ActiveSpace == true)
        {
            DrainShield(1);

            if (currentShield < 1)
            {
                DeactivateShield();
            }

        }

        else
        {
            RestoreShield(1);

            if (blueField == true)
            {
                RestoreShield(2);
            }

            if (redField == true)
            {
                DrainHealth(3);
                if (!audio.isPlaying)
                {
                    audio.Play();
                }
            }

            if (greenField == true)
            {
                RestoreHealth(1);
            }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "RedField")
        {
            redField = true;
        }
        if (col.gameObject.tag == "BlueField")
        {
            blueField = true;
        }
        if (col.gameObject.tag == "GreenField")
        {
            greenField = true;
        }
        if (col.gameObject.tag == "YellowField")
        {
            greenField = true;
            blueField = true;
            GameOverMessage.reachedMidgard = true;
            FindObjectOfType<GameManagerScript>().GameOver();
        }
    }


    private void ActivateShield()
    {
        ActiveSpace = true;
        animator.Play("ShieldUp", 0, 0.25f);
        shieldParticle1System.Play();
        shieldParticle2System.Play();
    }

    private void DeactivateShield()
    {
        ActiveSpace = false;
        animator.Play("Walk", 0, 0.25f);
        shieldParticle1System.Stop();
        shieldParticle2System.Stop();
    }


    private void RestoreHealth(int amount)
    {
        currentHealth += amount;
        healthBar.SetHealth(currentHealth);
    }

    private void DrainHealth(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);  
    }

    public void RestoreShield(int restoreAmount)
    {
        if (currentShield < maxShield)
        {
            currentShield += restoreAmount;
            shieldBar.SetShield(currentShield);
        }        
    }

    public void DrainShield(int drainAmount)
    {
        if (currentShield > 0)
        {
            currentShield -= drainAmount;
            shieldBar.SetShield(currentShield);
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "RedField")
        {
            redField = false;
        }
        if (col.gameObject.tag == "BlueField")
        {
            blueField = false;
        }
        if (col.gameObject.tag == "GreenField")
        {
            greenField = false;
        }
    }
}
