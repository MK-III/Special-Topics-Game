using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Item {

    public int attack = 50;
    public int damage = 30;
    public int defense = 0;
    public static short id = 1;
    public static Item.type type = type.Weapon;

    public Revolver() : base(id, type)
    {

    }

    public override void ability1(Entity target)
	{
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack-5, attack+5);
        combatVals[1] = Random.Range(damage - 3, damage + 3);
        combatVals[2] = Random.Range(defense - 5, defense + 5);
		DamageCalc(combatVals, target);
    }

    public override string getNameAbility1()
    {
        return "Shoot";
    }

    public override void ability2(Entity target)
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack-25, attack-15);
        combatVals[1] = Random.Range(damage-5, damage +15);
        combatVals[2] = Random.Range(defense -15, defense -5);
		DamageCalc(combatVals, target);
    }

    public override string getNameAbility2()
    {
        return "Pistol Whip";
    }
}
