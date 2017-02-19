using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanoBots : Item {

    public static short id = 19;
    public Item.type type;

    public NanoBots(Item.type type) : base(id, type)
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
