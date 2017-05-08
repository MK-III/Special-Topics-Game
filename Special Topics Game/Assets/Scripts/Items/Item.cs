using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public abstract class Item{

    public short id;
    private type itemType;
	public string name;

	public Item(short id, type itemType, string name)
    {
        this.id = id;
        this.itemType = itemType;
		this.name = name;
    }

    public bool checkType(Item item, type checkType)
    {
        if (item.GetItemType() == checkType)
            return true;
        else
            return false;
    }

    public enum type
    {
        Weapon,
        Medical,
        Assist
    }
		
    public abstract void ability1(Entity target);
    public abstract void ability2(Entity target);
    public abstract string getNameAbility1();
    public abstract string getNameAbility2();

    public type GetItemType(){
        return itemType;
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
