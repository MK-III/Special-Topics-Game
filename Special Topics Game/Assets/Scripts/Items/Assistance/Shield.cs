using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheild : Item {
	
	public int damage = 0;
	public int attack = 0;
	public int defense = 500;
	public static short id = 12;
	public static Item.type type = type.Assist;

	public Sheild() : base(id, type)
	{
	}

	public override void ability1(Entity target)
	{
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
		return "Sheild";
	}

	public override void ability2(Entity target)
	{

	}

	public override string getNameAbility2()
	{
		return null;
	}



}