using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Game_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public static bool[] Winner;
    [SerializeField] private Bow Scenebow;
    [SerializeField] public GameObject[] The_Targets;
    [SerializeField] public float arrow_count,level;
    
    [SerializeField] public Image[] Arrow_s,Target_s;

    [SerializeField] public int Gamepoint;

    public LevelManager LevelManager;
    void Awake()
    {
        Scenebow=GameObject.Find("bow").GetComponent<Bow>();
        arrow_count=Scenebow.arrow_count;
        The_Targets=GameObject.FindGameObjectsWithTag("targethead");
        Bow.game_continue = true;
        Bow.Arrow_is_flying = true;

        for(int i=0;i<Scenebow.arrow_count;i++)
        {
         Arrow_s[i].gameObject.SetActive(true);
        }
        for(int i=0;i<The_Targets.Length;i++)
        {
         Target_s[i].gameObject.SetActive(true);
        }
        Gamepoint=The_Targets.Length;
        LevelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

    }

    // Update is called once per frame
   public bool image_control()
   {
    arrow_count=Scenebow.arrow_count;
    Arrow_s[(int)arrow_count].gameObject.SetActive(false);
    if(arrow_count==0 && Gamepoint>0)
    {
        // lose panel
        // Bow.game_continue = true; bir sonraki sahneye gidilecek butona tıklandığında
        GameObject.FindWithTag("pauseButton").SetActive(false);
        GameObject.FindWithTag("losePanel").gameObject.transform.DOLocalMoveY(0, 0.5f);
        Debug.Log("you lost bruh");
        Bow.game_continue = false;
    }
    return true;
   }
   
   public void image_Target_control(int a)
   {
    arrow_count=Scenebow.arrow_count;
    Arrow_s[(int)arrow_count].gameObject.SetActive(false);
    Gamepoint-=a;
    
        if(Target_s[Gamepoint]!=null)Target_s[Gamepoint].gameObject.SetActive(false);
        
        if (Gamepoint == 0 &&arrow_count>=0)
        {
            Bow.game_continue = false;
            
            if (LevelManager.isLevelDone[SceneManager.GetActiveScene().buildIndex] == false)
            {
                LevelManager.amountOfUnlockedLevels += 1;
                LevelManager.isLevelDone[SceneManager.GetActiveScene().buildIndex] = true;
            }
            
            GameObject.FindWithTag("pauseButton").SetActive(false);
            GameObject.Find("winPanel").transform.DOLocalMoveY(0, 0.5f);
        }

        
        
    
   
 
   }



}
