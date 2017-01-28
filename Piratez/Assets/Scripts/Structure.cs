using UnityEngine;
using System.Collections;

public class Structure : MonoBehaviour {

	public class Tile{
		float Health;
		int x;
		int z;
		GameObject instance;

		public Tile(int xpos, int zpos, float hp, GameObject inst){
			x = xpos;
			z = zpos;
			Health = hp;
			instance = inst;

		}
	}

	public Tile[,] supportTiles;
	public int slots;
	public int minPirates;
	public int currentPirates;
	public bool active;
	public GameObject slot;

	public void CreateSlots(){
		for (int i = 0; i < slots + 1; i++) {
			GameObject newSlot = slot;
			float z = gameObject.transform.position.z - 0.7f;
			float x = gameObject.transform.position.x + (-0.4f + (i * 0.4f));
			GameObject instance = Instantiate (newSlot, new Vector3 (x, 0f, z), Quaternion.identity) as GameObject;
			instance.transform.SetParent (gameObject.transform);
		}
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
