using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : Item {
    public int damage = 55;
    public int attack = 0;
    public int defense = -15;
    public short id;
    public Item.type type;

    public Saber(short id, Item.type type) : base(id, type)
    {
        this.type = type;
        this.id = 19;
    }

    public override int[] ability1()
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack + 75, attack + 85);
        combatVals[1] = Random.Range(damage - 5, damage + 5);
        combatVals[2] = Random.Range(defense - 5, defense + 5);
        return combatVals;
    }

    public override string getNameAbility1()
    {
        return "Slash";
    }

    public override int[] ability2()
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack - 20, attack - 10);
        combatVals[1] = Random.Range(damage + 15, damage + 25);
        combatVals[2] = Random.Range(defense - 20, defense - 10);
        return combatVals;
    }

    public override string getNameAbility2()
    {
        return "Charge";
    }



}

