using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

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
		
	public int columns = 11;
	public int rows = 5;
	public float tileHealth = 100;
	public GameObject tile;
	public GameObject cannon;
	public Transform boardHolder;

	public Tile deckTile;

	public Tile[,] tileArray;
	public Transform[,] cannonSlots;

	public void BoardSetup(){
		tileArray = new Tile[columns, rows];
		cannonSlots = new Transform[columns,rows];
		for (int x = 0; x < columns; x++) {
			for (int z = 0; z < rows; z++) {
				GameObject toInstantiate = tile;
				GameObject instance = Instantiate (toInstantiate, new Vector3 (x, 0f, z), Quaternion.identity) as GameObject;
				Tile newTile = new Tile (x, z, tileHealth, instance);
				tileArray [x, z] = newTile;
				if ((x % 2 != 0) && z == rows-1) {
					cannonSlots [x, z] = instance.transform;
					GameObject buildCannon = cannon;
					GameObject newCannon = Instantiate (buildCannon, new Vector3 (x, 0f, z), Quaternion.identity) as GameObject;
				}
				//
				instance.transform.SetParent (boardHolder);
			}
		}
		foreach (Transform i in cannonSlots) {
			Debug.Log (i);
		}

	}





	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
