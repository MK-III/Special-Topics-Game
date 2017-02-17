﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fists : Item {

    public int damage = 20;
    public int attack = 0;
    public int defense = -10;
    public short id;
    public Item.type type;

    public Fists(short id, Item.type type) : base(id, type)
    {
        this.type = type;
        this.id = 0;
    }

    public override int[] ability1()
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack + 105, attack +115);
        combatVals[1] = Random.Range(damage - 5, damage + 5);
        combatVals[2] = Random.Range(defense - 2, defense + 2);
        return combatVals;
    }

    public override string getNameAbility1()
    {
        return "Punch";
    }

    public override int[] ability2()
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack -17, attack -13);
        combatVals[1] = Random.Range(damage +20, damage + 40);
        combatVals[2] = Random.Range(defense - 12, defense - 8);
        return combatVals;
    }

    public override string getNameAbility2()
    {
        return "Strangle";
    }



}
