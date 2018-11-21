using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class PlayerData  {
    public int health;
    public int experiance;
	// Use this for initialization
	public PlayerData () {
        health = 100;
        experiance = 0;
    }

}
