using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Winscreen : MonoBehaviour {

	public Button backtomain;

	
	// Use this for initialization
	void Start () {
		
		backtomain = backtomain.GetComponent<Button> ();
	
		
	}
	
	// Update is called once per frame
	public void GoToMain () {
		
		Application.LoadLevel (0);
		
	}
	

}
