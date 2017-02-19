using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GattlinGun : Item {
    public int damage = 60;
    public int attack = 5;
    public int defense = -5;
    public static short id = 5;
    public Item.type type;

    public GattlinGun(Item.type type) : base(id, type)
    {
        this.type = type;
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
