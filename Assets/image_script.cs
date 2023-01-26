using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class image_script : MonoBehaviour
{
    // Start is called before the first frame update
    bool is_Actives;
    public bool is_Active()
    {   
        this.transform.DOLocalMoveY(-500,0.5f);
        is_Actives=true;    
    return true;
    
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Bow.Arrow_is_flying && is_Actives)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                is_Actives=false;

            } 
        }
    
    }
}
