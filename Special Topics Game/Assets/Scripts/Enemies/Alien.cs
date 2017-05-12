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
    public static int damage = 100;
    private int healCount = 0;
    public int usedAbility = 0;

    public Alien() : base(health, defense, attack, damage){
    }
    public override void onDeath()
    {
        Instantiaion.player.discoverItem(new Revolver());
    }
    public override int getUsedAbility(int currentHealth)
    {
        if (currentHealth < 30)
        {
            if (healCount <= 3)
            {
                if (UnityEngine.Random.Range(0, 100) >= 50)
                {
                    healCount += 1;
                    usedAbility = 4;
                }
                else
                {
                    usedAbility = 2;
                }
            }
        }
        else
        {
        switch (Instantiaion.player.getUsedAbility())
        {
                    case 1:
                        usedAbility = 1;
                        break;
                    case 2:
                        usedAbility = 3;
                        break;
                    case 3:
                        usedAbility = 1;
                        break;
                    case 4:
                        usedAbility = 2;
                        break;
                    default:
                        usedAbility = 1;
                        break;
        }
        }
        return usedAbility;
    }
    
    public override string getUsedAbilityName()
    {
        string text;
        switch (usedAbility)
        {
            case 1:
                text = getAbility1Name();
                break;
            case 2:
                text = getAbility2Name();
                break;
            case 3:
                text = getAbility3Name();
                break;
            case 4:
                text = getAbility4Name();
                break;
            default:
                text = "No Enemy Ability Used";
                break;
        }
        return text;
    }

    public override void ability1(Entity target){
		int[] combatVals = new int[3];
        combatVals[0] = UnityEngine.Random.Range(attack - 5, attack + 5);
        combatVals[1] = UnityEngine.Random.Range(damage - 3, damage + 3);
        combatVals[2] = UnityEngine.Random.Range(defense - 5, defense + 5);
        DamageCalc(combatVals, target);
    }
    public override void ability2(Entity target){
        int[] combatVals = new int[3];
        combatVals[0] = UnityEngine.Random.Range(attack - 15, attack - 55);
        combatVals[1] = UnityEngine.Random.Range(damage + 20, damage + 30);
        combatVals[2] = UnityEngine.Random.Range(defense - 25, defense - 15);
        DamageCalc(combatVals, target);
    }
    public override void ability3(Entity target){
        int[] combatVals = new int[3];
        combatVals[0] = UnityEngine.Random.Range(attack - 25, attack -15);
        combatVals[1] = UnityEngine.Random.Range(damage - 8, damage - 3);
        combatVals[2] = UnityEngine.Random.Range(defense - 5, defense + 5);
        if (UnityEngine.Random.Range(0, 100) >= target.getDefense() - (combatVals[0] + Instantiaion.player.getAttack() + Instantiaion.player.ATTACK))
        {
            target.doDamage(combatVals[1]);
            heal(combatVals[1]);
        }
        else
            target.doDamage(0);
    }
    public override void ability4(Entity target){
        heal(15);
    }

    public override string getAbility1Name(){
        return "Laser Blast";
    }
    public override string getAbility2Name(){
        return "UFO Charge";
    }
    public override string getAbility3Name(){
        return "Tractor Beam";
    }
    public override string getAbility4Name(){
        return "Healing Drones";
    }

	public int getHealth(){
		return health;
	}


}
