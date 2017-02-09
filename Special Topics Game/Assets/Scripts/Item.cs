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
}
