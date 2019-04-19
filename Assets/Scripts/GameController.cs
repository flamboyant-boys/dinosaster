using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Characters;
using System;
using TMPro;

public class GameController : MonoBehaviour
{
    private List<Player> players = new List<Player>();
    public GameObject uiPrefab;
    public Transform uiParent;
    public int maxStock = 3;

    // Start is called before the first frame update
    void Start()
    {
        GetPlayers();
    }

    public void GetPlayers()
    {
        LivingEntity[] livingEntities = GameObject.FindObjectsOfType<LivingEntity>();
        foreach(LivingEntity ent in livingEntities)
        {
            GameObject uiInstance = Instantiate(uiPrefab, uiParent);
            uiInstance.name = ent.Name + "_UI";
            players.Add(new Player(ent.gameObject, maxStock, uiInstance));
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Player p in players)
        {
            p.UpdateStats();
        }
    }
}

[Serializable]
public struct Player
{
    public GameObject characterPrefab;
    public int stock;
    public GameObject ui;

    private LivingEntity character;
    private TextMeshProUGUI text;
    private Image image;

    public Player(GameObject characterPrefab, int stock, GameObject ui)
    {
        this.characterPrefab = characterPrefab;
        this.stock = stock;
        this.ui = ui;

        character = characterPrefab.GetComponent<LivingEntity>();
        text = ui.GetComponentInChildren<TextMeshProUGUI>();
        image = ui.GetComponentInChildren<Image>();
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
        text.text = character.Percentage.ToString() + "%";
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
