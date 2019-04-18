using UnityEngine;
using System;
using System.Text;

namespace Characters
{
    public abstract class BaseAttack : ScriptableObject
    {
       [SerializeField] protected string attackName;
       [SerializeField] protected float damage;
       [SerializeField] protected float knockbackStrength;
       [SerializeField] protected float attackRange;

        /// <summary>
        /// Create a base attack with base values
        /// </summary>
        public BaseAttack()
        {
            attackName = "TmpAttack";
            damage = 10f;
            knockbackStrength = 2f;
        }

        /// <summary>
        /// Create a base attack with given values
        /// </summary>
        /// <param name="attackName">attackName of the attack</param>
        /// <param name="damage">The damagle dealt by this attack</param>
        /// <param name="knockbackStrength">Knockback strength of the attack</param>
        /// <param name="attackRange">Attack range of the attack</param>
        public BaseAttack(string attackName, float damage, float knockbackStrength, float attackRange)
        {
            if(String.IsNullOrEmpty(attackName))
            {
                throw new ArgumentNullException();
            } else
            {
                attackName = attackName.Trim();
            }

            this.attackName = attackName;
            this.damage = damage;
            this.knockbackStrength = knockbackStrength;
            this.attackRange = attackRange;
        }

        /// <summary>
        /// Summary of the Class
        /// </summary>
        /// <returns>Summary in string format</returns>
        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            ret.Append("Attack: Name: " + attackName).Append(", Damage: " + damage.ToString()).Append(", KnockbackStrenght: " + knockbackStrength).Append(", AttackRange: " + attackRange);
            return ret.ToString();
        }

        /// <summary>
        /// Execute the attack
        /// </summary>
        public abstract void Attack();

        #region Getter&Setter
        public string AttackName {
            get { return attackName; }
        }

        public float Damage {
            get { return damage; }
        }

        public float KnockbackStrength {
            get { return knockbackStrength; }
        }

        public float AttackRange {
            get { return attackRange; }
        }
        #endregion
    }
}