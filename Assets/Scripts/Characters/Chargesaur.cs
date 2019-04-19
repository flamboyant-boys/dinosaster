using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    public class Chargesaur : LivingEntity
    {
        public BaseAttack baseAttack;
        public ChargeAttack specialAttack;
        public Collider2D attackCollider;
        [SerializeField] SinputSystems.InputDeviceSlot slot;

        private bool blockSpecial = false;
        private bool blockBasic = false;

        private Movement movement;

        // Start is called before the first frame update
        void Start()
        {
            baseAttack.Init(this.transform, attackCollider);
            specialAttack.Init(this.transform, attackCollider);

            movement = GetComponent<Movement>();
            movement.CanMove = true;
            movement.CanRotate = true;
        }

        // Update is called once per frame
        void Update()
        {
            specialAttack.Direction = movement.Direction;

            if (!blockSpecial && Sinput.GetButtonDown("BasicAttack", slot))
            {
                baseAttack.Attack();
            }

            if (Sinput.GetButton("SpecialAttack", slot))
            {
                blockBasic = true;
                movement.CanMove = false;
                specialAttack.Attack();
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }

            if (Sinput.GetButtonUp("SpecialAttack", slot))
            {
                StartCoroutine("StartChargeTimer");
                specialAttack.AttackEnd();

                movement.CanRotate = false;
                blockBasic = false;
            }
        }

        private IEnumerator StartChargeTimer()
        {
            //Debug.Log((specialAttack.CurrentCharge * Time.deltaTime) / 10);
            yield return new WaitForSeconds((specialAttack.CurrentCharge * Time.deltaTime) / 10);
            //Debug.Log("Can Move");
            movement.CanMove = true;
            movement.CanRotate = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            StopCoroutine("StartChargeTimer");
            movement.CanMove = true;
            movement.CanRotate = true;
        }
    }

}
