using UnityEngine;
using System.Collections;




public class Goal : MonoBehaviour {

	public static bool goalMet = false;




	// Static Field accessible from anywhere

	// Storing if teh goal was met

	//OnTriggerEnter

	void OnTriggerEnter(Collider other) {

	

			if (other.gameObject.CompareTag ("projektil")) {
				
			goalMet = true;

			//Set the static field to true 

			Color c = this.gameObject.GetComponent<Renderer>().material.color;

			c.a = 1;


			this.gameObject.GetComponent<Renderer>().material.color = c;
			// set the alpha of the colour to a higher opacity
			}

	}

}


