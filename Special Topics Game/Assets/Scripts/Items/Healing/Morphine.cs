using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morphine : Item {

    public static short id = 17;
    public static string name = "Morphine";
    public static Item.type type = type.Medical;

    public Morphine() : base(id, type, name)
    {
    }

    public override void ability1(Entity target)
    {
        TurnStableLoop(2,
            () =>
            {
                Instantiaion.player.setDefense(Instantiaion.player.getDefense() + 50);
            },
            () =>
            {
				Instantiaion.player.setAttack(Instantiaion.player.DEFENSE);
            });
    }

    public override string getNameAbility1()
    {
        return "Morphine";
    }

    public override void ability2(Entity target)
    {

    }

    public override string getNameAbility2()
    {
        return null;
    }
}