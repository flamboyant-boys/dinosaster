using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "ChargeAttack", menuName = "Attacks/ChargeAttack", order = 3)]
    public class ChargeAttack : BaseAttack
    {
        public override void Attack()
        {
            base.Attack();
        }

        public override void AttackEnd()
        {

            base.AttackEnd();
        }
    }
}


