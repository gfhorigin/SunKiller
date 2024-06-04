using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Movement : MonoBehaviour
{
    public bool grounded = true;
    public float speed = 10f;
    public float jump = 600f;
    public float jumpButtonColldown = 0.2f;
  
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

  
    void Update()
    {
        bool inputY = Input.GetKey(KeyCode.Space);
        bool inputS = Input.GetKeyDown(KeyCode.S);
        float inputX = Input.GetAxis("Horizontal");
  
        rb.velocity = new Vector2(speed * inputX, rb.velocity.y);
        if (grounded && inputY && jumpButtonColldown<=0 )
        {
      
            
            rb.AddForce(Vector2.up * jump);
            jumpButtonColldown = 0.2f;

         
        }
        if(jumpButtonColldown > 0)jumpButtonColldown-= Time.deltaTime;
       
    
    }
}
