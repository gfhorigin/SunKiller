using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchgrass : MonoBehaviour
{
    public Movement plrmov;

    void OnCollisionEnter2D(Collision2D collision)
    {
            plrmov.grounded = true;
            plrmov.jumpButtonColldown = 0.05f;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
            plrmov.grounded = false;
    }
}
