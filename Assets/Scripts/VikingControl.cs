using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VikingControl : MonoBehaviour
{ 
    public int maxShield = 100;
   public int currentShield;

   public ShieldBar shieldBar;

   private bool collision = true;

   private int moveSpeed = 3;
   private GameManager _gameManager; 

    void Start()
    {
        currentShield = maxShield;
        shieldBar.SetMaxShield(maxShield);

        _gameManager = FindObjectOfType<GameManager>();

        Time.fixedDeltaTime = 0.5f;
    }
 
     void Update()
     {
         // automatic movement of the player character
        if (_gameManager.inputActive == true)
         {
             transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
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
         TakeDamage(10);
         Debug.Log("Collision");
         collision = true;
     }
     
    private void TakeDamage(int damage)
    {
        currentShield -= damage;

        shieldBar.SetShield(currentShield);
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
