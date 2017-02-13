using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fists : Item {

    public int damage = 5;
    public int attack = 100;
    public int defense = 0;
    public short id;
    public Item.type type;

    public Fists(short id, Item.type type) : base(id, type)
    {
        this.type = type;
        this.id = 0;
    }

    //Punch
    public override int[] ability1()
    {
        int[] combatVals = new int[2];
        //Attack/Cutting value
        combatVals[0] = attack;
        //Damage Value
        combatVals[1] = Random.Range(damage - 1, damage + 1);
        return combatVals;
    }

    public override string getNameAbility1()
    {
        return "Punch";
    }

    //Strangle
    public override int[] ability2()
    {
        int[] combatVals = { 25, 75, 0 };
        return combatVals;
    }

    public override string getNameAbility2()
    {
        return "Strangle";
    }



}
