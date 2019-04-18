using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    public abstract class BaseAttack
    {
        private float damage;
        private float knockbackStrength;
        private float attackRange;

        /// <summary>
        /// Create a base attack with base values
        /// </summary>
        public BaseAttack()
        {
            damage = 10f;
            knockbackStrength = 2f;
        }

        /// <summary>
        /// Create a base attack with given values
        /// </summary>
        /// <param name="damage">The damagle dealt by this attack</param>
        /// <param name="knockbackStrength">Knockback strength of the attack</param>
        /// <param name="attackRange">Attack range of the attack</param>
        public BaseAttack(float damage, float knockbackStrength, float attackRange)
        {
            this.damage = damage;
            this.knockbackStrength = knockbackStrength;
            this.attackRange = attackRange;
        }

        public abstract void Attack();
    }
}