using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] FloatReference movementSpeed = new FloatReference(10);
    [SerializeField] Rigidbody2D movingObject;

    public Rigidbody2D MovingObject { private get => movingObject; set => movingObject = value; }

    public void move(Vector2 direction)
    {
        MovingObject.velocity = direction *movementSpeed;
    }

}
