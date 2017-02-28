using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvFirstAidKit : Item {

    public static short id = 15;
    public static Item.type type = type.Medical;

    public AdvFirstAidKit() : base(id, type)
    {
    }

    public override void ability1(Entity target)
    {
        Instantiaion.player.setHealth(Instantiaion.player.getHealth() + 50);
    }

    public override string getNameAbility1()
    {
        return "Adv. First Aid Kit";
    }

    public override void ability2(Entity target)
    {

    }

    public override string getNameAbility2()
    {
        return null;
    }
}