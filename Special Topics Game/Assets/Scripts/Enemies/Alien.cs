﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Alien : Enemy {

    public static int health = 50;
    public static int defense = 20;
    public static int attack = 20;

    public Alien() : base(health, defense, attack){
    }

    public override int getUsedAbility(){
        return 1;
    }

    public override void ability1(Entity target){
        target.doDamage(20);
    }
    public override void ability2(Entity target){
       
    }
    public override void ability3(Entity target){

    }
    public override void ability4(Entity target){

    }

    public override string getAbility1Name(){
        return "Laser Beam";
    }
    public override string getAbility2Name(){
        return "Claw";
    }
    public override string getAbility3Name(){
        return null;
    }
    public override string getAbility4Name(){
        return null;
    }


}
