﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonshine : Item {

    public short id;
    public Item.type type;

    public Moonshine(short id, Item.type type) : base(id, type)
    {
        this.type = type;
        this.id = 17;
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

