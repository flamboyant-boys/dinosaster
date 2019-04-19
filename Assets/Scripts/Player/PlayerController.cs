using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Characters;

[RequireComponent(typeof(Movement))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] Movement playerMovement;
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] SinputSystems.InputDeviceSlot slot;
    [SerializeField] FloatReference moveInputThreshhold = new FloatReference(0.15f);
    [Header("The Class:")]
    [SerializeField] LivingEntity character;
    IWarrior warrior;

    public void initialize(SinputSystems.InputDeviceSlot slot, Rigidbody2D playerObj)
    {
        this.slot = slot;
        playerRigidbody = playerObj;
    }

    private void OnEnable()
    {
        if (character.GetComponent<IWarrior>() == null)
        {
            Debug.LogError("character needs to be of: " + typeof(IWarrior));
        }
        else
        {
            warrior = character.GetComponent<IWarrior>();
        }

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

    private void Update()
    {
        attacks();
    }

    void attacks()
    {
        if (Sinput.GetButtonDown("BasicAttack", slot))
        {
            warrior.startBasicAttack();
            Debug.Log("Basic");
        }



        if (Sinput.GetButton("SpecialAttack", slot))
            warrior.startSpecialAttack();


        if (Sinput.GetButtonUp("SpecialAttack", slot))
            warrior.endSpecialAttack();

    }

    void move()
    {

        float horizontal, vertical;
        horizontal = Sinput.GetAxis("Horizontal", slot);
        vertical = Sinput.GetAxis("Vertical", slot);
        if(Mathf.Abs(horizontal) >= moveInputThreshhold || Mathf.Abs(vertical) >= moveInputThreshhold)
        {
            playerMovement.move(Sinput.GetAxis("Horizontal", slot), Sinput.GetAxis("Vertical", slot));
        }

    }
}


