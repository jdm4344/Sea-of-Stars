﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
 * Holds key game data and methods
 */
public class GameManager : MonoBehaviour
{
    [Header("Resource Data")]
    public float fuelCount = 10; // This is separate to prevent the header from appearing above all 3 attributes
    public float foodCount = 10, luminosityCount = 10, minLuminosity = 0;
    public int crewCount = 0;

    private int foodCost;

    public bool inCombat;
    public CombatShip ship;
    public CombatEnemy enemy;

    //used for progression
    public int currLevel;

    //used for map
    public int currNode;

    public GameObject map;
    public GameObject canvas;

    public bool crewHidden;

    // Start is called before the first frame update
    void Start()
    {
        inCombat = true;
        crewHidden = false;

        if (PlayerPrefs.GetFloat("InCombat") > 0)
        {
            enemy.Health = PlayerPrefs.GetFloat("EnemyHealth");
        }
        else
        {
            enemy.Health = 5 * currLevel;
            enemy.Damage = .5f * currLevel;
        }

        ship.Health = PlayerPrefs.GetFloat("ShipHealth");
        //Debug.Log(PlayerPrefs.GetFloat("ShipHealth"));
        currLevel = PlayerPrefs.GetInt("CurrLevel");
        currNode = PlayerPrefs.GetInt("CurrNode");

        if(enemy.Health <= 0)
        {
            enemy.Health = 5 * currLevel;
            enemy.Damage = .5f * currLevel;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //once specialists/crew are added up crewCount

        ship.inCombat = inCombat;
        enemy.inCombat = inCombat;

        //saving in-game data
        PlayerPrefs.SetFloat("ShipHealth", ship.Health);
        PlayerPrefs.SetFloat("EnemyHealth", enemy.Health);


        if (inCombat)
        {
            //Put combat specific function calls here
            PlayerPrefs.SetInt("InCombat", 1);
        }
        else
        {
            //Put non-combat specific functions here
            PlayerPrefs.SetInt("InCombat", 0);

            if (Input.GetKeyDown(KeyCode.M))
            {
                crewHidden = !crewHidden;

                //bring up map
                if (map.activeSelf)
                {
                    map.SetActive(false);
                    canvas.SetActive(true);
                }
                else
                {
                    map.SetActive(true);
                    canvas.SetActive(false);
                }
            }
        }

        //Getting out of combat
        if (enemy.Health <= 0)
        {
            inCombat = false;
        }

        //foodCount -= crewCount;
        //for some reason subtracts 10 every frame
    }

    public void MoveToNode(MapNode node)
    {
        currLevel++;
        Debug.Log(currLevel);
        currNode = node.nodeNum;

        PlayerPrefs.SetInt("CurrLevel", currLevel);
        PlayerPrefs.SetInt("CurrNode", currNode);
        PlayerPrefs.SetFloat("InCombat", 1);
        PlayerPrefs.SetFloat("EnemyHealth", 5*currLevel);

        SceneManager.LoadScene("TestScene");
    }
}
