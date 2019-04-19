using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "CauldronThrow", menuName = "Attacks/CauldronThrow", order = 2)]
    public class CauldronThrow : BaseAttack
    {
        [SerializeField] private GameObject cauldron;
        [SerializeField] private float throwMultiplayer;
        private float strength = 0f;
        public bool canThrow = true;

        public override void Attack()
        {
            if (!canThrow) return;

            strength += throwMultiplayer;
            base.Attack();
        }

        public override void Init(Transform parentObject, Collider2D attackCollider)
        {
            base.Init(parentObject, attackCollider);
            canThrow = true;
        }

        public override void AttackEnd()
        {
            if (!canThrow) return;

            canThrow = false;

            GameObject cauldronInstance = Instantiate(cauldron, parentObject.transform.position, Quaternion.identity) as GameObject;
            cauldronInstance.name = parentObject.GetComponent<LivingEntity>().ID;

            if(cauldronInstance.GetComponent<Rigidbody2D>() != null)
            {   
                Vector2 direction = parentObject.transform.right * strength;

                cauldronInstance.GetComponent<Rigidbody2D>().AddForce(direction);
                cauldronInstance.GetComponent<Cauldron>().startThrowing(this);
            }

            strength = 0;
            base.AttackEnd();
        }

        public bool CanThrow {
            get { return canThrow; }
            set { canThrow = value; }
        }

        public Transform baseObject {
            get { return parentObject; }
        }

    }
}


