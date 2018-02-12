using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankInfo : MonoBehaviour {

	public float health;
	// Use this for initialization
	void Start ()
	{
		//health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.deltaTime > 1)
			Debug.Log (health);
		
	}

	public float ModHelth(float val)
	{
		if (val >= 0) return health;
		float hold = health;
		health += val;
		Debug.Log(hold+=val);
		health = (float)Math.Round(health);

		return health;
	}

	public float GetHealth()
	{
		return health;
	}
}
