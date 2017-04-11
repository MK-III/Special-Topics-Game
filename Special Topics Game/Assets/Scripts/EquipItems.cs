using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EquipItems : MonoBehaviour {

	public Text eqpdWeapon;
    public Text eqpdAssist;
    public Text eqpdHealth;
    public Dropdown eqpDropdown;
    public Dropdown healthDropdown;
    public Button fists;
    public Button revolver;
    public Button plasmaPistol;
    public Button saber;
    public Button repeatingRifle;
    public Button laserRifle;
    public Button lazerSaber;
    public Button gattlinGun;
    // Use this for initialization
    void Start () {
        fists.interactable = false;
        revolver.interactable = false;
        plasmaPistol.interactable = false;
        saber.interactable = false;
        repeatingRifle.interactable = false;
        laserRifle.interactable = false;
        lazerSaber.interactable = false;
        gattlinGun.interactable = false;
        healthDropdown.onValueChanged.AddListener(delegate {
            myDropdownValueChangedHandler(healthDropdown);
        });
        eqpDropdown.onValueChanged.AddListener(delegate {
            myDropdownValueChangedHandler(eqpDropdown);
        });
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        eqpdWeapon.text = Instantiaion.player.eqp[0].name;
        eqpdAssist.text = Instantiaion.player.eqp[1].name;
        eqpdHealth.text = Instantiaion.player.eqp[2].name;
        if (Instantiaion.player.inv[0] == true)
        {
            fists.interactable = true;
        }
        if (Instantiaion.player.inv[1] == true)
        {
            revolver.interactable = true;
        }
        if (Instantiaion.player.inv[2] == true)
        {
            plasmaPistol.interactable = true;
        }
        if (Instantiaion.player.inv[7] == true)
        {
            saber.interactable = true;
        }
        if (Instantiaion.player.inv[6] == true)
        {
            repeatingRifle.interactable = true;
        }
        if (Instantiaion.player.inv[3] == true)
        {
            laserRifle.interactable = true;
        }
        if (Instantiaion.player.inv[4] == true)
        {
            lazerSaber.interactable = true;
        }
        if (Instantiaion.player.inv[5] == true)
        {
            gattlinGun.interactable = false;
        }
        }

    void Destroy()
    {
        eqpDropdown.onValueChanged.RemoveAllListeners();
        healthDropdown.onValueChanged.RemoveAllListeners();
    }

    public void myDropdownValueChangedHandler(Dropdown target)
    {
        Debug.Log("selected: " + target.value);
        if (target == eqpDropdown)
        {
            Debug.Log("eqp");
            switch (target.value)
            {
                case 0:
                    Instantiaion.player.EquipItem(new Dynamite());
                    break;
                case 1:
                    Instantiaion.player.EquipItem(new Sheild());
                    break;
                case 2:
                    Instantiaion.player.EquipItem(new SmokeBomb());
                    break;
                case 3:
                    Instantiaion.player.EquipItem(new FlashBang());
                    break;
            }
        }
        else
        {
            Debug.Log("Health");
            switch (target.value)
            {
                case 0:
                    Instantiaion.player.EquipItem(new FirstAidKit());
                    Resources.Load<Sprite>("Assests/Sprites/Dynamite");
                    break;
                case 1:
                    Instantiaion.player.EquipItem(new AdvFirstAidKit());
                    break;
                case 2:
                    Instantiaion.player.EquipItem(new NanoBots());
                    break;
                case 3:
                    Instantiaion.player.EquipItem(new Moonshine());
                    break;
                case 4:
                    Instantiaion.player.EquipItem(new AlienProbe());
                    break;
                case 5:
                    Instantiaion.player.EquipItem(new Morphine());
                    break;
            }
        }
    }

    public void SetDropdownIndex(int index)
    {
        eqpDropdown.value = index;
    }

    public void ActiveItem()
	{

	}
	public void ActivateFists(){
        Instantiaion.player.EquipItem(new Fists());
	}
	public void ActivateRevolver(){
		Instantiaion.player.EquipItem(new Revolver());
	}
	public void ActivatePlasmaPistol(){
		Instantiaion.player.EquipItem(new PlasmaPistol());
	}
	public void ActivateLaserRifle(){
		Instantiaion.player.EquipItem(new LaserRifle());
	}
	public void ActivateLazerSaber(){
		Instantiaion.player.EquipItem(new LazerSaber());
	}
	public void ActivateGattlinGun(){
		Instantiaion.player.EquipItem(new GattlinGun());
	}
	public void ActivateRepeatingRifle(){
		Instantiaion.player.EquipItem(new RepeatingRifle());
	}
	public void ActivateSaber(){
		Instantiaion.player.EquipItem(new Saber());
	}

}
