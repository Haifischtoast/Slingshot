using UnityEngine;
using System.Collections;

public class FCamera : MonoBehaviour {

	public static FCamera S; //singleton instance of this case
	public GameObject poi;
	private float camZ;


	public float ease = 0.05f;

	public Vector2 minXY;

	void Awake() {

		S = this; 
		camZ = this.transform.position.z;

	}

	void FixedUpdate () {
 
	
		Vector3 destination;

		//check if poi is empty
		if (poi == null){
			//Set destination to zero-Vector
			destination = Vector3.zero;

		}

		else {
			 destination = poi.transform.position;

			if (poi.tag == "projektil"){
				if ( poi.GetComponent<Rigidbody>().IsSleeping()){

					poi = null;
					return;
			}
			}
			

		}

	 

		



		destination.x = Mathf.Max (minXY.x, destination.x ); 
		destination.y = Mathf.Max (minXY.y, destination.y ); 

		destination = Vector3.Lerp(transform.position , destination , ease);

		destination.z = camZ;

		transform.position = destination;

		this.GetComponent<Camera>().orthographicSize = 10 + destination.y;
	}


}


