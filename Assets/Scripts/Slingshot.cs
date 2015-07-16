using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Slingshot : MonoBehaviour {
	// public

	public bool fire;

	public GameObject[] prefabProjectile;
	public float velocityMult = 10.0f;
//	public Button normProj;
//	public Button fireProj;
	public AudioSource launchSound;
	//privat




	private GameObject launchPoint;
	private bool aimingMode;
	private Vector3 launchPos;
	private GameObject projectile;

	void Start (){

	//	normProj = normProj.GetComponent<Button>();
	//	fireProj = fireProj.GetComponent<Button>();

	}


	void Awake() {
		Transform launchPointTrans = transform.Find("LaunchPoint");
		launchPoint = launchPointTrans.gameObject;
		launchPoint.SetActive(false);
		launchPos = launchPoint.transform.position;


	}

	void OnMouseEnter() {

		launchPoint.SetActive(true);
	}

	void OnMouseExit() {

		launchPoint.SetActive(false);
		launchSound.Play();

	}

	void OnMouseDown() {
		// Set the game to aiming mode
		aimingMode = true;

		//instanciate a projectile

		if(fire == true ) {
		projectile = Instantiate(prefabProjectile[1]) as GameObject;
			Debug.Log("Feuer");
		}

		else {

			projectile = Instantiate(prefabProjectile[0]) as GameObject;
			Debug.Log("manglaubt es ncihtkein feuer");
		}


		//Position the projectile at the launchPoint
		projectile.transform.position = launchPos;

		// disusable kinematic physics for now

		projectile.GetComponent<Rigidbody>().isKinematic = true;
		GameController.ShotFired();

	
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

	public void ChangeProjectilesF(){
		
		fire = true;

	}

	public void ChangeProjectilesN(){
		
		fire = false;

	}


}