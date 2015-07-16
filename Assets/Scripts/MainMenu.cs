using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Button startText;
	public Button exitText;
	
	// Use this for initialization
	void Start () {
		
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		
	}
	
	// Update is called once per frame
	public void StartLevel () {
		
		Application.LoadLevel (0);
		
	}
	
	public void ExitGame () {
		
		Application.Quit ();
		
	}
}
