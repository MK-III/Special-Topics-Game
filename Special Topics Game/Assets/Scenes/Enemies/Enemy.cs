using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Enemy : Entity{

    public Entity target = Instantiaion.player;
	private int health;
	public readonly int DEFENSE;
	public readonly int ATTACK;
	public readonly int DAMAGE;
	public int defense;
    public int attack;
    public int damage;

	public Enemy(int health, int DEFENSE, int ATTACK, int DAMAGE)
    {
		this.defense = DEFENSE;
		this.damage = DAMAGE;
		this.attack = ATTACK;
        this.health = health;
		this.DEFENSE = DEFENSE;
		this.ATTACK = ATTACK;
		this.DAMAGE = DAMAGE;
    }

    public override void changeTarget(Entity newTarget)
    {
        this.target = newTarget;
    }

	public int getHealth(){
		return health;
	}

	public void setHealth(int val){
		health = val;
	}

    public override abstract void ability1(Entity target);
    public override abstract void ability2(Entity target);
    public override abstract void ability3(Entity target);
    public override abstract void ability4(Entity target);

    public override abstract string getAbility1Name();
    public override abstract string getAbility2Name();
    public override abstract string getAbility3Name();
    public override abstract string getAbility4Name();

    public override void setAttack(int value)
    {
        attack = value;
    }

    public override void setDefense(int value)
    {
        defense = value;
    }

    public override void setDamage(int value)
    {
        damage = value;
    }

    public override int getAttack()
    {
        return attack;
    }

    public override int getDamage()
    {
        return damage;
    }

    public override int getDefense()
    {
        return defense;
    }

    public abstract int getUsedAbility(int currentHealth);
    public abstract string getUsedAbilityName();

    public override void doDamage(int damage)
	{
		GlobalVariables.eDamageDone = damage;
		health -= damage;
	}
    public override void heal(int hp)
    {
        GlobalVariables.eHealed = hp;
        health += hp;
    }
    public void killEnemy()
    {
        GlobalVariables.inCombat = false;
        SceneManager.UnloadSceneAsync("Scenes/combat");
    }
    public void DamageCalc(int[] combatVals, Entity target)
    {
        if (UnityEngine.Random.Range(0, 100) >= target.getDefense() - (combatVals[0] + Instantiaion.player.getAttack() + Instantiaion.player.ATTACK))
            target.doDamage(combatVals[1]);
        else
            target.doDamage(0);
    }

    public void DamageOverTime(Entity target, int lowerDamage, int higherDamage, int turnCount)
    {
        int initialTurn = GlobalVariables.turn;
        int initialTurnCounter = initialTurn;
        while (GlobalVariables.turn - initialTurn > turnCount)
        {
            if (GlobalVariables.turn == initialTurnCounter)
            {
                target.doDamage(UnityEngine.Random.Range(lowerDamage, higherDamage));
                initialTurnCounter += 1;
            }
            else
            {
                target.doDamage(0);
            }
        }
    }

    public void TurnStableLoop(int turnCount, Action ifTrue, Action onFinished)
    {
        int initialTurn = GlobalVariables.turn;
        int initialTurnCounter = initialTurn;
        while (GlobalVariables.turn - initialTurn > turnCount)
        {
            if (GlobalVariables.turn == initialTurnCounter)
            {
                ifTrue();
            }
            else
            {
                onFinished();
            }
        }
    }
}
