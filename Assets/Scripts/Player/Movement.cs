using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] FloatReference movementSpeed = new FloatReference(10);
    [SerializeField] Rigidbody2D movingObject;
    Vector2 movVector;

    public Movement(Rigidbody2D movingObject)
    {
        this.movingObject = movingObject;
    }

    public Movement(Rigidbody2D movingObject, FloatReference movSpeed) : this(movingObject)
    {
        movementSpeed = movSpeed;
    }

    public Rigidbody2D MovingObject { private get => movingObject; set => movingObject = value; }

    public void move(Vector2 direction)
    {
        MovingObject.velocity = direction *movementSpeed;
    }
    public void move(float horizontal, float vertical)
    {
        movVector.x = horizontal;
        movVector.y = vertical;
        move(movVector);
    }
    public void move(float right, float left, float up, float down)
    {
        move(right - left, up - down);
    }

}
