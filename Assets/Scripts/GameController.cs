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
    public GameObject winUI;

    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        GetPlayers();

        winUI.SetActive(false);
    }

    public void GetPlayers()
    {
        LivingEntity[] livingEntities = GameObject.FindObjectsOfType<LivingEntity>();
        foreach(LivingEntity ent in livingEntities)
        {
            GameObject uiInstance = Instantiate(uiPrefab, uiParent);
            uiInstance.name = ent.Name + "_UI";
            players.Add(new Player(ent.gameObject, uiInstance));
        }
    }

    public void Win(LivingEntity who)
    {
<<<<<<< HEAD
        Time.timeScale = 0;

        winUI.SetActive(true);
        winUI.GetComponentInChildren<TextMeshProUGUI>().text = who.Name + " won!";
=======
        Debug.Log(who.name + " Lost the Game!");

        //foreach(Player p in players)
        //{
        //    if(p.LivingEntity.Name.Equals(who.GetComponent<LivingEntity>().Name))
        //    {
        //        p.decreaseStock(1);
        //    }
        //}
>>>>>>> f52628938b1e08a1df807ed4acdb4373c20757e7
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
    public GameObject ui;

    private LivingEntity character;
    private PlayerController controller;
    private TextMeshProUGUI percent;


    public Player(GameObject characterPrefab,  GameObject ui)
    {
        this.characterPrefab = characterPrefab;
        this.ui = ui;

        character = characterPrefab.GetComponent<LivingEntity>();
        percent = ui.transform.Find("Percent").GetComponent<TextMeshProUGUI>();
        ui.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = character.Name;
        controller = characterPrefab.GetComponent<PlayerController>();
    }

    public LivingEntity LivingEntity {
        get { return LivingEntity; }
    }

    public GameObject UI {
        get { return ui; }
    }

    public void UpdateStats()
    {
        percent.text = controller.getCurrentPercent.ToString();
    }
}
