using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("needed")]
    private bool Arrow_is_flying=false;
    private Vector2 direction;
    [SerializeField] private GameObject Arrow,Dot,Arrow_throw_obj;
    private Animator animator;
    [Header("Arrow parameter")]
    [SerializeField] private float arrow_count,arrow_power,arrow_power_bound,arrow_timer;
    void Awake()
    {
    Arrow_throw_obj=GameObject.Find("arrow_throw_pos");
    animator=GetComponent<Animator>();
        
    }

    // Update is called once per frame
     void BowDirection()
     {
     Vector2 Mouse_Posisiton=Camera.main.ScreenToWorldPoint(Input.mousePosition);
     direction=(Vector2)Mouse_Posisiton-(Vector2)transform.position;
     transform.right=direction;
     }
    void FixedUpdate()
    {
        BowDirection();
    }
    void Update()
    {
        if(!Arrow_is_flying)shoot();
    }
    void shoot()
    {
        if(Input.GetMouseButtonDown(0) )
        {
            animator.Play("flex");
         if(arrow_power<=arrow_power_bound)
         {
            arrow_timer+=Time.deltaTime;
            
            if(arrow_timer>0.15f)
            {
                arrow_power+=0.5f;
                arrow_timer=0;
            }
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

        //Arrow_is_flying=true;

        }

    }
}
