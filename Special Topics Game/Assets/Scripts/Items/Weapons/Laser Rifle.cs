﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRifle : Item {

    public int damage = 47;
    public int attack = 0;
    public int defense = 0;
    public static short id = 3;
    public Item.type type;

    public LaserRifle(Item.type type) : base(id, type)
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
