using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item{

    short id;
    private type itemType;

	public Item(short id, type itemType)
    {
        this.id = id;
        this.itemType = itemType;
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

    public int DamageCalc(int[] combatVals, int targetDef)
    {
        combatVals = new int[3];
        if (Random.Range(0, 100) >= targetDef - (combatVals[0] + Instantiaion.player.addAttack))
            return combatVals[1];
        else
            return 0;
    }


}
