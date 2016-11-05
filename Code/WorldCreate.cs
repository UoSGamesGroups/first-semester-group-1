using UnityEngine;
using System.Collections;

public class WorldCreate : MonoBehaviour {
	public GameObject[] tiles = new GameObject[10];
	private int[,] screenGrid = new int[20, 40];
	private int[,] levelGrid = {
		{1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, },
		{1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
		{1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
		{1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
		{1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
		{1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
		{1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
		{1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, },
		{1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
		{1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
		{1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, },
		{1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, },
		{1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, },
		{1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, },
		{1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
		{1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, },
		{1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, },
		{1, 0, 2, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, },
		{1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, },
		{1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, },
	};
	//public TileScript update;
	int level = 0;


	// Use this for initialization
	void Start () {
		for (int x = 0; x < 20; x++) {
			for (int y = 0; y < 40; y++) {
				//if(screenGrid[x, y] != levelGrid[x, y]){
				screenGrid[x, y]=levelGrid[x ,y];
					//update.updateScreen();
				//}
				switch (screenGrid[x,y]) {
				case 0:
					//Instantiate (tiles[0],new Vector3(-y,x),Quaternion.identity);
					break;
				case 1:
					Instantiate (tiles[1],new Vector3(y,-x),Quaternion.identity);
					break;
				case 2:
					Instantiate (tiles[2],new Vector3(y,-x),Quaternion.identity);
					break;
				case 3:
					Instantiate (tiles[3],new Vector3(y,-x),Quaternion.identity);
					break;
				case 4:
					Instantiate (tiles[4],new Vector3(y,-x),Quaternion.identity);
					break;
				case 5:
					Instantiate (tiles[5],new Vector3(y,-x),Quaternion.identity);
					break;
				case 6:
					Instantiate (tiles[6],new Vector3(y,-x),Quaternion.identity);
					break;
				case 7:
					Instantiate (tiles[7],new Vector3(y,-x),Quaternion.identity);
					break;
				case 8:
					Instantiate (tiles[8],new Vector3(y,-x),Quaternion.identity);
					break;
				case 9:
					Instantiate (tiles[9],new Vector3(y,-x),Quaternion.identity);
					break;
				default:
					Instantiate (tiles[0],new Vector3(y,-x),Quaternion.identity);
					break;
				}
			}
		}
	}
	/*
	// Update is called once per frame
	void Update () {
		for (int x = 0; x < 20; x++) {
			for (int y = 0; y < 40; y++) {
				if(screenGrid[x, y] != levelGrid[x,y]){
					screenGrid[x, y]=levelGrid[x,y];
					//update.updateScreen();
					switch (screenGrid [x, y]) {
					case 0:
					
						break;
					case 1:
						Instantiate (tiles [1], new Vector3 (-x  , y  ), Quaternion.identity);
						break;
					case 2:
						Instantiate (tiles [2], new Vector3 (-x  , y  ), Quaternion.identity);
						break;
					case 3:
						Instantiate (tiles [3], new Vector3 (-x  , y  ), Quaternion.identity);
						break;
					case 4:
						Instantiate (tiles [4], new Vector3 (-x  , y  ), Quaternion.identity);
						break;
					case 5:
						Instantiate (tiles [5], new Vector3 (-x  , y  ), Quaternion.identity);
						break;
					case 6:
						Instantiate (tiles [6], new Vector3 (-x  , y  ), Quaternion.identity);
						break;
					case 7:
						Instantiate (tiles [7], new Vector3 (-x  , y  ), Quaternion.identity);
						break;
					case 8:
						Instantiate (tiles [8], new Vector3 (-x  , y  ), Quaternion.identity);
						break;
					case 9:
						Instantiate (tiles [9], new Vector3 (-x  , y  ), Quaternion.identity);
						break;
					default:
						Instantiate (tiles [0], new Vector3 (-x  , y  ), Quaternion.identity);
						break;
					}
				}
			} 
		}
	}
	*/
}



