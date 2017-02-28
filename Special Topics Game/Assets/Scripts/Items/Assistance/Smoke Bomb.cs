using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBomb : Item {

    public int damage = 5;
    public int attack = 40;
    public int defense = 0;
    public static short id = 13;
    public static Item.type type = type.Assist;

    public SmokeBomb() : base(id, type)
    {
    }

    public override void ability1(Entity target)
    {
        int[] combatVals = new int[3];
        combatVals[0] = attack;
        combatVals[1] = Random.Range(damage - 15, damage + 15);
        combatVals[2] = Random.Range(defense - 5, defense + 5);
        TurnStableLoop(2,
            () =>
            {
                target.setAttack(target.getAttack() - attack);
            },
            () =>
            {
                target.setAttack(0);
            });
    }

    public override string getNameAbility1()
    {
        return "Vape Naysh";
    }

    public override void ability2(Entity target)
    {

    }

    public override string getNameAbility2()
    {
        return null;
    }



}