using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Movement playerMovement;
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] SinputSystems.InputDeviceSlot slot;
    [SerializeField] SinputSystems.InputDeviceType deviceType;

    public void initialize(SinputSystems.InputDeviceSlot slot, Rigidbody2D playerObj)
    {
        this.slot = slot;
        playerRigidbody = playerObj;
    }

    private void OnEnable()
    {
        playerMovement.MovingObject = playerRigidbody;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();

    }

    void move()
    {
        if(deviceType == SinputSystems.InputDeviceType.GamepadAxis)
            playerMovement.move(Sinput.GetAxis("Horizontal"), Sinput.GetAxis("Vertical"));
    }
}


