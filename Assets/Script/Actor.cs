using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{

    public string diplayName;
    public float speedWalk;   //  nossa velocide para escolher
    public Vector2 jumpForce;
    //public Vector2 jumpForce;


    public bool onAir = false;

    protected SpriteRenderer spRender;
    protected Animator animator;
    protected Rigidbody2D rigidBody2D;

    //protected Rigidbody rigidBody;
     

    void Start()
    {
        spRender = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        //rigidBody = GetComponent<Rigidbody>();
 
    }


    void Update()
    {

        Vector3 position = transform.position;

        bool moving = false;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moving = true;

            position.x += speedWalk;

            spRender.flipX = false;  // 

            Debug.Log("Direita ");
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            moving = true;

            position.x -= speedWalk;

            spRender.flipX = true;//

           

            Debug.Log("equerda");


        }

         if(Input.GetKey(KeyCode.A) && onAir == false)
        {
            rigidBody2D.AddForce(jumpForce);
            onAir = true;
        }

       
        


       transform.position =  position;


        if (onAir)
        {

            changeAnim("jump");
        }
        else
        {
            if (moving)
            {
                changeAnim("walk");
            }
            else
            {
                changeAnim("stand");
            }
        }
        
        
    }


    public void changeAnim(string anim)
    {

        animator.CrossFade(anim, 0);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onAir = false;
    }




    // estva mexendo no prefab sem existir 


}
