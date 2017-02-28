using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerSaber : Item {

    public int damage = 65;
    public int attack = 90;
    public int defense = -15;
    public static short id = 4;
    public static Item.type type = type.Weapon;

    public LazerSaber() : base(id, type)
    {

    }

    public override void ability1(Entity target)
    {
        int[] combatVals = new int[3];
        combatVals[0] = Random.Range(attack - 5, attack + 5);
        combatVals[1] = Random.Range(damage - 5, damage + 5);
        combatVals[2] = Random.Range(defense - 2, defense + 3);
        target.doDamage(base.DamageCalc(combatVals, target.getDefense()));
    }

    public override string getNameAbility1()
    {
        return "Slash";
    }

    public override void ability2(Entity target)
    {
        int chance = Random.Range(30, 40);
        if (Random.Range(0, 100) >= chance)
        {
            TurnStableLoop(1,
            () =>
            {
                target.changeTarget(target);
            },
            () =>
            {
                target.changeTarget(Instantiaion.player);
            });
        }
        else
        {
            target.doDamage(0);
        }
    }

    public override string getNameAbility2()
    {
        return "Deflect";
    }
}
