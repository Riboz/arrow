using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class image_script : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void is_Active()
    {   
        this.transform.DOLocalMoveY(-500,0.5f);
    }

    public void is_Inactive()
    {   
        this.transform.DOLocalMoveY(-600,0.5f);
    }
   
}
