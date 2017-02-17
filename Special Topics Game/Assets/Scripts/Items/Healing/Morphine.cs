using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morphine : Item {

    public short id;
    public Item.type type;

    public Morphine(short id, Item.type type) : base(id, type)
    {
        this.type = type;
        this.id = 16;
    }

    //Heal
    public override int[] ability1()
    {
        GlobalVariables.PDefense += 50;
        return null;
    }

    public override string getNameAbility1()
    {
        return "Morphine";
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

