using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashBang : Item {
	
	public int damage = 10;
	public int attack = 0;
	public int defense = -40;
	public static short id = 10;
    public static string name = "Flash Bang";
    public static Item.type type = type.Assist;

	public FlashBang() : base(id, type, name)
	{
	}

	public override void ability1(Entity target)
	{
		target.doDamage (Random.Range(damage - 3, damage + 3));
		TurnStableLoop(2,
			() =>
			{
				target.setDefense(target.getDefense() + defense);
			},
			() =>
			{
				target.setDefense(target.DEFENSE);
			});
	}

	public override string getNameAbility1()
	{
		return "Flash Bang";
	}

	public override void ability2(Entity target)
	{

	}

	public override string getNameAbility2()
	{
		return null;
	}



}
