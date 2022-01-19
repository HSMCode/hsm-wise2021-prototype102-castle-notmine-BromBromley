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

   private int moveSpeed = 3;

    void Start()
    {
        currentShield = maxShield;
        shieldBar.SetMaxShield(maxShield);
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        Time.fixedDeltaTime = 0.1f;

        audio = GetComponent<AudioSource>();

    }
 
    void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    
        // Activate Shield while holding Spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActiveSpace = true;
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ActiveSpace = false;
        }

        if (currentHealth < 1)
        {
            FindObjectOfType<GameManagerScript>().GameOver();
        }
    }

    private void FixedUpdate()
    {
        if (ActiveSpace == true)
        {
            DrainShield(1);
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
