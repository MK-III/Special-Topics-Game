using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Item {

    public int attack = 15;
    public int damage = 30;
    public int defense = 0;
    public short id;
    public Item.type type;

    public Revolver(short id, Item.type type) : base(id, type)
    {
        this.type = type;
        this.id = 1;
    }    
   
    public override int[] ability1()
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack - 3, attack + 3);
        combatVals[1] = Random.Range(damage - 3, damage + 3);
        combatVals[2] = Random.Range(defense-1, defense +1);
        return combatVals;
    }

    public override string getNameAbility1()
    {
        return "Shoot";
    }

    public override int[] ability2()
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack - 12, attack - 8);
        combatVals[1] = Random.Range(damage - 5, damage + 15);
        combatVals[2] = Random.Range(defense - 12, defense -8);
        return combatVals;
    }

    public override string getNameAbility2()
    {
        return "Pistol Whip dat Bitch";
    }
}
