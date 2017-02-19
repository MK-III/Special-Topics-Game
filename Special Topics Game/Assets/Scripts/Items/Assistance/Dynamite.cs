using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : Item {

    public int damage = 30;
    public int attack = 20;
    public int defense = 20;
    public static short id = 8;
    public Item.type type;

    public Dynamite(Item.type type) : base(id, type)
    {
        this.type = type;
    }

    //Explode
    public override void ability1(Entity target)
    {
       
    }

    public override string getNameAbility1()
    {
        return "Explode";
    }

    //No second ability
    public override void ability2(Entity target)
    {

    }

    public override string getNameAbility2()
    {
        return null;
    }



}
