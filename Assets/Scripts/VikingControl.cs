using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VikingControl : MonoBehaviour
{
    public int maxShield = 100;
    public int currentShield = 0;
    public ShieldBar shieldBar;
    private int moveSpeed = 3;
    private GameManager _gameManager;

    void Start()
    {
        currentShield = maxShield;

        _gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // automatic movement of the player character
        if (_gameManager.inputActive == true)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        // shield activation
        if (Input.GetKey(KeyCode.Space))
        {
            LooseHealth();
        }
        else
        {
            GainHealth();
        }
        Debug.Log(currentShield);
    }
    

    void LooseHealth()
    {
        if (currentShield > 0)
        {
            currentShield -= 1;
            shieldBar.SetHealth(currentShield);
            Debug.Log("using shield " + currentShield);
        }
    }

    void GainHealth()
    {
        if (currentShield < 100)
        {
            currentShield += 1;
            shieldBar.SetHealth(currentShield);
            Debug.Log("NOT using shield " + currentShield);
        }
    }

    //walking over a red field with deactivated shield
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "RedField")
        {
            _gameManager.GameIsOver();
            Destroy(this.gameObject);
        }
    }
}
