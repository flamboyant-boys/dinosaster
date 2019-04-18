using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    [RequireComponent(typeof(Collider2D))]
    public class Cauldron : MonoBehaviour
    {
        private Collider2D col;
        private Rigidbody2D rgbd;
        private float knockbackRadius;

        private void Start()
        {
            col = GetComponent<Collider2D>();
            rgbd = GetComponent<Rigidbody2D>();
        }

        public void starThrowing(float radius)
        {
            col.enabled = false;
            knockbackRadius = radius;
        }

        private void FixedUpdate()
        {
            if(rgbd.velocity.x <= 0.1f && rgbd.velocity.y <= 0.1f)
            {
                rgbd.velocity = Vector3.zero;

                StartKnockback();
            }
        }

        private void StartKnockback()
        {

        }
    }
}

