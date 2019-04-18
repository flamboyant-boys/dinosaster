using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Characters;

public class Test : MonoBehaviour
{
    public BaseAttack attack;
    public Collider2D attackCol;

    void Start()
    {
        //Debug.Log(test.ToString());
        attack.Init(this.transform, attackCol);

    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            attack.Attack();
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            attack.AttackEnd();
        }
    }
}
