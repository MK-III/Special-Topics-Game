using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : Item {

    public short id;
    public Item.type type;

    public FirstAidKit(short id, Item.type type) : base(id, type)
    {
        this.type = type;
        this.id = 13;
    }

    //Heal
    public override int[] ability1()
    {
        GlobalVariables.health += 20;
        return null;
    }

    public override string getNameAbility1()
    {
        return "First Aid Kit";
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

