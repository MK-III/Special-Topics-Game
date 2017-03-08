using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRifle : Item {

    public int damage = 47;
    public int attack = 0;
    public int defense = 0;
    public static short id = 3;
    public static Item.type type = type.Weapon;

    public LaserRifle() : base(id, type)
    {

    }

    public override void ability1(Entity target)
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack + 55, attack + 45);
        combatVals[1] = Random.Range(damage - 1, damage + 1);
        combatVals[2] = Random.Range(defense - 2, defense + 3);
		DamageCalc(combatVals, target);
    }

    public override string getNameAbility1()
    {
        return "Laser Shot";
    }

    public override void ability2(Entity target)
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack - 88, attack - 82);
        combatVals[1] = Random.Range(damage - 28, damage + 128);
        combatVals[2] = Random.Range(defense - 2, defense + 3);
		DamageCalc(combatVals, target);
    }

    public override string getNameAbility2()
    {
        return "Head Shot";
    }
}
