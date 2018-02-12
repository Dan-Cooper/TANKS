using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControle : MonoBehaviour
{

	private GameObject Current;
	private Vector3 offset;
	private Vector3 oGPos;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(Current!=null)
		{
			GetComponent<Transform>().position = Current.GetComponent<Transform>().position + offset;
		}
	}

	public void LatchGameObject(GameObject other)
	{
		Current = other;
		offset =  new Vector3(0, 5, -20); //Current.GetComponent<Transform>().position +
		GetComponent<Transform>().Translate(Current.GetComponent<Transform>().position);
		//Debug.Log("LatchV3: "+ Current.GetComponent<Transform>().position);
		
	}
}
