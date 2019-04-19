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
        protected Transform parentObject;
        protected Collider2D attackCollider;

        public delegate void OnAttack();
        public event OnAttack OnAttackEvent;

        public delegate void OnAttackEnd();
        public event OnAttackEnd OnAttackEndEvent;

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
        public BaseAttack(string attackName, float damage, float knockbackStrength)
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
        }

        /// <summary>
        /// Summary of the Class
        /// </summary>
        /// <returns>Summary in string format</returns>
        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            ret.Append("Attack: Name: " + attackName).Append(", Damage: " + damage.ToString()).Append(", KnockbackStrenght: " + knockbackStrength);
            return ret.ToString();
        }

        /// <summary>
        /// Execute the attack
        /// </summary>
        public virtual void Attack()
        {
            if(OnAttackEvent != null)
                OnAttackEvent();
        }

        /// <summary>
        /// Execute after attack end
        /// </summary>
        public virtual void AttackEnd()
        {
            if(OnAttackEndEvent != null)
                OnAttackEndEvent();
        }

        /// <summary>
        /// Init the attack
        /// </summary>
        /// <param name="parentObject">Attack Origin</param>
        /// <param name="attackCollider">Attack Collider</param>
        public virtual void Init(Transform parentObject, Collider2D attackCollider)
        {
            this.parentObject = parentObject;
            this.attackCollider = attackCollider;
        }

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

        public Transform ParentTransform {
            get { return parentObject; }
        }
        #endregion
    }
}