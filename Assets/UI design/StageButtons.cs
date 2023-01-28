using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StageButtons : MonoBehaviour
{
    public void SwipeUpStageButtons()
    {
        this.transform.DOLocalMoveY(0, 0.5f);
    }

    public void SwipeDownStageButtons()
    {
        this.transform.DOLocalMoveY(-1000, 0.5f);
    }
    
    public void SwipeUpStageButtons2()
    {
        this.transform.DOLocalMoveY(1000, 0.5f);
    }
}
