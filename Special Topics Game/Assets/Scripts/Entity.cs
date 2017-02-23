﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity {

    public abstract void ability1(Entity target);
    public abstract void ability2(Entity target);
    public abstract void ability3(Entity target);
    public abstract void ability4(Entity target);

    public abstract string getAbility1Name();
    public abstract string getAbility2Name();
    public abstract string getAbility3Name();
    public abstract string getAbility4Name();

    public abstract void doDamage(int damage);

    public abstract int getDefense();
}
