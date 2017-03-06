using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonshine : Item {

    public static short id = 18;
    public static Item.type type = type.Medical;

    public Moonshine() : base(id, type)
    {
    }

    public override void ability1(Entity target)
    {
        TurnStableLoop(2,
            () =>
            {
                Instantiaion.player.setDamage(Instantiaion.player.getDamage() + 50);
            },
            () =>
            {
				Instantiaion.player.setAttack(Instantiaion.player.DAMAGE);
            });
    }

    public override string getNameAbility1()
    {
        return "Moonshine";
    }

    public override void ability2(Entity target)
    {

    }

    public override string getNameAbility2()
    {
        return null;
    }
}
