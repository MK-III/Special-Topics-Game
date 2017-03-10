using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingRifle : Item {

    public int attack = 40;
    public int damage = 40;
    public int defense = 0;
    public static short id = 6;
    public static string name = "Repeating Rifle";
    public static Item.type type = type.Weapon;

    public RepeatingRifle() : base(id, type, name)
    {

    }

    public override void ability1(Entity target)
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack - 2, attack + 2);
        combatVals[1] = Random.Range(damage - 1, damage + 1);
        combatVals[2] = Random.Range(defense - 2, defense + 3);
		DamageCalc(combatVals, target);
    }

    public override string getNameAbility1()
    {
        return "Shoot";
    }

    public override void ability2(Entity target)
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack - 23, attack - 17);
        combatVals[1] = Random.Range(damage +14, damage + 16);
        combatVals[2] = Random.Range(defense - 2, defense +3);
		DamageCalc(combatVals, target);
    }

    public override string getNameAbility2()
    {
        return "Multi Shot";
    }
}
