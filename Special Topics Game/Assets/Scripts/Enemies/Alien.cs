using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Alien : Enemy {

    public static int health = 50;
    public static int defense = 20;
    public static int attack = 20;

    public Alien() : base(health, defense, attack)
    {
    }

    public override int getUsedAbility()
    {
        return 1;
    }

    public override int[] ability1()
    {
        int[] combatVals = new int[3];
        combatVals[0] = attack;
        combatVals[1] = UnityEngine.Random.Range(20, 25);
        combatVals[2] = UnityEngine.Random.Range(defense-3, defense+2);
        Debug.Log("WHY THE FUCK DONT YOU WORK YOU NIGGER-FAGGOT");
        return combatVals;
    }
    public override int[] ability2()
    {
        int[] combatVals = new int[3];
        combatVals[0] = attack;
        combatVals[1] = UnityEngine.Random.Range(20, 25);
        combatVals[2] = UnityEngine.Random.Range(defense - 15, defense - 10);
        return combatVals;
    }
    public override int[] ability3()
    {
        return null;
    }
    public override int[] ability4()
    {
        return null;
    }

    public override string getAbility1Name()
    {
        return "Laser Beam";
    }
    public override string getAbility2Name()
    {
        return "Claw";
    }
    public override string getAbility3Name()
    {
        return null;
    }
    public override string getAbility4Name()
    {
        return null;
    }

}
