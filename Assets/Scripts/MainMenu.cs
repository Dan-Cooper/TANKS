using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject StartButton;
	public GameObject ExitButton;

	public void StartOnUp(string levle)
	{
		Debug.Log ("S UP");
		SceneManager.LoadScene(levle,LoadSceneMode.Single);
	}

	public void ExitOnUp( ){
		Debug.Log ("S UP");
		Application.Quit ();

	}
}
