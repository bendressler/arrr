using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

	//set up tile class for the ship deck
	public class Tile{
		public float health;
		public int x;
		public int z;
		public GameObject instance;

		public Tile(int xpos, int zpos, float hp, GameObject inst){
			x = xpos;
			z = zpos;
			health = hp;
			instance = inst;

		}
	}

	//set ship dimensions and assets
	public int columns = 11;
	public int rows = 5;
	public Tile deckTile;
	public Tile[,] tileArray;
	public Transform[,] cannonSlots;

	public float tileHealth = 100;

	//set gameobjects
	public GameObject tile;
	public GameObject cannon;
	public GameObject repairBay;
	public GameObject dmgText;
	public GameObject canvas;

	//set boardholder to parent tiles
	public Transform boardHolder;

	//set Sprites for deck
	public Sprite tile0;
	public Sprite tile1;
	public Sprite tile2;
	public Sprite tile3;



	//set up the ship
	public void BoardSetup(){

		//initialise arrays to hold the deck tiles and cannon positions
		tileArray = new Tile[columns, rows];
		cannonSlots = new Transform[columns,rows];
	
		//loop through columns and rows and create tiles and cannons
		for (int x = 0; x < columns; x++) {
			for (int z = 0; z < rows; z++) {
				GameObject toInstantiate = tile;
				GameObject instance = Instantiate (toInstantiate, new Vector3 (x, 0f, z), Quaternion.identity) as GameObject;
				Tile newTile = new Tile (x, z, tileHealth, instance);
				tileArray [x, z] = newTile;
				//create cannons on uneven columns and the top row
				if ((x % 2 != 0) && z == rows-1) {
					cannonSlots [x, z] = instance.transform;
					GameObject buildCannon = cannon;
					GameObject newCannon = Instantiate (buildCannon, new Vector3 (x, 0f, z), Quaternion.identity) as GameObject;
				}
				//create repairbay at a fixed position
				if (x == 4 && z == 1) {
					GameObject newRepairBay = Instantiate (repairBay, new Vector3 (x, 0f, z), Quaternion.identity) as GameObject;
				}
				//set tile parent to boardholder
				instance.transform.SetParent (boardHolder);
			}
		}
	}

	//method to pick a random tile from the tile array
	Tile PickRandomTile(){
		Tile randomtile;
		randomtile = tileArray[Random.Range(0,columns),Random.Range(0,rows)];
		return randomtile;
	}

	//method that shoots a random tile on the ship
	public void ShootTile(){
		//picks random tile and damage
		Tile targetTile = PickRandomTile ();
		float damage = Random.Range (20, 50);

		//if tile is not already broken, deal damage
		if (targetTile.health > 0){
			targetTile.health -= damage;

			//damage text (currently broken)
			Vector2 screenPosition = Camera.main.ScreenToWorldPoint (targetTile.instance.transform.position);
			GameObject newDmgText = Instantiate (dmgText, targetTile.instance.transform.position, Quaternion.identity) as GameObject;
			newDmgText.transform.SetParent (canvas.transform,false);
			newDmgText.transform.position = screenPosition;

			//set new sprite for tile that was shot if applicable
			SpriteRenderer tileRenderer = targetTile.instance.GetComponentInChildren<SpriteRenderer> ();
			if (targetTile.health <= 75){
				tileRenderer.sprite = tile1;
				if (targetTile.health <= 30) {
					tileRenderer.sprite = tile2;
						if (targetTile.health <= 0) {
							tileRenderer.sprite = tile3;
						}
				}
			}
		}
	}

	//function to restore a broken tile
	public void RestoreTile(){
		Tile targetTile = tileArray[0,0];

		//loop through tile array and pick the tile with lowest health
		foreach (Tile t in tileArray){
			if (t.health < targetTile.health) {
				targetTile = t;
			}
		}

		//restore that tile and refresh the sprite
		targetTile.health = tileHealth;
		SpriteRenderer tileRenderer = targetTile.instance.GetComponentInChildren<SpriteRenderer> ();
		tileRenderer.sprite = tile0;

	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
