using UnityEngine;
using System.Collections;

public class FCamera : MonoBehaviour {

	public static FCamera s; //singleton instance of this case
	public GameObject poi;
	private float camZ;



	public float ease = 0.05f;

	Vector2 minXY;

	void Awake() {

		s = this; 
		camZ = transform.position.z;

	}

	void Update () {



		//check if poi is empty
		if (poi == null){

			return;
			}

		Vector3 destination = Vector3.Lerp (transform.position, poi.transform.position , ease);

		destination.x = Mathf.Max (minXY.x, destination.x ); 
		destination.y = Mathf.Max (minXY.y, destination.y ); 

		destination = Vector3.Lerp(transform.position , destination , ease);

		destination.z = camZ;

		transform.position = destination;

		this.GetComponent<Camera>().orthographicSize = 10 + destination.y;
	}


}
