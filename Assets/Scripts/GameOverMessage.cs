using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMessage : MonoBehaviour
{
    public static bool reachedMidgard;
    public Text gameOverMessageText;

    // Start is called before the first frame update
    void Start()
    {
        if (reachedMidgard)
        {
            gameOverMessageText.text = "successful";
        }
        else
        {
            gameOverMessageText.text = "failed";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
