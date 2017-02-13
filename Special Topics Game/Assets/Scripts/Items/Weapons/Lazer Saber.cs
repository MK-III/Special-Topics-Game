using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerSaber : Item {
    public int damage = 30;
    public int attack = 20;
    public int defense = 20;
    public short id;
    public Item.type type;

    public LazerSaber(short id, Item.type type) : base(id, type)
    {
        this.type = type;
        this.id = 1;
    }

    //Shoot
    public override int[] ability1()
    {
        int[] combatVals = new int[2];
        //Attack/Cutting value
        combatVals[0] = attack;
        //Damage Value
        combatVals[1] = Random.Range(damage - 3, damage + 3);
        return combatVals;
    }

    public override string getNameAbility1()
    {
        return "Shoot";
    }

    //Melee
    public override int[] ability2()
    {
        int[] combatVals = { 3, 3 };
        return combatVals;
    }

    public override string getNameAbility2()
    {
        return "Melee";
    }



}
