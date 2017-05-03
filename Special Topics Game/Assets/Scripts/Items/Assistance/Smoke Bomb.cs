using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBomb : Item {

    public int damage = 5;
    public int attack = -40;
    public int defense = 0;
    public static short id = 13;
    public static string name = "Smoke Bomb";
    public static Item.type type = type.Assist;

    public SmokeBomb() : base(id, type, name)
    {
    }

    public override void ability1(Entity target)
    {
		target.doDamage (Random.Range(damage - 5, damage + 5));
        TurnStableLoop(2,
            () =>
            {
                target.setAttack(target.getAttack() + attack);
            },
            () =>
            {
                target.setAttack(target.ATTACK);
            });
    }

    public override string getNameAbility1()
    {
        return "Smoke Bomb";
    }

    public override void ability2(Entity target)
    {

    }

    public override string getNameAbility2()
    {
        return null;
    }



}