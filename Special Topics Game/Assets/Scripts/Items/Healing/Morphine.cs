using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morphine : Item {

    public static short id = 17;
    public Item.type type;

    public Morphine(Item.type type) : base(id, type)
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

