using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerSaber : Item {
    public int damage = 65;
    public int attack = 90;
    public int defense = -15;
    public short id;
    public Item.type type;

    public LazerSaber(short id, Item.type type) : base(id, type)
    {
        this.type = type;
        this.id = 4;
    }

    public override int[] ability1()
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack - 5, attack + 5);
        combatVals[1] = Random.Range(damage - 5, damage + 5);
        combatVals[2] = Random.Range(defense -5, defense + 5);
        return combatVals;
    }

    public override string getNameAbility1()
    {
        return "Slash";
    }

    public override int[] ability2()
    {
        return null;
    }

    public override string getNameAbility2()
    {
        return "Deflect";
    }



}
