﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] Movement playerMovement;
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] SinputSystems.InputDeviceSlot slot;

    public void initialize(SinputSystems.InputDeviceSlot slot, Rigidbody2D playerObj)
    {
        this.slot = slot;
        playerRigidbody = playerObj;
    }

    private void OnEnable()
    {
        playerMovement.MovingObject = playerRigidbody;
    }

    // Update is called once per frame
    void Update()
    {
        move();
            
    }

    void move()
    {
        playerMovement.move(Sinput.GetAxis("Horizontal"), Sinput.GetAxis("Vertical"));
    }
}


