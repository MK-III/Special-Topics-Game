using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity{

    /* Slot 1 - Weapon
     * Slot 2 - Assist
     * Slot 3 - Medical*/

    public Item[] eqp = new Item[3];
    public bool[] inv = new bool[8];

    //Item IDs need -7 subtracted from them to refrence this array
    public int[] consumables = new int[14];

	public readonly int DEFENSE = 25;
	public readonly int ATTACK = 0;
	public readonly int DAMAGE = 0;
    public readonly int HEALTH = 100;
    private int health = 100;
    public int Defense = 0;
	public int Attack = 0;
	public int Damage = 0;
    public int usedAbility = 0;

    public Player(){
        eqp = new Item[] { new Fists(), null, null };
    }
    public void discoverItem(Item item)
    {
        //If it's a consumable
        if(item.GetItemType() == Item.type.Medical || item.GetItemType() == Item.type.Assist)
        {
            consumables[item.id - 7] += 1;
        }
        else
        {
            inv[item.id] = true;
        }
    }

    public void consumeItem(Item item)
    {
        if (item.GetItemType() == Item.type.Medical || item.GetItemType() == Item.type.Assist)
            consumables[item.id - 7] -= 1;
    }

    public override void setAttack(int value)
    {
        Attack= value;
    }

    public override void setDefense(int value)
    {
        Defense = value;
    }

    public override void setDamage(int value)
    {
        Damage = value;
    }

    public override int getAttack()
    {
        return Attack;
    }

    public override int getDamage()
    {
        return Damage;
    }

    public override int getDefense()
    {
        return Defense;
    }

    public override void changeTarget(Entity target)
    {
        throw new NotImplementedException();
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

    public int getUsedAbility()
    {
        return usedAbility;
    }

    public void setUsedAbility(int num)
    {
        usedAbility = num;
    }
    
    public string getUsedAbilityName()
    {
        string text;
        switch (usedAbility)
        {
            case 1:
                text = Instantiaion.player.GetNameWeaponAbility1();
                break;
            case 2:
                text = Instantiaion.player.GetNameWeaponAbility2();
                break;
            case 3:
                text = Instantiaion.player.GetNameAssistAbility();
                break;
            case 4:
                text = Instantiaion.player.GetNameMedicalAbility();
                break;
            default:
                text = "No Player Ability Used";
                break;
        }
        return text;
    }

    //Statistics Methods
    public int getHealth(){
        return health;
    }

    public void setHealth(int val){
        health = val;
    }

    public override void doDamage(int damage){
		GlobalVariables.pDamageDone = damage;
        health -= damage;
    }
    public override void heal(int hp)
    {
        GlobalVariables.pHealed = hp;
        health += hp;
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
                EquipAssist(item);
                break;
            case Item.type.Medical:
                EquipMedical(item);
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
