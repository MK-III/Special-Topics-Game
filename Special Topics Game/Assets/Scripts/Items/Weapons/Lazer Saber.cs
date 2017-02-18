using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerSaber : Item {
    public int damage = 65;
    public int attack = 90;
    public int defense = -15;
    public short id;
    public Item.type type;

    public LazerSaber(short id, Item.type type) : base(id, type)
    {
        this.type = type;
        this.id = 4;
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
