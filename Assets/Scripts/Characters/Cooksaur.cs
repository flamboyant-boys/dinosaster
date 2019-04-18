using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Cooksaur : LivingEntity, IDamagable
    {
        public BaseAttack baseAttack;
        public BaseAttack specialAttack;
        public Collider2D attackCollider;
        [SerializeField] SinputSystems.InputDeviceSlot slot;

        private bool blockSpecial = false;

        void IDamagable.die(GameObject damageDealer)
        {
            //throw new System.NotImplementedException();
        }

        void IDamagable.getDamage(GameObject damageDealer, float damage)
        {
            //throw new System.NotImplementedException();
        }

        private void Start()
        {
            baseAttack.Init(this.gameObject.transform, attackCollider);
            specialAttack.Init(this.gameObject.transform, attackCollider);

        }

        private void Update()
        {
            if (!blockSpecial && Sinput.GetButtonDown("BasicAttack", slot))
            {
                baseAttack.Attack();
            }

            if (Sinput.GetButton("SpecialAttack", slot))
            {
                blockSpecial = true;
                specialAttack.Attack();
            }

            if (Sinput.GetButtonUp("SpecialAttack", slot))
            {
                specialAttack.AttackEnd();
                blockSpecial = false;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(attackCollider.bounds.center, attackCollider.bounds.size);
        }
    }
}

