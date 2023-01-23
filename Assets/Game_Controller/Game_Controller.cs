using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Bow Scenebow;
    [SerializeField] public GameObject[] The_Targets;
    [SerializeField] public float arrow_count;
    [SerializeField] public int Gamepoint;
    void Awake()
    {
        Scenebow=GameObject.Find("bow").GetComponent<Bow>();
        arrow_count=Scenebow.arrow_count;
        The_Targets=GameObject.FindGameObjectsWithTag("targethead");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
