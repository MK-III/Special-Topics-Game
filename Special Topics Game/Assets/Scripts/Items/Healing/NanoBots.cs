using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanoBots : Item {

    public short id;
    public Item.type type;

    public NanoBots(short id, Item.type type) : base(id, type)
    {
        this.type = type;
        this.id = 18;
    }

    //Heal
    public override int[] ability1()
    {
        GlobalVariables.health += 60;
        return null;
    }

    public override string getNameAbility1()
    {
        return "NanoBots";
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
