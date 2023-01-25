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
    public GameObject panel_Arrow,panel_targets;
    [SerializeField] public Image Arrow_s,Target_s;

    [SerializeField] public int Gamepoint;
    void Awake()
    {
        Scenebow=GameObject.Find("bow").GetComponent<Bow>();
        arrow_count=Scenebow.arrow_count;
        The_Targets=GameObject.FindGameObjectsWithTag("targethead");

    }

    // Update is called once per frame
   bool image_control()
   {
    
    return true;
   }
}
