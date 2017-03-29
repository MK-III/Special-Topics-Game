using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GattlinGun : Item {

    public int damage = 60;
    public int attack = 5;
    public int defense = -5;
    public static short id = 5;
    public static string name = "Gattlin Gun";
    public static Item.type type = type.Weapon;

    public GattlinGun() : base(id, type, name)
    {

    }

    public override void ability1(Entity target)
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack - 5, attack + 5);
        combatVals[1] = Random.Range(damage - 10, damage + 10);
        combatVals[2] = Random.Range(defense - 5, defense + 5);
		if (Random.Range(0, 100) >= target.getDefense() - (combatVals[0] + Instantiaion.player.getAttack()))
			target.doDamage(combatVals[1]);
        else
            target.doDamage(Random.Range(15,25));

    }

    public override string getNameAbility1()
    {
        return "Spray";
    }

    public override void ability2(Entity target)
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack -30, attack -20);
        combatVals[1] = Random.Range(damage +15, damage + 25);
        combatVals[2] = Random.Range(defense +5, defense +10);
		DamageCalc(combatVals, target);
    }

    public override string getNameAbility2()
    {
        return "Focus";
    }
}
