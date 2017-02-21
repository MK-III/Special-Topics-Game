using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fists : Item {

    public int damage = 20;
    public int attack = 0;
    public int defense = -10;
    public static short id = 0;
    public static Item.type type = type.Weapon;

    public Fists() : base(id, type)
    {
    }

    public override void ability1(Entity target)
    {
        target.doDamage(15);
    }

    public override string getNameAbility1()
    {
        return "Punch";
    }

    public override void ability2(Entity target)
    {

    }

    public override string getNameAbility2()
    {
        return "Strangle";
    }




}
