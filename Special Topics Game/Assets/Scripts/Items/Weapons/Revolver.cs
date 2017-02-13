using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Item {

    public int attack = 5;
    public int damage = 30;
    public int defense = -5;
    public short id;
    public Item.type type;

    public Revolver(short id, Item.type type) : base(id, type)
    {
        this.type = type;
        this.id = 1;
    }    
   
    //Shoot
    public override int[] ability1()
    {
        int[] combatVals = new int[3];
        //Attack/Cutting value
        combatVals[0] = attack;
        //Damage Value
        combatVals[1] = Random.Range(damage - 3, damage + 3);
        combatVals[2] = Random.Range(defense - 5, defense + 5);
        return combatVals;
    }

    public override string getNameAbility1()
    {
        return "Shoot";
    }

    //Melee
    public override int[] ability2()
    {
        int[] combatVals = { 100, 50 }; //(*) Need to figure out how to lower defense for the enemies attack
        return combatVals;
    }

    public override string getNameAbility2()
    {
        return "Melee";
    }

    //public override int[] ChangeStats(int PStat, int Changeto)
   // {
   //     int[] changes = { };
   //     return changes;
  //  }

}
