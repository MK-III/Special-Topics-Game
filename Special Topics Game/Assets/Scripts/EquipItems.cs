using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EquipItems : MonoBehaviour {

	public Text eqpdWeapon;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		eqpdWeapon.text = Instantiaion.player.eqp[0];
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
