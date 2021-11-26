using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    private UIManager _uiManager;
    private VikingControl _shieldControl;
    public bool inputActive;

    void Start()
    {
     _uiManager = FindObjectOfType<UIManager>(); 
    }

    // activates when the 'Start Game' button is pressed
    public void StartGame()
    {
        _uiManager.StartingGame();
        inputActive = true;
    }

    public void GameIsOver()
    {
        _uiManager.GameOver();
        inputActive = false;
    }
}
