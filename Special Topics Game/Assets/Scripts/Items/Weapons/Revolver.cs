using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Item {

    public int attack = 15;
    public int damage = 30;
    public int defense = 0;
    public static short id = 1;
    public static Item.type type = type.Weapon;

    public Revolver() : base(id, type)
    {
    }

    public override void ability1(Entity target)
    {

    }

    public override string getNameAbility1()
    {
        return "";
    }

    public override void ability2(Entity target)
    {

    }

    public override string getNameAbility2()
    {
        return null;
    }

}
