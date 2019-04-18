﻿using System.Collections;
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
        public bool hasCauldron = true;

        public override void Attack()
        {
            if (!hasCauldron) return;

            strength += throwMultiplayer;
            base.Attack();
        }

        public override void AttackEnd()
        {
            if (!hasCauldron) return;

            hasCauldron = false;
            GameObject cauldronInstance = Instantiate(cauldron, parentObject.transform.position, Quaternion.identity) as GameObject;
            if(cauldronInstance.GetComponent<Rigidbody2D>() != null)
            {   
                Vector2 direction = parentObject.transform.up * strength;

                cauldronInstance.GetComponent<Rigidbody2D>().AddForce(direction);
                cauldronInstance.GetComponent<Cauldron>().startThrowing(this);
            }

            strength = 0;
            base.AttackEnd();
        }

        public void CollectCauldron()
        {
            hasCauldron = true;
        }

        public Transform baseObject {
            get { return parentObject; }
        }
    }
}


