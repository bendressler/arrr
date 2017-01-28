using UnityEngine;
using System.Collections;

public class Slot : MonoBehaviour {

	public bool filled;
	public Sprite sprFilled;
	public Sprite sprEmpty;
	int pirates;
	int slots;

	// Use this for initialization
	void Start () {
		int pirates = GetComponentInParent<Cannon> ().currentPirates;
		int slots = GetComponentInParent<Cannon> ().slots;
		Debug.Log ("parent slots" + GetComponentInParent<Cannon> ().slots);
		Debug.Log ("slots" + slots);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("parent slots" + GetComponentInParent<Cannon> ().slots);
		Debug.Log ("slots" + slots);
	}

	void OnMouseDown(){
		Debug.Log ("pirates" + pirates);
		Debug.Log ("slots" + slots);
		if (filled) {
			Debug.Log ("Removing a pirate");
			filled = false;
			GetComponentInChildren<SpriteRenderer> ().sprite = sprEmpty;
			pirates--;

		} else {
			if (pirates < slots) {
				Debug.Log ("Adding a pirate");
				filled = true;
				GetComponentInChildren<SpriteRenderer> ().sprite = sprFilled;
				pirates++;
			}
		}
	}





}
