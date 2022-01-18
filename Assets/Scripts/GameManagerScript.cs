using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "01_MainMenu" && Input.anyKey)
        {
            audio.Play();
            Invoke("StartGame", audio.clip.length);
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("01_MainMenu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("02_Game");
    }
}