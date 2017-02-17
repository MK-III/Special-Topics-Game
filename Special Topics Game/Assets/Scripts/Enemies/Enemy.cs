using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Enemy{

    public int health;
    public int defense;
    public int attack;

    public Enemy(int health, int defense, int attack)
    {
        this.health = health;
        this.defense = defense;
        this.attack = attack;
    }

    public abstract int[] ability1();
    public abstract int[] ability2();
    public abstract int[] ability3();
    public abstract int[] ability4();

    public abstract string getAbility1Name();
    public abstract string getAbility2Name();
    public abstract string getAbility3Name();
    public abstract string getAbility4Name();

    public abstract int getUsedAbility();

    public void doDamage(int damage)
    {
        health -= damage;
    }

    public void killEnemy()
    {
        GlobalVariables.inCombat = false;
        SceneManager.UnloadSceneAsync("Scenes/combat");
    }
}
