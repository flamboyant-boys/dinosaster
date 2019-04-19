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
<<<<<<< HEAD
        MovingObject.velocity = direction * movementSpeed;

        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
=======
        MovingObject.velocity = direction *movementSpeed;
        look(direction);
>>>>>>> 8807628170df7d68b904b5ce23092dcf71ccf8a0
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

    public void look(Vector2 direction)
    {
        Debug.Log("Direction: " + direction);
        float angle = 0;
        if (direction.y >= 0)
        {
            angle = Vector2.Angle(Vector2.right, direction);
            Debug.Log("Angle" + angle);
            
        }
        else
        {
            angle = Vector2.Angle(Vector2.right, direction) * -1;
        }
        movingObject.MoveRotation(angle);

    }
}
