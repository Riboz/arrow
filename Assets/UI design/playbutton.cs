using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class playbutton : MonoBehaviour
{
    public void SwipePlayButton()
    {
       
        this.transform.DOLocalMoveY(1000, 0.6f);
           
    }
}
