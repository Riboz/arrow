using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject arrowCam;
    bool Not_Active=false;

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
      if(!Not_Active)
     {
      float angle=Mathf.Atan2(rb.velocity.y,rb.velocity.x)*Mathf.Rad2Deg;
      transform.rotation=Quaternion.AngleAxis(angle,Vector3.forward);
     }
    
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
     if(collision.gameObject.CompareTag("target"))
     {
        GameObject bow=GameObject.Find("bow");
        if(bow!=null)
        {
        StartCoroutine(Later_Goback());
        }
    
     }
      if(collision.gameObject.CompareTag("targethead"))
      {
         GameObject bow=GameObject.Find("bow");
        if(bow!=null)
        {
        GameObject game_cont=GameObject.FindGameObjectWithTag("GameController");
        game_cont.GetComponent<Game_Controller>().Gamepoint+=1;
        StartCoroutine(Later_Goback());
        
        }
      }
    }
    IEnumerator Later_Goback()
    {
        Not_Active=true;
        GetComponent<Rigidbody2D>().velocity=Vector2.zero;
        Destroy(this.GetComponent<Rigidbody2D>());
        yield return new WaitForSeconds(2f);
         Bow.Arrow_is_flying=false;
         arrowCam.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("bow").transform;

        Destroy(this.GetComponent<Arrow>());
        yield break;
    }
}
