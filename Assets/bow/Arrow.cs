using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject Press_start_image;
    public GameObject arrowCam;
    bool Not_Active=false;
    public Animator cameraState;
    public Animator scarecrow;
    public GameObject hit_smoke;
    public AudioSource audios;
    public AudioClip hit;
    void Awake()
    {
        audios=GetComponent<AudioSource>();
        arrowCam = GameObject.FindWithTag("arrowCam");
        arrowCam.GetComponent<CinemachineVirtualCamera>().Follow = gameObject.transform;
        cameraState = GameObject.Find("CameraStateController").GetComponent<Animator>();
        Press_start_image = GameObject.Find("Image");
    }
    void Start()
    {
      
    rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Bow.game_continue)
        {
            if(!Not_Active)
            {
                float angle=Mathf.Atan2(rb.velocity.y,rb.velocity.x)*Mathf.Rad2Deg;
                transform.rotation=Quaternion.AngleAxis(angle,Vector3.forward);
            }
    
           
        }
        else
        {
            Press_start_image.GetComponent<image_script>().is_Inactive();
        }
        
     
        
    }
    public IEnumerator Gobow()
    {
        yield return new WaitForSeconds(0.8f);
                // bowa geri dönsün
                Bow.Arrow_is_flying=false; 
                cameraState.SetBool("arrowFlying", false);
            
                Press_start_image.GetComponent<image_script>().is_Inactive();
                Destroy(this.GetComponent<Arrow>());
                yield break;
            
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Gobow());

        Instantiate(hit_smoke, transform.position, quaternion.identity);
        audios.PlayOneShot(hit);
        if(collision.gameObject.CompareTag("ground"))
        {
        GameObject bow=GameObject.Find("bow");
        Game_Controller game_Controller=GameObject.Find("Game_Controller").GetComponent<Game_Controller>();
     
        if(bow!=null)
        {
        StartCoroutine(Later_Goback()); 
        }   
        
        }
         
        if(collision.gameObject.CompareTag("target"))
        {
        transform.parent = collision.gameObject.transform;
        GameObject bow=GameObject.Find("bow");
        Game_Controller game_Controller=GameObject.Find("Game_Controller").GetComponent<Game_Controller>();
        
        if(bow!=null)
        {
        StartCoroutine(Later_Goback()); 
        }
      }
      if(collision.gameObject.CompareTag("targethead"))
      { 
        

        GameObject bow=GameObject.Find("bow");
        
        scarecrow = collision.gameObject.GetComponent<Animator>();
        scarecrow.SetTrigger("IsHit");
        transform.parent = collision.gameObject.transform;
        if(bow!=null)
        { 
            StartCoroutine(Later_Goback());
            GameObject game_cont=GameObject.FindGameObjectWithTag("GameController");
            game_cont.GetComponent<Game_Controller>().image_Target_control(1);
        }
      }
    }
    
    IEnumerator Later_Goback()
    {
        Not_Active=true;
     
        GetComponent<Rigidbody2D>().velocity=Vector2.zero;
        Destroy(this.GetComponent<Rigidbody2D>());
        Destroy(this.GetComponent<CircleCollider2D>());
        
       
        // bundan sonrası kamerayı tekrar bowa yolluyor
        // panel açılsın 
       
        yield break;
    }
}
