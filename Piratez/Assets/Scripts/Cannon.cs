using UnityEngine;
using System.Collections;

public class Cannon : Structure {

	public float timer;
	public float shotFrequency;
	public float damage;

	// Use this for initialization
	void Start () {
		damage = 0.1f;
		slots = 2;
		minPirates = 1;
		active = false;
		currentPirates = 0;
		shotFrequency = 5f;
		CreateSlots ();
		timer = Time.time + shotFrequency;
		gameManager = GameObject.FindWithTag("GameController");

	}

	// Update is called once per frame
	void Update () {

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
				timer = Time.time + shotFrequency;
			}
		}

		//pass damage to GameManager function if active and timer is run down
		if (active && timer <= Time.time) {
			gameManager.GetComponent<GameManager> ().ShootEnemy(damage * currentPirates);
			timer = Time.time + shotFrequency;
		}
	}
}
