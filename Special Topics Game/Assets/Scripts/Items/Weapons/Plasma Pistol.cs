using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaPistol : Item {

    public int attack = 15;
    public int damage = 35;
    public int defense = 0;
    public static short id = 2;
    public static string name = "Plasma Pistol";
    public static Item.type type = type.Weapon;

    public PlasmaPistol() : base(id, type, name)
    {

    }

    public override void ability1(Entity target)
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack - 5, attack + 5);
        combatVals[1] = Random.Range(damage - 3, damage + 3);
        combatVals[2] = Random.Range(defense - 5, defense + 5);
		if (Random.Range(0, 100) >= target.getDefense() - (combatVals[0] + Instantiaion.player.getAttack()))
        {
            target.doDamage(combatVals[1]);
            DamageOverTime(target, 3, 6, 3);
        }
    }

    public override string getNameAbility1()
    {
        return "Plasma Burn";
    }

    public override void ability2(Entity target)
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack - 15, attack - 5);
        combatVals[1] = Random.Range(damage +10, damage + 20);
        combatVals[2] = Random.Range(defense - 15, defense - 5);
		if (Random.Range(0, 100) >= target.getDefense() - (combatVals[0] + Instantiaion.player.getAttack()))
        {
            target.doDamage(combatVals[1]);
            DamageOverTime(target, 1, 2, 5);
        }
}

    public override string getNameAbility2()
    {
        return "Plasma Stab";
    }

}