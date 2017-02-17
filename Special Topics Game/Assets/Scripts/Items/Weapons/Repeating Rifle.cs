using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingRifle : Item {
    public int attack = 40;
    public int damage = 40;
    public int defense = 0;
    public short id;
    public Item.type type;

    public RepeatingRifle(short id, Item.type type) : base(id, type)
    {
        this.type = type;
        this.id = 6;
    }
    public override int[] ability1()
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack - 3, attack + 3);
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
        combatVals[0] = Random.Range(attack - 17, attack + 13);
        combatVals[1] = Random.Range(damage +14, damage + 16);
        combatVals[2] = Random.Range(defense - 1, defense + 1);
        return combatVals;
    }

    public override string getNameAbility2()
    {
        return "MultiShot";
    }



}
