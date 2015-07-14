using UnityEngine;
using System.Collections;

public class GotHit : MonoBehaviour {



	void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag ("projektil")||other.gameObject.CompareTag ("fire") ) {
			
			this.gameObject.SetActive (false);

		}
}
}