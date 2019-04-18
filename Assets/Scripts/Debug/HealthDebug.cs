using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Characters;

public class HealthDebug : MonoBehaviour, IDamagable
{

    float percent = 0;

    public void die(GameObject damageDealer)
    {
        throw new System.NotImplementedException();
    }

    public void getDamage(GameObject damageDealer, float damage)
    {
        percent += damage;
        Debug.Log("Current Percent: " + percent);
    }



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Current Percent: " + percent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
