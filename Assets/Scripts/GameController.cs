using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum GameState {

	idle,
	playing,
	levelEnd

	}

public class GameController : MonoBehaviour {



	public static GameController S ; 

	public GameObject[] castles;

	public Text gtLevel;
	public Text gtScore;

	public Vector3 castlePos;

    public int level;
	public int levelMax;
	public int shotsTaken;

	public GameObject castle;

	public GameState state = GameState.idle; 
	 
	public string showing =  "Slingshot";

	void Start(){

		S = this;
		level = 0;
		levelMax = castles.Length;
		StartLevel();

	}



	void StartLevel() {

		if(castle != null) {
			Destroy (castle);
		}

		GameObject[] projectiles = GameObject.FindGameObjectsWithTag("projektil");
		foreach(GameObject p in projectiles){
			Destroy(p);
		}

		castle = Instantiate (castles[level]) as GameObject;
		castle.transform.position = castlePos;
		shotsTaken = 0;
		



		SwitchView("Both");
		ProjectileTrail.S.Clear();

		Goal.goalMet = false;
		UpdateGT();
		
		state = GameState.playing;
		
	}


	void UpdateGT() {

	gtLevel.text = "Level:" + (level+1) + " of " + levelMax;
	gtScore.text = "Shots Taken:" + shotsTaken;

	}

	void Update(){

		UpdateGT();
		if(state == GameState.playing && Goal.goalMet) {

			if(FCamera.S.poi.tag == "projektil" &&  FCamera.S.poi.GetComponent<Rigidbody>().IsSleeping()) {


					state = GameState.levelEnd;
				SwitchView("Both");
				Invoke("NextLevel",2f);
			}
		}
	}

	void NextLevel(){
		level++;
		if(level == levelMax) {
			Application.LoadLevel (0);
		}
		StartLevel();
	}


	public void SwitchView(string view) {
		S.showing = view;
		switch(S.showing){
		case "Slingshot":
			FCamera.S.poi = null;
			break;
		case "Castle":
			FCamera.S.poi = S.castle;
			break;
		case "Both":
			FCamera.S.poi = GameObject.Find ("ViewBoth");
			break;
		}
	}
	public static void ShotFired(){
		S.shotsTaken++;
	}


}
