using System.Collections;
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

    //Heal
    public override int[] ability1()
    {
        GlobalVariables.PDamage += 50;
        return null;
    }

    public override string getNameAbility1()
    {
        return "Moonshine";
    }

    //No second ability
    public override int[] ability2()
    {
        return null;
    }

    public override string getNameAbility2()
    {
        return null;
    }



}

