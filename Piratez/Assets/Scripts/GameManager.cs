using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject boardManager;

	//variables for fake enemy ship
	public GameObject enemyLifeBar;
	public float enemyLife;
	public float shotFrequency;
	public float timer;

	//variables for pirate resource
	public GameObject skullUI;
	public GameObject[] pirateUI;
	public int totalPirates;
	public int freePirates;
	public Sprite freePirate;
	public Sprite busyPirate;


	// Use this for initialization
	void Start () {
		//set resource values
		totalPirates = 5;
		freePirates = 5;

		//set resource UI
		pirateUI = new GameObject[totalPirates];
		UISetup ();

		//set fake ship
		enemyLife = enemyLifeBar.gameObject.transform.localScale.y;
		shotFrequency = 0.3f;
		timer = Time.time + shotFrequency;

		//set board
		boardManager.GetComponent<BoardManager> ().BoardSetup();

	}
	
	// Update is called once per frame
	void Update () {

		//update length of enemy ships life bar
		enemyLifeBar.gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x,enemyLife,gameObject.transform.localScale.z);

		//timer that triggers one of the deck tiles to get shot at
		if (timer <= Time.time) {
			boardManager.GetComponent<BoardManager> ().ShootTile();
			timer = Time.time + shotFrequency;
		}

		//go through pirate resource indicators and change according to how many busy pirates there are
		for (int i = 0; i < freePirates; i++) {
			pirateUI [i].GetComponentInChildren<SpriteRenderer> ().sprite = freePirate;
		}
		for (int i = freePirates; i < totalPirates; i++) {
			pirateUI [i].GetComponentInChildren<SpriteRenderer> ().sprite = busyPirate;
		}
	}

	//function that reduces enemy life by a damage value
	public void ShootEnemy(float damage){
		enemyLife -= damage;
	}

	//set up pirate resource indicator
	void UISetup(){
		for (int i = 0; i < totalPirates; i++) {
			GameObject newSkull = Instantiate (skullUI, new Vector3 (-0.7f, 1, 0.5f + i), Quaternion.identity) as GameObject;
			pirateUI [i] = newSkull;
		}
	}



}
