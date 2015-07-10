using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileTrail : MonoBehaviour {

	public static ProjectileTrail S;

	public float minDist = 0.1f;

	private LineRenderer line;
	private int pointsCount;
	private GameObject _poi;
	private Vector3 lastPoint;




	void Awake() {

		S = this;         // S = ProjectileTrail trailobject in hieracy

		//store the linerenderer component in a field 
		line = this.GetComponent<LineRenderer>();
		

		Color c1 = Color.yellow;
		Color c2 = Color.red;
		line.SetColors(c1,c2);
		pointsCount = 0;

		line.enabled = false;
	}

	
	public GameObject poi {
		get {
			
			return _poi;
		}
		
		set {
			
			
			_poi = value;
			
			if(_poi != null){
				line.enabled = false;
				pointsCount = 0;
				line.SetVertexCount(0); 
				
				
			}
			
		}
		
	}

	void FixedUpdate() {

		if(poi == null){
			if(FCamera.S.poi != null){
				if(FCamera.S.poi.tag == "projektil"){
					poi = FCamera.S.poi;
					
				}
				
				else {
					return;
				}
			}
			
			else {
				return;
			}
			
		}

		AddPoint();
		if(poi.GetComponent<Rigidbody>().IsSleeping()){

			poi = null;
		}
	}




	void AddPoint () {

		// if the point we want to add isnt far enough from the last one , do nothing
		Vector3 pt = _poi.transform.position;
		if(pointsCount > 0 && (pt - lastPoint).magnitude < minDist) {

			return;

		}

		if (pointsCount == 0) {

			line.SetVertexCount(1);
			line.SetPosition(0, pt);
			pointsCount += 1;
			line.enabled = true;

		}  else {

			pointsCount++;
			line.SetVertexCount(pointsCount);
			line.SetPosition(pointsCount -1, pt);
	
		}

		lastPoint = pt;

	}

	public void Clear() {
		_poi = null;
		line.enabled = false;
		pointsCount = 0;
		line.SetVertexCount(0);

	}
		// if we are dealing with the first launchpoint


		// else , not the first point




	}
