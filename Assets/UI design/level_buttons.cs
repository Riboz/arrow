using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class level_buttons : MonoBehaviour
{
    

    public void SwipeUpLevelButtons()
    {
        this.transform.DOLocalMoveY(0, 0.8f);
    }

    public void SwipeDownLevelButtons()
    {
        this.transform.DOLocalMoveY(-1000, 0.5f);
    }
}
