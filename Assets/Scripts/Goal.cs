using UnityEngine;
using System.Collections;




public class Goal : MonoBehaviour {

	public static bool goalMet = false;




	// Static Field accessible from anywhere

	// Storing if teh goal was met

	//OnTriggerEnter

	void OnTriggerEnter(Collider other) {

	

		if (other.gameObject.CompareTag ("projektil")||other.gameObject.CompareTag ("fire")) {
				
			goalMet = true;

			this.gameObject.SetActive (false);


			}

	}

}


