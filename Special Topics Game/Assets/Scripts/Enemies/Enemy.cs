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

    public abstract int getUsedAbility();

    public override void doDamage(int damage)
	{
		GlobalVariables.eDamageDone = damage;
		health -= damage;
	}

    public void killEnemy()
    {
        GlobalVariables.inCombat = false;
        SceneManager.UnloadSceneAsync("Scenes/combat");
    }
}
