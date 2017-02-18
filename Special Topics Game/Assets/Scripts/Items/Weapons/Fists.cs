using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fists : Item {

    public int damage = 20;
    public int attack = 0;
    public int defense = -10;
    public short id;
    public Item.type type;

    public Fists(short id, Item.type type) : base(id, type)
    {
        this.type = type;
        this.id = 0;
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
