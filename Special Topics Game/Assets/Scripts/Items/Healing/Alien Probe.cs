﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienProbe : Item {

    public static short id = 16;
    public static Item.type type = type.Medical;

    public AlienProbe() : base(id, type)
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
