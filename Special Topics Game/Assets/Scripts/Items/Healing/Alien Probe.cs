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

    //Heal
    public override int[] ability1()
    {
        GlobalVariables.PAttack += 50;
        return null;
    }

    public override string getNameAbility1()
    {
        return "Alien Probe";
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
