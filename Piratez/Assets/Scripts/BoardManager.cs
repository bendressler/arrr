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
		
	public int columns = 10;
	public int rows = 5;
	public float tileHealth = 100;
	public GameObject tile;

	public Tile deckTile;

	public Tile[,] tileArray;

	public void BoardSetup(){
		for (int x = 0; x < columns; x++) {
			for (int z = 0; z < rows; z++) {
				GameObject toInstantiate = tile;
				GameObject instance = Instantiate (toInstantiate, new Vector3 (x, 0f, z), Quaternion.identity) as GameObject;
				Debug.Log (instance);
				Tile newTile = new Tile (x, z, tileHealth, instance);
				tileArray [x, z] = newTile;
				Debug.Log ("Created 1 new tile");
			}
		}

	}





	// Use this for initialization
	void Start () {
		tileArray = new Tile[columns, rows];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
