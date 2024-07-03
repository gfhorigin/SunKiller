using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerAttack : MonoBehaviour
{
    private float  AttackCooldown;
    public  float  AttackCooldownStart;

    public Transform AttackPos;
    public float AttackRange;
    public LayerMask Enemy;
    

    public int Damage;
    public Animator animator;

    public int ComboCounter;
    public float ComboTimer ;
    public float ComboTimerStart = 2f;
    public Text ComboText;

    void Update()
    {
        if(ComboTimer > 0)
        {
            ComboTimer-= Time.deltaTime;
        }
        else
        {
            ComboCounter = 0;
            ComboText.text = " ";
        }


        if(AttackCooldown <= 0)
        {
            if(Input.GetMouseButton(0))
            {

                //anim.SetTrigger("")
                
                Attack();
            }
        }
        else
        {
            AttackCooldown -= Time.deltaTime;
        }
    }
    void Attack()
    {
        ComboCounter +=1;
        ComboTimer = ComboTimerStart;
        ComboText.text = ComboCounter.ToString();

        Collider2D[] enemies = Physics2D.OverlapCircleAll(AttackPos.position,AttackRange, Enemy);
        for (int i = 0; i < enemies.Length; i++)
        {
        enemies[i].GetComponent<EnemyHp>().TakeDamage(Damage);
        }
        AttackCooldown = AttackCooldownStart;
    }
    void OnDrawGizmos() //
    {
        Gizmos.color = Color.red; //

        Gizmos.DrawWireSphere(AttackPos.position, AttackRange); //
        
    }
}
