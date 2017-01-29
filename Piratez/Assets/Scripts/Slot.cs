using UnityEngine;
using System.Collections;

public class Slot : MonoBehaviour {

	public GameObject gameManager;
	public bool filled;
	public Sprite sprFilled;
	public Sprite sprEmpty;
	int pirates;
	int slots;

	// Use this for initialization
	void Start () {
		//get number of active pirates and slots from parent structure
		pirates = GetComponentInParent<Structure> ().currentPirates;
		slots = GetComponentInParent<Structure> ().slots;

		gameManager = GameObject.FindWithTag("GameController");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//if clicked and filled, remove pirate and add it to the parents available pirates
	void OnMouseDown(){
		pirates = GetComponentInParent<Structure> ().currentPirates;
		if (filled) {
			filled = false;
			GetComponentInChildren<SpriteRenderer> ().sprite = sprEmpty;
			pirates-=1;
			gameManager.GetComponent<GameManager> ().freePirates += 1;

		} else {
			//if clicked and empty, add a pirate and remove from parents available pirates
			if ((pirates < slots) && (gameManager.GetComponent<GameManager> ().freePirates > 0))
			 {
				Debug.Log ("Adding a pirate");
				filled = true;
				GetComponentInChildren<SpriteRenderer> ().sprite = sprFilled;
				pirates+=1;
				gameManager.GetComponent<GameManager> ().freePirates -= 1;
			}
		}
		//update parents active pirates
		GetComponentInParent<Structure> ().currentPirates = pirates;
	}





}
