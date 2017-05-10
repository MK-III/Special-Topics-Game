using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiaion : MonoBehaviour {

    public GameObject gameObject;
    public static Player player = new Player();

    // Use this for initialization
    void Awake () {
        player.inv[0] = true;
        DontDestroyOnLoad(gameObject);
        player.discoverItem(new Fists());
        player.discoverItem(new FirstAidKit ());
        player.discoverItem(new Dynamite ());
        player.discoverItem(new PlasmaPistol());
        player.discoverItem(new Saber());
        player.discoverItem(new GattlinGun());
        player.discoverItem(new RepeatingRifle());
        player.discoverItem(new LaserRifle());
        player.discoverItem(new LazerSaber());
        player.discoverItem(new Revolver());

        UnityEngine.Debug.Log(Instantiaion.player.inv[0]);
        UnityEngine.Debug.Log(Instantiaion.player.inv[1]);
        UnityEngine.Debug.Log(Instantiaion.player.inv[2]);
        UnityEngine.Debug.Log(Instantiaion.player.inv[3]);
        UnityEngine.Debug.Log(Instantiaion.player.inv[4]);
        UnityEngine.Debug.Log(Instantiaion.player.inv[5]);
        UnityEngine.Debug.Log(Instantiaion.player.inv[6]);
        UnityEngine.Debug.Log(Instantiaion.player.inv[7]);

    }
}
