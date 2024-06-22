using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public int Hp ;
    public void TakeDamage(int Damage)
    {
        Hp -= Damage;
       
    }
}
