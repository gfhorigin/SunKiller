using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float  AttackCooldown;
    public  float  AttackCooldownStart;

    public Transform AttackPos;
    public float AttackRange;
    public LayerMask Enemy;
    

    public int Damage;
    public Animator animator;

    void Update()
    {
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
