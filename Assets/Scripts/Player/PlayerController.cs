using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Movement playerMovement;
    [SerializeField] Rigidbody2D playerRigidbody;

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

    }
}
