using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControle : MonoBehaviour
{

	public int Power;
	public int Angle;
	public GameObject Shot;
	public GameObject ShotSpawn;
	public GameObject BarrleControle;

	public bool IsTurn;
	public bool hasFired = false;

	public bool IsDead = false;



	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && IsTurn && !hasFired && !IsDead)
		{
			GameObject s = Instantiate(Shot, ShotSpawn.GetComponent<Transform>().position,
				ShotSpawn.GetComponent<Transform>().rotation);
			GameObject.Find("Main").GetComponent<Game>().Camera.GetComponent<CameraControle>().LatchGameObject(s);
			hasFired = true;
		}
		//Debug.Log(Power);
		//BEGIN ANGLE Controle
		if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && Angle < 180 && IsTurn && !IsDead)
		{
			BarrleControle.GetComponent<Transform>().eulerAngles = new Vector3(-1*Angle, 90, 0);
			ShotSpawn.GetComponent<Transform>().eulerAngles = new Vector3(-1*Angle, 0, 0);

		}
		if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && Angle > 0 && IsTurn && !IsDead)
		{
			BarrleControle.GetComponent<Transform>().eulerAngles = new Vector3(-1*Angle,90,0);
			ShotSpawn.GetComponent<Transform>().eulerAngles = new Vector3(-1*Angle,0,0);
		}
	}

	public void SetDead(bool val)
	{
		IsDead = val;
	}
	
	//Not used look to Game.cs @ line 138
	public Vector3 GetGlobalFromLocal()
	{
		Debug.Log ("GFL");
		GameObject other = BarrleControle;
		var locVel = other.GetComponent<Transform>().InverseTransformDirection(other.GetComponent<Rigidbody>().velocity);
		locVel.x = Power;
		Debug.Log(other.GetComponent<Transform>().TransformDirection(locVel)+ "E5!");
		return other.GetComponent<Transform>().TransformDirection(locVel);
	}

	public void SetAngle(int a)
	{
		Angle = a;
	}

	public void SetPower(int p)
	{
		Power = p;
	}
}
