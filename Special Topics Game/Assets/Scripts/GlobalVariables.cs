using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables{
    public static bool inCombat = false;
    public static int health = 50;
    public static int PAttack = 0;
    public static int PDefense = 25;
    public static int PDamage = 0;
    public static readonly int PATTACK = 0;
    public static readonly int PDEFENSE = 25;
    public static readonly int PDAMAGE = 0;
    public static int turn;
    public static ArrayList inv = new ArrayList();
    public static Item[] eqp = new Item[5];
    public static string enemyName;


}
