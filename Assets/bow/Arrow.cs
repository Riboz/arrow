using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject arrowCam;

    void Awake()
    {
        arrowCam = GameObject.FindWithTag("bowCamera");
        arrowCam.GetComponent<CinemachineVirtualCamera>().Follow = gameObject.transform;
    }
    void Start()
    {
    rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    float angle=Mathf.Atan2(rb.velocity.y,rb.velocity.x)*Mathf.Rad2Deg;
    transform.rotation=Quaternion.AngleAxis(angle,Vector3.forward);
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
     if(collision.gameObject.CompareTag("target"))
     {
        
     }
    }
}
