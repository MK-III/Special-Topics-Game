using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : Item {

    public int damage = 55;
    public int attack = 8999;
    public int defense = 0;
    public static short id = 8;
    public static Item.type type= type.Assist;

    public Dynamite() : base(id, type)
    {
    }
		
    public override void ability1(Entity target)
    {
        int[] combatVals = new int[3];
        combatVals[0] = attack;
        combatVals[1] = Random.Range(damage - 15, damage + 15);
        combatVals[2] = Random.Range(defense - 5, defense + 5);
		DamageCalc(combatVals, target);
    }

    public override string getNameAbility1()
    {
        return "Explode";
    }
		
    public override void ability2(Entity target)
    {

    }

    public override string getNameAbility2()
    {
        return null;
    }



}
