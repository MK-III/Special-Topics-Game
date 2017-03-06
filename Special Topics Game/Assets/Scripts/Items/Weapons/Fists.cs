using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fists : Item {

    public int attack = 110;
    public int damage = 20;
    public int defense = -10;
    public static short id = 0;
    public static Item.type type = type.Weapon;

    public Fists() : base(id, type)
    {

    }

    public override void ability1(Entity target)
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack - 10, attack + 10);
        combatVals[1] = Random.Range(damage - 5, damage + 5);
        combatVals[2] = Random.Range(defense - 3, defense + 3);
		DamageCalc(combatVals, target);
    }

    public override string getNameAbility1()
    {
        return "Punch";
    }

    public override void ability2(Entity target)
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack - 130, attack - 120);
        combatVals[1] = Random.Range(damage - 25, damage + 35);
        combatVals[2] = Random.Range(defense - 15, defense - 5);
		DamageCalc(combatVals, target);
    }

    public override string getNameAbility2()
    {
        return "Strangle";
    }
}