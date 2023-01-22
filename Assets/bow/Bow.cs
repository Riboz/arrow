using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("needed")]
    [SerializeField]private int NumberOfDots;

private GameObject[] Dots;
    private bool Arrow_is_flying=false;
    private Vector2 direction;
    [SerializeField] private GameObject Arrow,Dot,Arrow_throw_obj;
    private Animator animator;
    [Header("Arrow parameter")]
    [SerializeField] private float arrow_count,arrow_power,arrow_power_bound,arrow_timer,SpaceBetweenDots;
    void Awake()
    {
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
     void BowDirection()
     {
     Vector2 Mouse_Posisiton=Camera.main.ScreenToWorldPoint(Input.mousePosition);
     direction=(Vector2)transform.position-(Vector2)Mouse_Posisiton;
     transform.right=direction;
     }
    void FixedUpdate()
    {
        BowDirection();
    }
    void Update()
    {
        if(!Arrow_is_flying && arrow_count>0)shoot();
    }
    void shoot()
    {
        if(Input.GetMouseButton(0) )
        {
            animator.Play("flex");
         if(arrow_power<=arrow_power_bound)
         {
            arrow_timer+=Time.deltaTime;
            
            if(arrow_timer>0.1f)
            {
             arrow_power+=0.5f;
             arrow_timer=0;
             
            }
         }

         for(int i=0;i<arrow_power*2;i++)
         {
            Dots[i].SetActive(true);
            Dots[i].transform.position=Dotposition(i*SpaceBetweenDots);   
         }

        }
        
       if(Input.GetMouseButtonUp(0) )
        { 
        animator.Play("reflex");

        GameObject new_Arrow=Instantiate(Arrow,Arrow_throw_obj.transform.position,Arrow_throw_obj.transform.rotation);

        new_Arrow.GetComponent<Rigidbody2D>().velocity=transform.right*arrow_power;

        arrow_power=0;

        arrow_timer=0;

        arrow_count-=1;
        for(int i=0;i<Dots.Length;i++)
          {
        
        Dots[i].SetActive(false);
          }
        //Arrow_is_flying=true;

        }

    }
    Vector2 Dotposition(float t)
    {
        Vector2 position=(Vector2)Arrow_throw_obj.transform.position+(direction.normalized*arrow_power*t)+0.5f*Physics2D.gravity*(t*t);
        return position;
    }

}
