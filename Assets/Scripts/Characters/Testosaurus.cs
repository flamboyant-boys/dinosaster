using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    public class Testosaurus : MonoBehaviour, IDamagable
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        void IDamagable.die(GameObject damageDealer)
        {
            throw new System.NotImplementedException();
        }

        void IDamagable.getDamage(GameObject damageDealer, float damage)
        {
            throw new System.NotImplementedException();
        }
    }
}
