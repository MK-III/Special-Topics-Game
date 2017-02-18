using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienProbe : Item {

    public short id;
    public Item.type type;

    public AlienProbe(short id, Item.type type) : base(id, type)
    {
        this.type = type;
        this.id = 15;
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
