using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	// Use this for initialization

	
	// Update is called once per frame


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("fire")) {
			
			this.gameObject.SetActive (false);
		
		}
}
}
