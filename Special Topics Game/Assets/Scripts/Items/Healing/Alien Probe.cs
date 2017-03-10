using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienProbe : Item {

    public static short id = 16;
    public static string name = "Alien Probe";
    public static Item.type type = type.Medical;

    public AlienProbe() : base(id, type, name)
    {
  
    }

    public override void ability1(Entity target)
    {
        TurnStableLoop(2,
            () =>
            {
				Instantiaion.player.setAttack(Instantiaion.player.getAttack() + 50);
            },
            () =>
            {
				Instantiaion.player.setAttack(Instantiaion.player.ATTACK);
            });
    }

    public override string getNameAbility1()
    {
        return "ALien Probe";
    }

    public override void ability2(Entity target)
    {

    }

    public override string getNameAbility2()
    {
        return null;
    }
}
