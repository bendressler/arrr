using UnityEngine;
using System.Collections;

public class RepairBay : Structure {

	public float timer;
	public float restoreFrequency;
	public GameObject boardManager;

	// Use this for initialization
	void Start () {
		slots = 3;
		minPirates = 1;
		active = false;
		currentPirates = 0;
		restoreFrequency = 10f;
		CreateSlots ();
		timer = Time.time + restoreFrequency;
		boardManager = GameObject.Find("BoardManager");

	}

	// Update is called once per frame
	void Update () {

		//set repair speed
		restoreFrequency = 10f / currentPirates;

		//set to active if there are pirates allocated, inactive if not
		if (currentPirates > 0) {
			active = true;
		}else {
			active = false;
		}

		//set to active and start timer if a pirate is allocated
		if (active == false) {
			if (currentPirates >= minPirates) {
				active = true;
				timer = Time.time + restoreFrequency;
			}
		}

		//call BoardManagers repair function if active and timer is run down
		if (active && timer <= Time.time) {
			Debug.Log ("Repair!");
			boardManager.GetComponent<BoardManager> ().RestoreTile();
			timer = Time.time + restoreFrequency;
		}
	}
}
