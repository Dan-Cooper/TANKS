using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32;
using UnityEngine;



public class ShotControle : MonoBehaviour
{

	//private int power;
	//private int angle;
	public GameObject boom;
	
    
	// Use this for initialization
	void Start ()
	{
		
		//power = ;
		//angle = GameObject.Find("TANK").GetComponent<FireControle>().Angle;
		//this.GetComponent<Transform>().eulerAngles = new Vector3(0,0,angle);
		Debug.Log(GameObject.Find("Main").GetComponent<Game>().GtGlobalFromLocal());
		this.GetComponent<Rigidbody> ().velocity = GameObject.Find("Main").GetComponent<Game>().GtGlobalFromLocal();
			//GameObject.Find("Main").GetComponent<Game>().GtGlobalFromLocal();
		//= new Vector3 (0, 50, 0);
		//Debug.Log(power);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag.Equals("Ground") || other.gameObject.tag.Equals("Tank"))
		{
			Instantiate(boom, this.GetComponent<Transform>().position, this.GetComponent<Transform>().rotation);
			Destroy(this.gameObject);
		}
	}

}
