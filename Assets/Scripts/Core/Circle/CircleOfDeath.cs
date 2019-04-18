using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Characters;

public class CircleOfDeath : MonoBehaviour
{
    List<IDamagable> damagables = new List<IDamagable>();
    [SerializeField] FloatReference ticksPerSec = new FloatReference(1);
    [SerializeField] FloatReference dmg = new FloatReference(1);
    [SerializeField] Collider2D circle;
    [SerializeField] GameEvent circleMorphEven;
    [SerializeField] CircleStageManager stageManager;

    private void OnTriggerExit2D(Collider2D collision)
    {
        IDamagable c = collision.GetComponent<IDamagable>();
        if(c != null)
            damagables.Add(c);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable c = collision.GetComponent<IDamagable>();
        if (c != null)
            damagables.Remove(c);
    }


    private void Start()
    {
        InvokeRepeating("dealDamage", 0, 1 / ticksPerSec.Value);

    }

    private void dealDamage()
    {
        foreach (IDamagable damagable in damagables)
            damagable.getDamage(gameObject, dmg.Value);
    }




}
