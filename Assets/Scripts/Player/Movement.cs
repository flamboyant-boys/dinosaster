using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] FloatReference movementSpeed = new FloatReference(10);
    [SerializeField] Rigidbody2D movingObject;
    Vector2 movVector = Vector2.zero;
    bool canMove = true;
    bool canRotate = true;

    private void Start()
    {
        CanMove = true;
        CanRotate = true;
    }

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
        if(canMove)
        {
            MovingObject.velocity = direction *movementSpeed;
        }

        if(canRotate)
        {
            look(direction);

        }
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
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        movingObject.MoveRotation(rotation);
    }

    public Vector2 Direction {
        get { return movVector; }
    }

    public bool CanMove {
        get { return canMove; }
        set { canMove = value; }
    }

    public bool CanRotate {
        get { return canRotate; }
        set { canRotate = value; }
    }
}
