using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        FindObjectOfType<GameManagerScript>().GoToMainMenu();
    }
}
