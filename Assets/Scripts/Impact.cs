using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Impact : MonoBehaviour
{

	private Collider[] cols;
	//public GameObject boom;

	private void Start()
	{
		cols = Physics.OverlapSphere(GetComponent<Transform>().position, 5);
		Debug.Log ("HIT " + cols.Length+ " Things");
		foreach (var col in cols)
		{
			Debug.Log ("Loop "+ col.gameObject.tag);
			if (col.gameObject.tag.Equals("Tank"))
			{
				float prox = (this.GetComponent<Transform>().position - col.gameObject.GetComponent<Transform>().position)
					.magnitude;
				float effect = 1 - (prox / 10);
				
				Debug.DrawLine (GetComponent<Transform> ().position, (col.gameObject.GetComponent<Transform>().position), Color.red,1000000000000000000f);
				Debug.Log ("Loop: "+effect);
				col.gameObject.GetComponent<TankInfo>().ModHelth(-1*(100* effect));

			}
		}
		Debug.DrawLine (GetComponent<Transform> ().position, (GetComponent<Transform> ().position + new Vector3(2,2,0)), Color.red, 10000000000000000f);
		//Debug.Log ("RUN");
		Destroy (this.gameObject);
	}


}
