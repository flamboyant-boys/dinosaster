using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] Movement playerMovement;
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] SinputSystems.InputDeviceSlot slot;
    [SerializeField] FloatReference moveInputThreshhold = new FloatReference(0.15f);

    public void initialize(SinputSystems.InputDeviceSlot slot, Rigidbody2D playerObj)
    {
        this.slot = slot;
        playerRigidbody = playerObj;
    }

    private void OnEnable()
    {
        if (playerMovement == null)
        {
            if (GetComponent<Movement>() == null)
                playerMovement = gameObject.AddComponent<Movement>();
            else
                playerMovement = GetComponent<Movement>();
        }

        playerMovement.MovingObject = playerRigidbody;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
            
    }

    void move()
    {
        float horizontal, vertical;
        horizontal = Sinput.GetAxis("Horizontal", slot);
        vertical = Sinput.GetAxis("Vertical", slot);
        if(Mathf.Abs(horizontal) >= moveInputThreshhold || Mathf.Abs(vertical) >= moveInputThreshhold)
            playerMovement.move(Sinput.GetAxis("Horizontal", slot), Sinput.GetAxis("Vertical", slot));
    }
}


