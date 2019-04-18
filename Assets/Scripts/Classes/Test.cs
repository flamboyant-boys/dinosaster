using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Characters;

public class Test : MonoBehaviour
{
    public BasicAttack attack;
    public Collider2D attackCol;

    void Start()
    {
        //Debug.Log(test.ToString());
        attack.Init(this.transform, attackCol);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            attack.Attack();
        }
    }
}
