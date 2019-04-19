using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Characters;
using System;

public class GameController : MonoBehaviour
{
    public List<Player> players = new List<Player>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public struct Player
{
    public LivingEntity character;
    public int stock;
    public GameObject ui;

    public Player(LivingEntity character, int stock, GameObject ui)
    {
        this.character = character;
        this.stock = stock;
        this.ui = ui;
    }

    public int Stock {
        get { return stock; }
    }

    public LivingEntity LivingEntity {
        get { return LivingEntity; }
    }

    public GameObject UI {
        get { return ui; }
    }

    public void UpdateStats()
    {
       
    }

    public bool decreaseStock(int ammount)
    {
        stock--;
        if(stock <= 0)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
