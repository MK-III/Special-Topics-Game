using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Enemy : Entity{

    public int health;
    public int defense;
    public int attack;

    public Enemy(int health, int defense, int attack, Entity target)
    {
        this.health = health;
        this.defense = defense;
        this.attack = attack;
    }

    public abstract void changeTarget(Entity newTarget);

    public override abstract void ability1(Entity target);
    public override abstract void ability2(Entity target);
    public override abstract void ability3(Entity target);
    public override abstract void ability4(Entity target);

    public override abstract string getAbility1Name();
    public override abstract string getAbility2Name();
    public override abstract string getAbility3Name();
    public override abstract string getAbility4Name();

    public abstract int getUsedAbility();

    public override void doDamage(int damage)
    {
        health -= damage;
    }

    public void killEnemy()
    {
        GlobalVariables.inCombat = false;
        SceneManager.UnloadSceneAsync("Scenes/combat");
    }
}
