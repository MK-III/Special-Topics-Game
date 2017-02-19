using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienProbe : Item {

    public static short id = 16;
    public Item.type type;

    public AlienProbe(Item.type type) : base(id, type)
    {
        this.type = type;
    }

    public override void ability1(Entity target)
    {

    }

    public override string getNameAbility1()
    {
        return "Advanced First Aid Kit";
    }

    public override void ability2(Entity target)
    {

    }

    public override string getNameAbility2()
    {
        return null;
    }



}
