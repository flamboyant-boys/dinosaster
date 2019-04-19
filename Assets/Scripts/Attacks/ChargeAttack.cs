using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "ChargeAttack", menuName = "Attacks/ChargeAttack", order = 3)]
    public class ChargeAttack : BaseAttack
    {
        private bool isCharging = false;
        private float currentCharge = 0f;
        private Vector2 direction = Vector2.zero;
        public float chargeMultiplier = 10f;

        public override void Attack()
        {
            currentCharge += chargeMultiplier;

            base.Attack();
        }

        public override void AttackEnd()
        {
            Vector2 dir = direction.normalized * currentCharge;
            parentObject.GetComponent<Rigidbody2D>().AddForce(dir);

            currentCharge = 0;

            base.AttackEnd();
        }

        public override void Init(Transform parentObject, Collider2D attackCollider)
        {
            currentCharge = 0;
            direction = Vector2.zero;
            base.Init(parentObject, attackCollider);
        }

        public bool IsCharging {
            get { return isCharging; }
        }

        public Vector2 Direction {
            get { return direction; }
            set { direction = value; }
        }

        public float CurrentCharge {
            get { return currentCharge; }
        }

    }
}


