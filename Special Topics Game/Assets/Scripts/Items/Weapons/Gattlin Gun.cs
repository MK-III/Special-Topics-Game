using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GattlinGun : Item {
    public int damage = 60;
    public int attack = 5;
    public int defense = -5;
    public short id;
    public Item.type type;

    public GattlinGun(short id, Item.type type) : base(id, type)
    {
        this.type = type;
        this.id = 5;
    }

    public override int[] ability1()
    {
        //If gattlingun misses with ability one it will deal only 20 damage
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack - 2, attack + 2);
        combatVals[1] = Random.Range(damage - 10, damage + 10);
        combatVals[2] = Random.Range(defense - 2, defense +2);
        return combatVals;
    }

    public override string getNameAbility1()
    {
        return "Spray";
    }

    public override int[] ability2()
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack - 30, attack - 20);
        combatVals[1] = Random.Range(damage + 20, damage + 30);
        combatVals[2] = Random.Range(defense - 2, defense + 2);
        return combatVals;
    }

    public override string getNameAbility2()
    {
        return "Focus";
    }



}
