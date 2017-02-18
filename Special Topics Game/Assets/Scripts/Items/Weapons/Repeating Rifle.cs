using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingRifle : Item {
    public int attack = 40;
    public int damage = 40;
    public int defense = 0;
    public short id;
    public Item.type type;

    public RepeatingRifle(short id, Item.type type) : base(id, type)
    {
        this.type = type;
        this.id = 6;
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
