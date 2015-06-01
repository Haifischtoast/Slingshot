using UnityEngine;
using System.Collections;

public class Clouds : MonoBehaviour {


	public int numClouds = 40;

	public Vector3 cloudPosMin;
	public Vector3 cloudPosMax;

	public float cloudSpeedMult = 0.5f;

	public float cloudScaleMin = 1.0f;
	public float cloudScaleMax = 5.0f;

	// Internal fields
	private GameObject[] cloudInstances;
	public GameObject[] cloudPrefabs;

	public void Awake () {


		// create an array to hold our cloud instances 

		cloudInstances = new GameObject[numClouds];


		// find the clouds anchor object
		GameObject anchor = GameObject.Find ("Cloudss");

	


		//iterate through array and create each cloud
		GameObject cloud; 
		for (int i = 0; i < numClouds; i++ ) {

		

		// pick a random cloud prefab between 0 and cloudPrefabs.Lenght-1
			int prefabNum = Random.Range(0, cloudPrefabs.Length-1);



		//Instanciate a cloud and position it accordingly
			cloud = Instantiate(cloudPrefabs[prefabNum]);

			Vector3 cPos = Vector3.zero;
			cPos.x = Random.Range(cloudPosMin.x, cloudPosMax.x);
			cPos.y = Random.Range(cloudPosMin.y, cloudPosMax.y);

			float scaleU = Random.value;
			float scaleVal = Mathf.Lerp(cloudScaleMin, cloudScaleMax, scaleU);

			cPos.y = Mathf.Lerp(cloudPosMin.y, cPos.y, scaleU);

			cPos.z = 100 - 90 * scaleU;

			cloud.transform.position = cPos; 
			cloud.transform.localScale = Vector3.one * scaleVal;
		// Add the cloud to our cloud instances 

			cloud.transform.parent = anchor.transform;
			cloudInstances[i] = cloud;


		}
	}
		void Update () {
		// Iterate over all generated clouds
		foreach(GameObject cloud in cloudInstances) {
			// Get cloud scale and position
			Vector3 cPos = cloud.transform.position;
			float scaleValue = cloud.transform.localScale.x;
			
			// Move lager clouds faster
			cPos.x -= scaleValue * Time.deltaTime * cloudSpeedMult;
			
			// If cloud moved too far left, set it back to max
			if(cPos.x < cloudPosMin.x){
				cPos.x = cloudPosMax.x;
			}
			// Apply the new position to the cloud
			cloud.transform.position = cPos;
		}

		}
	
}
