using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class Game : MonoBehaviour
{
	public GameObject[] Tanks; //L to R 0-3
	private int turn;
	private bool f;
	private int dead;
	
	//OLD UI
	public Text PowerTxt;
	public Text AngleTxt;
	public Text HealthTxt;
	
	//NEW UI
	public Slider PowerSlider;
	public GameObject AngleControler;

	public GameObject Camera;
	
	
	// Use this for initialization
	void Start ()
	{
		f = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		TurnOrder();
		
		//BEGIN POWER Controle OLD
		if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && Int32.Parse(PowerTxt.text) < 100)
		{
			PowerTxt.text = "" + (Int32.Parse(PowerTxt.text) + 1); 
			PowerSlider.normalizedValue = ((float)Int32.Parse(PowerTxt.text) + 1)/100;
			//Debug.Log(PowerSlider.normalizedValue +" PowerSlider num");
			//Tanks[turn].GetComponent<FireControle>().Power = Int32.Parse(PowerTxt.text);
			Tanks[turn].GetComponent<FireControle>().SetPower(Int32.Parse(PowerTxt.text));
		}
		if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && Int32.Parse(PowerTxt.text) > 0 )
		{
			PowerTxt.text = "" + (Int32.Parse(PowerTxt.text) - 1);
			PowerSlider.normalizedValue = ((float)Int32.Parse(PowerTxt.text) - 1)/100;
			//Tanks[turn].GetComponent<FireControle>().Power = Int32.Parse(PowerTxt.text);
			Tanks[turn].GetComponent<FireControle>().SetPower(Int32.Parse(PowerTxt.text));
		}
		//BEGIN ANGLE Controle OLD
		if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && Int32.Parse(AngleTxt.text) < 180)
		{
			AngleTxt.text = "" + (Int32.Parse(AngleTxt.text) + 1);
			AngleControler.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, Int32.Parse(AngleTxt.text));
			//Tanks[turn].GetComponent<FireControle>().Angle = -1*Int32.Parse(AngleTxt.text);
			Tanks[turn].GetComponent<FireControle>().SetAngle(Int32.Parse(AngleTxt.text));
			
		}
		if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && Int32.Parse(AngleTxt.text) > 0)
		{
			AngleControler.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, Int32.Parse(AngleTxt.text));
			AngleTxt.text = "" + (Int32.Parse(AngleTxt.text) - 1);
			Tanks[turn].GetComponent<FireControle>().SetAngle(Int32.Parse(AngleTxt.text));
		}
		
	}

	void TurnOrder()
	{
		if (f == true)
		{
			Tanks[0].GetComponent<FireControle>().IsTurn = true;
			f = false;
			Camera.GetComponent<CameraControle>().LatchGameObject(Tanks[turn]);
			HealthTxt.text = ""+ Tanks[0].GetComponentInChildren<TankInfo>().health;
		}
		else if (Input.GetKeyDown(KeyCode.Return) && turn < 3 && Tanks[turn].GetComponentInChildren<TankInfo>().GetHealth()>=0)
		{
			Tanks[turn].GetComponent<FireControle>().IsTurn = false;
			turn++;
			GetLast();
			Camera.GetComponent<CameraControle>().LatchGameObject(Tanks[turn]);
			Tanks[turn].GetComponent<FireControle>().IsTurn = true;
			Tanks[turn].GetComponent<FireControle>().hasFired = false;
			//Debug.Log("HealthReal"+ Tanks[turn].GetComponentInChildren<TankInfo>().health + " TURN " + turn);
			HealthTxt.text = ""+ Tanks[turn].GetComponentInChildren<TankInfo>().health;
		}
		else if (Input.GetKeyDown(KeyCode.Return) && turn == 3 && Tanks[turn].GetComponentInChildren<TankInfo>().GetHealth() >= 0)
		{
			Tanks[turn].GetComponent<FireControle>().IsTurn = false;
			turn = 0;
			GetLast();
			Camera.GetComponent<CameraControle>().LatchGameObject(Tanks[turn]);
			Tanks[turn].GetComponent<FireControle>().IsTurn = true;
			Tanks[turn].GetComponent<FireControle>().hasFired = false;
			HealthTxt.text = "" + Tanks[turn].GetComponentInChildren<TankInfo>().health;
		}
		else if (Input.GetKeyDown(KeyCode.Return) && turn < 3 && Tanks[turn].GetComponentInChildren<TankInfo>().GetHealth()<=0)
		{
			Tanks[turn].GetComponent<FireControle>().IsTurn = false;
			turn++;
			GetLast();
			Camera.GetComponent<CameraControle>().LatchGameObject(Tanks[turn]);
			Tanks[turn].GetComponent<FireControle>().IsTurn = true;
			Tanks [turn].GetComponent<FireControle> ().hasFired = false;
			HealthTxt.text = ""+ Tanks[turn].GetComponentInChildren<TankInfo>().health;
		}
		else if (Input.GetKeyDown(KeyCode.Return) && turn == 3 && Tanks[3].GetComponentInChildren<TankInfo>().GetHealth() <= 0)
		{
			Tanks[turn].GetComponent<FireControle>().IsTurn = false;
			turn = 0;
			GetLast();
			Camera.GetComponent<CameraControle>().LatchGameObject(Tanks[turn]);
			Tanks[turn].GetComponent<FireControle>().IsTurn = true;
			Tanks[turn].GetComponent<FireControle>().hasFired = false;
			HealthTxt.text = "" + Tanks[turn].GetComponentInChildren<TankInfo>().health;
		}
		else
		{
			//SceneManager.LoadScene("MainMenu",LoadSceneMode.Single);
		}
		HealthTxt.text = "" + Tanks[turn].GetComponentInChildren<TankInfo>().health;
		if(Tanks[turn].GetComponentInChildren<TankInfo>().health <=0)
		{
			Tanks [turn].GetComponentInChildren<FireControle> ().SetDead (true);
		}
		HealthTxt.text = ""+ Tanks[turn].GetComponentInChildren<TankInfo>().health;
	}

	public void UIControle()
	{
		//BEGIN POWER Controle
		if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && Int32.Parse(PowerTxt.text) < 100)
		{
			
			PowerTxt.text = "" + (Int32.Parse(PowerTxt.text) + 1);
			//Tanks[turn].GetComponent<FireControle>().Power = Int32.Parse(PowerTxt.text);
			Tanks[turn].GetComponent<FireControle>().SetPower(Int32.Parse(PowerTxt.text));
		}
		if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && Int32.Parse(PowerTxt.text) > 0 )
		{
			PowerTxt.text = "" + (Int32.Parse(PowerTxt.text) - 1);
			//Tanks[turn].GetComponent<FireControle>().Power = Int32.Parse(PowerTxt.text);
			Tanks[turn].GetComponent<FireControle>().SetPower(Int32.Parse(PowerTxt.text));
		}
		//BEGIN ANGLE Controle OLD
		if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && Int32.Parse(AngleTxt.text) < 180)
		{
			AngleTxt.text = "" + (Int32.Parse(AngleTxt.text) + 1);
			//Tanks[turn].GetComponent<FireControle>().Angle = -1*Int32.Parse(AngleTxt.text);
			Tanks[turn].GetComponent<FireControle>().SetAngle(Int32.Parse(AngleTxt.text));
			
		}
		if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && Int32.Parse(AngleTxt.text) > 0)
		{
			AngleTxt.text = "" + (Int32.Parse(AngleTxt.text) - 1);
			Tanks[turn].GetComponent<FireControle>().SetAngle(Int32.Parse(AngleTxt.text));
		}
	}

	public void GetLast()
	{
		PowerTxt.text = "" + Tanks[turn].GetComponent<FireControle>().Power;
		AngleTxt.text = "" + Tanks[turn].GetComponent<FireControle>().Angle;
	}
	
	public GameObject GetBarrleControl()
	{
		return Tanks[turn].GetComponent<FireControle>().BarrleControle;
	}

//Depending on tank pre fab change locVel.x to locVel.z
	public Vector3 GtGlobalFromLocal()
	{
		GameObject other = GetBarrleControl();
		var locVel = other.GetComponent<Transform>().InverseTransformDirection(other.GetComponent<Rigidbody>().velocity);//other.GetComponent<Rigidbody>().velocity
		locVel.x *= -1;
		locVel.z = Tanks[turn].GetComponent<FireControle>().Power;
		Debug.Log(other.GetComponent<Transform>().TransformDirection(locVel)+"GFL");
		return other.GetComponent<Transform>().TransformDirection(locVel);
		//Vector3 t = Tanks [turn].GetComponent<FireControle> ().GetGlobalFromLocal();
		//return t;
	}
}
