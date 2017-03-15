using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Alien : Enemy {

	private static int health = 100;
    public static int defense = 25;
    public static int attack = 20;
    public static int damage = 20;

    public Alien() : base(health, defense, attack, damage){
    }

    public override int getUsedAbility(){
        return 1;
    }

    public override void ability1(Entity target){
		int[] combatVals = new int[3];
        combatVals[0] = UnityEngine.Random.Range(attack - 5, attack + 5);
        combatVals[1] = UnityEngine.Random.Range(damage - 3, damage + 3);
        combatVals[2] = UnityEngine.Random.Range(defense - 5, defense + 5);
        if (UnityEngine.Random.Range(0, 100) >= target.getDefense() - (combatVals[0] + Instantiaion.player.getAttack() + Instantiaion.player.ATTACK))
            target.doDamage(combatVals[1]);
        else
            target.doDamage(0);
    }
    public override void ability2(Entity target){
       
    }
    public override void ability3(Entity target){

    }
    public override void ability4(Entity target){

    }

    public override string getAbility1Name(){
        return "Laser Beam";
    }
    public override string getAbility2Name(){
        return "Claw";
    }
    public override string getAbility3Name(){
        return null;
    }
    public override string getAbility4Name(){
        return null;
    }

	public int getHealth(){
		return health;
	}


}
