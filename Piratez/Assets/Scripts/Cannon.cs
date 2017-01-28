using UnityEngine;
using System.Collections;

public class Cannon : Structure {



	// Use this for initialization
	void Start () {
		slots = 2;
		minPirates = 1;
		active = false;
		currentPirates = 0;
		CreateSlots ();

	}

	// Update is called once per frame
	void Update () {
	}
}
