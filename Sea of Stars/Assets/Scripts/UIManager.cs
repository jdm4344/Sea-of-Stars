﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Managers")]
    public CrewManager crewManager;

    [Header("Text Objects")]
    public GameObject roomTextObj;
    public GameObject foodTextObj;
    public GameObject energyTextObj;
    public GameObject healthTextObj;
    public GameObject enemyHealthTextObj;
    public GameObject stressTextObj;

    public TestPlayerScript player;
    public CombatShip ship;
    public CombatEntity enemy;

    [Header("Dialogue Text Objects")]
    public GameObject playerTextObj;
    public GameObject weaponTextObj;
    public GameObject magazineTextObj;
    public GameObject galleyTextObj;
    public GameObject storageTextObj;
    public GameObject engineTextObj;

    [Header("Button Objects")]
    public GameObject sosButton;
    public bool showSOS;

    // Start is called before the first frame update
    void Start()
    {
        foodTextObj.GetComponent<Text>().text = "Food: ";
        energyTextObj.GetComponent<Text>().text = "Fuel: ";

        if (!crewManager) crewManager = GetComponent<CrewManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 30 == 0)
        {
            roomTextObj.GetComponent<Text>().text = "Current Room: " + player.currRoom;
            healthTextObj.GetComponent<Text>().text = "Health: " + ship.Health;
            enemyHealthTextObj.GetComponent<Text>().text = "Health: " + enemy.Health;
            stressTextObj.GetComponent<Text>().text = "Stress: " + ship.stress;
        }

        if (showSOS) sosButton.SetActive(true);
    }

    // Updates the UI in response to an event
    public void AnnounceEvent(string message)
    {

    }

    // Called when SOS button is pressed
    public void SOS()
    {
        ship.stress = 0;

        ship.SOSState = false;

        // Hide the button again
        showSOS = false;
        sosButton.gameObject.SetActive(false);

        // TODO: Recruit a new crew member

    }
}
