﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatEntity : MonoBehaviour
{
    //properties
    public float Health { get; set; }
    public float Damage { get; set; }
    public float FireRate { get; set; }
    public bool AttackReady { get; set; }
    public string ID;

    //Timing
    float prevTime;

    public bool inCombat = true;

    public List<Text> log;

    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //Attack Cooldown
        float currTime = Time.time;
        if (currTime - prevTime > FireRate)
        {
            AttackReady = true;
        }
        else { AttackReady = false; }

    }

    public virtual void TakeDamage(float dam)
    {
        Health -= dam;
        if(Health < 0)
        {
            Health = 0;
        }
        Debug.Log(ID + " now has " + Health + " Health");
    }

    public virtual void Attack(CombatEntity target)
    {
        if (AttackReady)
        {
            if(target.Health <= 0.0f)
            {
                Debug.Log("Enemy is defeated");
                inCombat = false;
                return;
            }
            AttackReady = false;
            prevTime = Time.time;
            target.TakeDamage(Damage);
            Debug.Log(ID + " did " + Damage + " Damage to " + target.ID);

            log[1].text = log[0].text;
            log[0].text = ID + " did " + Damage + " Damage to " + target.ID;
        }
        else
        {
            if(ID != "Squid")
            {
                Debug.Log(ID + " Attack Cooldown: " + (FireRate - (Time.time - prevTime)));
            }
        }
    }

    public void ResetAttackTimer()
    {
        prevTime = Time.time;
    }
}
