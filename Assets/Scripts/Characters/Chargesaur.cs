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
        public Collider2D chargeCollider;
        public float stunTime = 2f;
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

            chargeCollider.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            specialAttack.Direction = movement.Direction;

            if (!blockBasic && Sinput.GetButtonDown("BasicAttack", slot))
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

            if(specialAttack.IsCharging)
            {
                attackCollider.enabled = false;
                chargeCollider.enabled = true;
            } else
            {
                attackCollider.enabled = true;
                chargeCollider.enabled = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.transform.name != this.transform.name)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                StopCoroutine("StartChargeTimer");

                if(!collision.transform.CompareTag("Player"))
                {
                    StartCoroutine("StartStun");
                } else
                {
                    movement.CanMove = true;
                    movement.CanRotate = true;
                }

                
                specialAttack.IsCharging = false;
            }
        }

        private IEnumerator StartStun()
        {
            Debug.Log("Stunned");
            yield return new WaitForSeconds(stunTime);
            movement.CanMove = true;
            movement.CanRotate = true;
            Debug.Log("End");
        }

        private IEnumerator StartChargeTimer()
        {
            //Debug.Log((specialAttack.CurrentCharge * Time.deltaTime) / 10);
            yield return new WaitForSeconds((specialAttack.CurrentCharge * Time.deltaTime) / 10);
            //Debug.Log("Can Move");
            movement.CanMove = true;
            movement.CanRotate = true;
        }
    }

}
