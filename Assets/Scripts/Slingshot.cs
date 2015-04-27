using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

	public GameObject launchPoint;

	void Awake() {
		Transform launchPointTrans = transform.Find("LaunchPoint");
		launchPoint = launchPointTrans.gameObject;
		launchPoint.SetActive(false);
	}

	void OnMouseEnter() {
		print ("jo");
		launchPoint.SetActive(true);
	}

	void OnMouseExit() {
		print ("no");
		launchPoint.SetActive(false);
	}
}