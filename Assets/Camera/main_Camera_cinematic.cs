using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class main_Camera_cinematic : MonoBehaviour
{
    // Start is called before the first frame update
    CinemachineVirtualCamera camera_Bow,camera_level;
    
    void Start()
    {
      //GetComponent<CinemachineShot>().VirtualCamera=camera_level;

       // camera_Bow=GameObject.FindWithTag("Bowcamera");

        //camera_level=GameObject.FindWithTag("levelcamera");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
