using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Game_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Bow Scenebow;
    [SerializeField] public GameObject[] The_Targets;
    [SerializeField] public float arrow_count;
    
    [SerializeField] public Image[] Arrow_s,Target_s;

    [SerializeField] public int Gamepoint;
    void Awake()
    {
        Scenebow=GameObject.Find("bow").GetComponent<Bow>();
        arrow_count=Scenebow.arrow_count;
        The_Targets=GameObject.FindGameObjectsWithTag("targethead");

        for(int i=0;i<Scenebow.arrow_count;i++)
        {
         Arrow_s[i].gameObject.SetActive(true);
        }
        for(int i=0;i<The_Targets.Length;i++)
        {
         Target_s[i].gameObject.SetActive(true);
        }
        Gamepoint=The_Targets.Length;

    }

    // Update is called once per frame
   public bool image_control()
   {
    arrow_count=Scenebow.arrow_count;
    Arrow_s[(int)arrow_count].gameObject.SetActive(false);
    if(arrow_count==0)
    {
        // lose panel
    }
    return true;
   }
   
   public void image_Target_control(int a)
   {
    Gamepoint-=a;
    if(Gamepoint>=0)
    {
        Target_s[Gamepoint].gameObject.SetActive(false);
        if(Gamepoint==0)
        {
            // win panel
        }
    }
    
 
   }



}
