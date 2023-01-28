using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int amountOfUnlockedLevels;
    public int temporary;
    public GameObject[] levelButtons;
    public bool[] isLevelDone;
    public GameObject levelButtonsCanvas;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        amountOfUnlockedLevels = 0;
        temporary = -1;

        for (int i = 0; i < isLevelDone.Length; i++)
        {
            isLevelDone[i] = false;
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            for (int i = 0; i <= isLevelDone.Length; i++)
            {
                levelButtons[i] = GameObject.Find("Button-" + (i+1));
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            for (int i = 0; i <= amountOfUnlockedLevels; i++)
            {
                levelButtons[i].gameObject.GetComponent<Button>().enabled = true;
                levelButtons[i].gameObject.GetComponent<CanvasGroup>().alpha = 1;
            }
        }

    }
    
}
