using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    [RequireComponent(typeof(Collider2D))]
    public class Cauldron : MonoBehaviour
    {
        private Collider2D col;
        private Rigidbody2D rgbd;
        private CauldronThrow cauldronThrowAttack;
        public ContactFilter2D filter;

        private void Start()
        {
            col = GetComponent<Collider2D>();
            rgbd = GetComponent<Rigidbody2D>();
        }

        public void startThrowing(CauldronThrow cauldronThrowAttack)
        {
            this.cauldronThrowAttack = cauldronThrowAttack;
        }

        private void FixedUpdate()
        {
            if(rgbd.velocity.x <= 0.1f && rgbd.velocity.y <= 0.1f)
            {
                rgbd.velocity = Vector3.zero;

                StartKnockback();
            }
        }

        private void StartKnockback()
        {
            List<Collider2D> results = new List<Collider2D>();
            int count = col.OverlapCollider(filter, results);

            foreach(Collider2D col in results)
            {
                if(!col.name.Equals(this.gameObject.name))
                {
                    if (col.GetComponent<IDamagable>() != null)
                    {
                        col.GetComponent<IDamagable>().getDamage(this.gameObject, cauldronThrowAttack.Damage);
                    }

                    if (col.GetComponent<Rigidbody2D>() != null)
                    {
                        Rigidbody2D rgbd = col.GetComponent<Rigidbody2D>();
                        Vector2 direction = new Vector2(transform.position.x - rgbd.position.x, transform.position.y - rgbd.position.y) * -1;
                        rgbd.AddForce(direction * cauldronThrowAttack.KnockbackStrength);
                    }
                }
            }
        }

    }
}

