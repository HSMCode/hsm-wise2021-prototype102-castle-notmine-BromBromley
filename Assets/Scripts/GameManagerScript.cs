using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("01_MainMenu");
    }
}