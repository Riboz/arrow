using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool game_continue=true;
   
    [Header("needed")]
    [SerializeField]private int NumberOfDots;
    Game_Controller game_Controller;
    private GameObject[] Dots;
    public static bool Arrow_is_flying=true;
    public Animator cameraState;
    private Vector2 direction;
    [SerializeField] private GameObject Arrow,Dot,Arrow_throw_obj;
    private Animator animator;
    public AudioSource audios;
    public AudioClip bow_attack;
    [Header("Arrow parameter")]
    [SerializeField] public float arrow_count,arrow_power,arrow_power_bound,SpaceBetweenDots;
   Touch touch;
  
    void Awake()
    {
        touch=new Touch();

        audios=GetComponent<AudioSource>();

    game_Controller=GameObject.FindGameObjectWithTag("GameController").GetComponent<Game_Controller>();
    image_script b=GameObject.Find("Image").GetComponent<image_script>();
    b.is_Active();
     Arrow_throw_obj=GameObject.Find("arrow_throw_pos");
     animator=GetComponent<Animator>();
     Dots=new GameObject[NumberOfDots];
     for(int i=0;i<Dots.Length;i++)
     {
        Dots[i]=Instantiate(Dot,Arrow_throw_obj.transform.position,Quaternion.identity);
        Dots[i].SetActive(false);
     }
       
    }

    
    
    // Update is called once per frame
    IEnumerator first_Of_first()
    {
        yield return new WaitForSeconds(3f);
     Arrow_is_flying=false;
     yield break;
    }
     void BowDirection()
     {
     Vector2 Mouse_Posisiton=Camera.main.ScreenToWorldPoint(Input.mousePosition);
     direction=(Vector2)transform.position-(Vector2)Mouse_Posisiton;
     transform.right=direction;
     }
    void FixedUpdate()
    {
        
        if (game_continue) BowDirection();
    }
    public void buttonvo()
    {
 
                image_script a = GameObject.Find("Image").GetComponent<image_script>();
                a.is_Inactive();
                cameraState.SetBool("levelShow", true);
            
                StartCoroutine(first_Of_first());
    }
    void Update()
    {
        if (game_continue)
        {
            if(!Arrow_is_flying && arrow_count>0)shoot();
           
        }
      
    }
    void shoot()
    {
        
        if(touch.phase == TouchPhase.Began)
        {
            animator.Play("flex");
         if(arrow_power<=arrow_power_bound)
         {

          
           Vector2 Mouse_Posisiton=Camera.main.ScreenToWorldPoint((Vector2)touch.position);

           float Arrowflex=Vector2.Distance(Mouse_Posisiton,(Vector2)this.transform.position);

           arrow_power=Arrowflex*6;
         
            
         }
         else
         {
            arrow_power=arrow_power_bound;
         }

         for(int i=0;i<Dots.Length;i++)
         {
            Dots[i].SetActive(true);
            Dots[i].transform.position=Dotposition(i*SpaceBetweenDots);   
         }

        }
        
       if(touch.phase == TouchPhase.Ended)
        { 
        audios.PlayOneShot(bow_attack);
        animator.Play("reflex");

        GameObject new_Arrow=Instantiate(Arrow,Arrow_throw_obj.transform.position,Arrow_throw_obj.transform.rotation);

        new_Arrow.GetComponent<Rigidbody2D>().velocity=transform.right*arrow_power;

        arrow_power=0;

        
       
        arrow_count-=1;
       
       
        Arrow_is_flying=true;
        cameraState.SetBool("arrowFlying", true);

        
        
        }
        
    }
    Vector2 Dotposition(float t)
    {
        Vector2 position = (Vector2)Arrow_throw_obj.transform.position+(direction.normalized*arrow_power*t)+0.5f*Physics2D.gravity*(t*t);
        return position;
    }

}
