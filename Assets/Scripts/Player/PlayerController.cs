﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Characters;

[RequireComponent(typeof(Movement))]
public class PlayerController : MonoBehaviour, IDamagable
{
    [SerializeField] Movement playerMovement;
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] SinputSystems.InputDeviceSlot slot;
    [SerializeField] FloatReference moveInputThreshhold = new FloatReference(0.15f);
    [Header("The Class:")]
    [SerializeField] LivingEntity character;
    IWarrior warrior;

    [Header("Damageable")]
    [SerializeField] float originalMass = 5;
    [SerializeField] float currentPercent;
    [SerializeField] FloatReference maxPercent = new FloatReference(50);

    public Material flashWhiteMat;

    public ParticleContainer particleContainer;

    private Material baseMat;
    private SpriteRenderer spriteRenderer;
 

    public void initialize(SinputSystems.InputDeviceSlot slot)
    {
        this.slot = slot;
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    float currMass()
    {
        return originalMass - ((originalMass-1)* (1 / maxPercent) * currentPercent);
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

        playerRigidbody.mass = currMass();
        playerMovement.MovingObject = playerRigidbody;

        spriteRenderer = GetComponent<SpriteRenderer>();
        baseMat = spriteRenderer.material;
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

    
    public void resetCurrentPercent()
    {
        SetCurrentPercent = 0;
    }

    public float SetCurrentPercent
    {
        set
        {
            currentPercent = value;
        } 
    }

    public float getCurrentPercent {
        get {
            return currentPercent;
        }
    }


    public void getDamage(GameObject damageDealer, float damage)
    {
        StartCoroutine(DamageFX());

        currentPercent += damage;
        Debug.Log("Got damage!");

        playerRigidbody.mass = currMass();

        if(currentPercent >= maxPercent.Value)
        {
            die(damageDealer);
        }
    }

    public void die(GameObject damageDealer)
    {
        

        if (GetComponent<Cooksaur>())
        {
            Instantiate(particleContainer.particleSystem1, transform.position, transform.rotation);
        }
        else if (GetComponent<Chargesaur>())
        {
            Instantiate(particleContainer.particleSystem2, transform.position, transform.rotation);
        }

        GameManager.Instance.OnPlayerDeath(this);

    }

    private IEnumerator DamageFX()
    {
        float flashTime = 0.06f;

        spriteRenderer.material = flashWhiteMat;
        yield return new WaitForSeconds(flashTime);
        spriteRenderer.material = baseMat;
        yield return new WaitForSeconds(flashTime);
        spriteRenderer.material = flashWhiteMat;
        yield return new WaitForSeconds(flashTime);
        spriteRenderer.material = baseMat;
        yield return new WaitForSeconds(flashTime);
        spriteRenderer.material = flashWhiteMat;
        yield return new WaitForSeconds(flashTime);
        spriteRenderer.material = baseMat;
        yield return new WaitForSeconds(flashTime);
        spriteRenderer.material = flashWhiteMat;
        yield return new WaitForSeconds(flashTime);
        spriteRenderer.material = baseMat;
    }
}


