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

    public Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer ren;

    private bool LookAt = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ren = GetComponent<SpriteRenderer>();
    }

  
    void Update()
    {
        bool InputY = Input.GetKey(KeyCode.Space);
        bool InputS = Input.GetKeyDown(KeyCode.S);
        float InputX = Input.GetAxis("Horizontal");

        if (InputX < 0 && LookAt || InputX > 0 && !LookAt ) Flip();

        rb.velocity = new Vector2(speed * InputX, rb.velocity.y);
        if (grounded && InputY && jumpButtonColldown<=0 )
        {
      
            
            rb.AddForce(Vector2.up * jump);
            jumpButtonColldown = 0.2f;

         
        }
        if(jumpButtonColldown > 0)jumpButtonColldown-= Time.deltaTime;
       
    
    }
    void Flip()
    {
        LookAt = !LookAt;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
