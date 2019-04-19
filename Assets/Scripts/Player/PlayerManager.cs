using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PlayerController joinPlayer(SinputSystems.InputDeviceSlot slot)
    {
        GameObject newPlayer = Instantiate(playerPrefab);
        PlayerController pc = newPlayer.AddComponent<PlayerController>();
        //pc.initialize(slot, newPlayer.GetComponent<Rigidbody2D>());
        return pc;
    }
}
