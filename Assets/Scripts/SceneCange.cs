using UnityEngine;
using System.Collections;

public class SceneCange : MonoBehaviour {

	// Use this for initialization
public void ChangeToScene (int sceneToChangeTo){

		Application.LoadLevel(sceneToChangeTo);

	}
}
