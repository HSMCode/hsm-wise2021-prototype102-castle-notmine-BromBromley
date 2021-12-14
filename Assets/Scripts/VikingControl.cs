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

   private bool collision = true;
   private bool ActiveSpace = false;

   private AudioSource argh;

   private int moveSpeed = 3;
   private GameManager _gameManager; 

    void Start()
    {
        currentShield = maxShield;
        shieldBar.SetMaxShield(maxShield);
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        _gameManager = FindObjectOfType<GameManager>();

        Time.fixedDeltaTime = 0.5f;

        argh = GetComponent<AudioSource>();

    }
 
     void Update()
     {
         // automatic movement of the player character
        if (_gameManager.inputActive == true)
         {
             transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
         }
    
        // Drücken der Leertaste ermöglicht das Aktivieren von Schild
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Pressed Spacebar");
            ActiveSpace = true;
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ActiveSpace = false;
        }

    }


     private void FixedUpdate()
     {
         if (collision == false)
         {
             RestoreShield(1);
             Debug.Log("No Collision");
         }
     }


     private void OnCollisionEnter(Collision other)
     {
        collision = true;

        if (ActiveSpace == true)
        {  
         TakeDamageShield(10);
         Debug.Log("Collision");
        }
        else
        {
         TakeDamageHealth(10);
         argh.Play();
         Debug.Log("Collision");
        }
     }
     

    private void TakeDamageShield(int damage)
    {
        currentShield -= damage;
        shieldBar.SetShield(currentShield);
    }

    private void TakeDamageHealth(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);  
    }

    public void RestoreShield(int restoreAmount)
    {
        currentShield += restoreAmount;
        shieldBar.SetShield(currentShield);
    }

    private void OnCollisionExit(Collision other)
    {
        Debug.Log("Exit");
        collision = false;
    }



    //walking over a red field with deactivated shield
         /*   private void OnCollisionEnter(Collision collision)
            {
            if (collision.gameObject.tag == "RedField")
                {
                _gameManager.GameIsOver();
                Destroy(this.gameObject);
                }
            } */

}
