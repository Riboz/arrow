using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class level_buttons : MonoBehaviour
{
    public void SwipeUpLevelButtons()
    {
        this.transform.DOLocalMoveY(0, 0.8f);
    }
}
