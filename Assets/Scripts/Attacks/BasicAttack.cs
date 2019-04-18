using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "BasicAttack", menuName = "Attacks/BasicAttack", order = 1)]
    public class BasicAttack : BaseAttack
    {
        public ContactFilter2D filter;
        public bool knockback = true;

        public override void Attack()
        {
            List<Collider2D> results = new List<Collider2D>();
            int count = attackCollider.OverlapCollider(filter, results);

            foreach(Collider2D col in results)
            {
                // Check if its the same collider as the parentObj
                if(!col.name.Equals(parentObject.name))
                {
                    if(col.GetComponent<IDamagable>() != null)
                    {
                        col.GetComponent<IDamagable>().getDamage(parentObject.gameObject, damage);
                    }

                    if(knockback && col.GetComponent<Rigidbody2D>() != null)
                    {
                        Rigidbody2D rgbd = col.GetComponent<Rigidbody2D>();
                        Vector2 direction = new Vector2(parentObject.position.x - rgbd.position.x, parentObject.position.y - rgbd.position.y) * -1;
                        rgbd.AddForce(direction * knockbackStrength);
                    }
                } 
            }

            // Invoke the Events
            base.Attack();
        }
    }   
}


