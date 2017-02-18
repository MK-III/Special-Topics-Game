using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaPistol : Item {

    public int damage = 35;
    public int attack = 15;
    public int defense = 0;
    public short id;
    public Item.type type;

    public PlasmaPistol(short id, Item.type type) : base(id, type)
    {
        this.type = type;
        this.id = 2;
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