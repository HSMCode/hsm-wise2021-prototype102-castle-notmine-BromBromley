using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject HeadsUpDisplay;
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private GameObject Score;

    public void StartingGame()
    {
        MainMenu.SetActive(false);
        HeadsUpDisplay.SetActive(true);
        GameOverScreen.SetActive(false);
        Score.SetActive(true);
    }

    public void GameOver()
    {
        HeadsUpDisplay.SetActive(false);
        GameOverScreen.SetActive(true);
    }
}
