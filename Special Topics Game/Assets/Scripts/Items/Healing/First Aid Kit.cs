using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : Item {

    public static short id = 13;
    public static string name = "First Aid Kit";
    public static Item.type type = type.Medical;

    public FirstAidKit() : base(id, type, name)
    {
    }

    public override void ability1(Entity target)
    {
        Instantiaion.player.heal(25);
    }

    public override string getNameAbility1()
    {
        return "First Aid Kit";
    }

    public override void ability2(Entity target)
    {

    }

    public override string getNameAbility2()
    {
        return null;
    }
}

