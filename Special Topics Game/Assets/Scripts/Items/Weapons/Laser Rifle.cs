using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRifle : Item {

    public int damage = 47;
    public int attack = 0;
    public int defense = 0;
    public short id;
    public Item.type type;

    public LaserRifle(short id, Item.type type) : base(id, type)
    {
        this.type = type;
        this.id = 3;
    }

    //Shoot
    public override int[] ability1()
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack + 48, attack + 52);
        combatVals[1] = Random.Range(damage - 1, damage + 1);
        combatVals[2] = Random.Range(defense - 1, defense + 1);
        return combatVals;
    }

    public override string getNameAbility1()
    {
        return "Shoot";
    }

    public override int[] ability2()
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack - 88, attack - 82);
        combatVals[1] = Random.Range(damage + 28, damage + 128);
        combatVals[2] = Random.Range(defense - 1, defense + 1);
        return combatVals;
    }

    public override string getNameAbility2()
    {
        return "OverCharge";
    }



}
