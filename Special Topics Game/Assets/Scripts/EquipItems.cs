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
    // Use this for initialization
    void Start () {
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
	}

    void Destroy()
    {
        eqpDropdown.onValueChanged.RemoveAllListeners();
        healthDropdown.onValueChanged.RemoveAllListeners();
    }

    private void myDropdownValueChangedHandler(Dropdown target)
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
