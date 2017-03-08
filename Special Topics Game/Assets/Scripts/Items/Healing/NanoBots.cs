using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanoBots : Item {

    public static short id = 19;
    public static Item.type type = type.Medical;

    public NanoBots() : base(id, type)
    {
    }

    public override void ability1(Entity target)
    {
        TurnStableLoop(2,
            () =>
            {
                Instantiaion.player.setHealth(Instantiaion.player.getHealth() + 50);
            },
            () =>
            {
                //Nothing happens; Loop ends
            });
    }

    public override string getNameAbility1()
    {
        return "NanoBots";
    }

    public override void ability2(Entity target)
    {

    }

    public override string getNameAbility2()
    {
        return null;
    }
}