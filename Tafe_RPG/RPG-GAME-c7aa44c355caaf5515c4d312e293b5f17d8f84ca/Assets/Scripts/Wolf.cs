﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Enemy
{
    [Header("Wolf Stats")]
    public float curStamina;
    public float maxStamina;

    public override void Attack()
    {
        base.Attack();
    }
    public void BiteDamage()
    {
        int critChance = Random.Range(0, 21);
        float critDamage = 0;
        if(critChance == 20)
        {
            critDamage = Random.Range(baseDamage / 2, baseDamage * difficulty);
        }
        player.GetComponent<PlayerHandler>().curHealth -= (baseDamage * difficulty) + critDamage;
    }
}
