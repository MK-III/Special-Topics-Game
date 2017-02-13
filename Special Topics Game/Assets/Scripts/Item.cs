using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item{

    short id;
    type itemType;

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

    public abstract int[] ability1();
    public abstract int[] ability2();

    public abstract string getNameAbility1();
    public abstract string getNameAbility2();

    //public abstract int[] ChangeStats();

}
