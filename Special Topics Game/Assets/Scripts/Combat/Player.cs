using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity{

    /* Slot 1 - Weapon
     * Slot 2 - Assist
     * Slot 3 - Medical*/

    private Item[] eqp = new Item[3];
    private static ArrayList inv = new ArrayList();

    private int health = 100;
    private int addDefense;
    private int addAttack;

    public Player(){
        eqp = new Item[] { null, null, null };
    }

    //Abilities
    public void WeaponAbility1(Entity target){
        eqp[0].ability1(target);
    }

    public void WeaponAbility2(Entity target){
        eqp[0].ability2(target);
    }

    public void AssistAbility(Entity target){
        eqp[1].ability1(target);
    }

    public void MedicalAbility(Entity target){
        eqp[2].ability1(target);
    }

    public string GetNameWeaponAbility1(){
        if (eqp[0] == null)
            return "";
        return eqp[0].getNameAbility1();
    }

    public string GetNameWeaponAbility2(){
        if (eqp[0] == null)
            return "";
        return eqp[0].getNameAbility2();
    }

    public string GetNameAssistAbility(){
        if (eqp[1] == null)
            return "";
        return eqp[1].getNameAbility1();
    }

    public string GetNameMedicalAbility(){
        if (eqp[2] == null)
            return "";
        return eqp[2].getNameAbility1();
    }

    //Statistics Methods
    public int getHealth(){
        return health;
    }

    public int getDefense(){
        return addDefense;
    }

    public int getAttack(){
        return addAttack;
    }

    public void setHealth(int val){
        health = val;
    }

    public override void doDamage(int damage){
        health -= damage;
    }

    //Overriden entity methods
    public override void ability1(Entity target)
    {
        WeaponAbility1(target);
    }

    public override void ability2(Entity target)
    {
        WeaponAbility2(target);
    }

    public override void ability3(Entity target)
    {
        AssistAbility(target);
    }

    public override void ability4(Entity target)
    {
        MedicalAbility(target);
    }

    public override string getAbility1Name()
    {
        return GetNameWeaponAbility1();
    }

    public override string getAbility2Name()
    {
        return GetNameWeaponAbility2();
    }

    public override string getAbility3Name()
    {
        return GetNameAssistAbility();
    }

    public override string getAbility4Name()
    {
        return GetNameMedicalAbility();
    }

    //Equipment
    public void EquipItem(Item item){
        switch (item.GetItemType()){
            case Item.type.Weapon:
                EquipWeapon(item);
                break;
            case Item.type.Assist:
                EquipWeapon(item);
                break;
            case Item.type.Medical:
                EquipWeapon(item);
                break;
        }
    }

    private void EquipWeapon(Item item){
        eqp[0] = item;
    }

    private void EquipAssist(Item item){
        eqp[1] = item;
    }

    private void EquipMedical(Item item){
        eqp[2] = item;
    }
}
