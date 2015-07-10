using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {
	// public

	public GameObject prefabProjectile;
	public float velocityMult = 10.0f;


	//privat

	private GameObject launchPoint;
	private bool aimingMode;
	private Vector3 launchPos;
	private GameObject projectile;

	void Awake() {
		Transform launchPointTrans = transform.Find("LaunchPoint");
		launchPoint = launchPointTrans.gameObject;
		launchPoint.SetActive(false);
		launchPos = launchPoint.transform.position;
	}

	void OnMouseEnter() {
		print ("jo");
		launchPoint.SetActive(true);
	}

	void OnMouseExit() {
		print ("no");
		launchPoint.SetActive(false);
	}

	void OnMouseDown() {
		// Set the game to aiming mode
		aimingMode = true;

		//instanciate a projectile
		projectile = Instantiate(prefabProjectile) as GameObject;


		//Position the projectile at the launchPoint
		projectile.transform.position = launchPos;

		// disusable kinematic physics for now

		projectile.GetComponent<Rigidbody>().isKinematic = true;

	
	}

	void Update() {
		// Check aimingmode
		if (!aimingMode)return;

		// MousePos in 3dspace 
		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = -Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

		// delta between mouse & launch pos.
		Vector3 mouseDelta = mousePos3D - launchPos;
		// set projectile to new pos und beschränk it auf shperecollider
		float maxMagnitude = this.GetComponent<SphereCollider>().radius;
		mouseDelta = Vector3.ClampMagnitude(mouseDelta, maxMagnitude);
		Vector3 projPos = launchPos + mouseDelta;
		projectile.transform.position = projPos;
		// check mouse button released
		// fire
		if (Input.GetMouseButtonUp(0)){
			aimingMode = false;
			projectile.GetComponent<Rigidbody>().isKinematic = false;
			projectile.GetComponent<Rigidbody>().velocity = -mouseDelta * velocityMult;
			FCamera.S.poi = projectile;
			projectile = null;
		}



	}


}