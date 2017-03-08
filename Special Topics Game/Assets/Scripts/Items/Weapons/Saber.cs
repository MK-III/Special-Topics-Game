using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : Item {
    public int damage = 55;
    public int attack = 0;
    public int defense = -15;
    public static short id = 7;
    public static Item.type type = type.Weapon;

    public Saber() : base(id, type)
    {

    }

    public override void ability1(Entity target)
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack + 75, attack + 85);
        combatVals[1] = Random.Range(damage - 7, damage + 7);
        combatVals[2] = Random.Range(defense - 5, defense + 5);
		DamageCalc(combatVals, target);
    }

    public override string getNameAbility1()
    {
        return "Slash";
    }

    public override void ability2(Entity target)
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack -20 , attack -10);
        combatVals[1] = Random.Range(damage + 15, damage + 25);
        combatVals[2] = Random.Range(defense - 20, defense - 10);
		DamageCalc(combatVals, target);
    }

    public override string getNameAbility2()
    {
        return "Charge";
    }
}


