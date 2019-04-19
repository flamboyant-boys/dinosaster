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
        private bool blockBasic = false;

        private Animator animator;
        private Rigidbody2D rb;

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
            rb = this.GetComponent<Rigidbody2D>();
            animator = this.GetComponent<Animator>();
            GetComponent<Movement>().CanMove = true;
            GetComponent<Movement>().CanRotate = true;
            Init("Cooksaur");
        }

        private void Update()
        {
            if (!blockBasic && Sinput.GetButtonDown("BasicAttack", slot))
            {
                baseAttack.Attack();
                animator.SetTrigger("BaseAttack");
            }

            if (Sinput.GetButton("SpecialAttack", slot))
            {
                blockBasic = true;
                specialAttack.Attack();
            }

            if (Sinput.GetButtonUp("SpecialAttack", slot))
            {
                specialAttack.AttackEnd();
                blockBasic = false;
                animator.SetTrigger("SpecialAttack");
            }

            if (Mathf.Round(rb.velocity.magnitude) >= -1 && Mathf.Round(rb.velocity.magnitude) <= 1)
            {
                animator.SetBool("IsMoving", false);
            }
            else
            {
                animator.SetBool("IsMoving", true);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            //Gizmos.DrawCube(attackCollider.bounds.center, attackCollider.bounds.size);
        }
    }
}

