using UnityEngine;
using System.Collections;




public class Goal : MonoBehaviour {

	public static bool goalMet = false;




	void OnCollisionEnter(Collision other) {

	

		if (other.gameObject.CompareTag ("projektil")||other.gameObject.CompareTag ("fire")) {
				


			this.gameObject.SetActive (false);


			}

		if (GameObject.FindWithTag("enemy") == null) {

			Debug.Log("keine feinde mehr");
			goalMet = true;

		}

	}

}


