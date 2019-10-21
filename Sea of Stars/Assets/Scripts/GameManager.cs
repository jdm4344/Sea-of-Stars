﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Authors: Jordan Machalek
 * Holds key game data and methods
 */
public class GameManager : MonoBehaviour
{
    [Header("Resource Data")]
    // Food for thought: Condense these as a Vector3 called 'shipStats'?
    public int fuelCount = 10; // This is separate to prevent the header from appearing above all 3 attributes
    public int foodCount = 10, luminosityCount = 10;

    [Header("Crew Data")]
    public int crewCount = 0;

    [Header("UI References")]
    public GameObject fuelTextObj;
    public GameObject foodTextObj;
    public GameObject crewTextObj;
    public GameObject luminosityTextObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update UI every 30 frames
        if(Time.frameCount % 30 == 0)
        {
            // TODO: Create additional variables and in Start() save Text component so they aren't being retrieved every time
            // Also, maybe just use GameObject.Find() in Start - may have impact on initial loading time though
            fuelTextObj.GetComponent<Text>().text = "Fuel: " + fuelCount;
            foodTextObj.GetComponent<Text>().text = "Food: " + foodCount;
            crewTextObj.GetComponent<Text>().text = "Crew " + crewCount;
            luminosityTextObj.GetComponent<Text>().text = "Luminosity: " + luminosityCount;
        }
    }
}