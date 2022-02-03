using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour {

	public MazeMaker mazeMaker;
	public int Columns = 5; // consider making these properties again when you build a UI for the web player
	public int Rows = 4;    // and no longer need to access the values directly in the inspector
	//public Player player;
	
	public WaitForSeconds Delay { get; private set; }

	void Start () {

		mazeMaker.SelectedAlgorithm = "RecursiveBacktracking";
		Delay = new WaitForSeconds(0f);
		
		LoadMaze();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			RestartMaze();
		}
		
	}
	
	void LoadMaze () {

		switch (mazeMaker.SelectedAlgorithm)
		{
			case "RecursiveDivision":
				mazeMaker.GenerateCells(Rows, Columns, Delay);
				break;

			default:
				mazeMaker.BuildTheEggCarton(Rows, Columns, Delay);
				break;
		}
		
	}

	void RestartMaze ()
	{
		StopAllCoroutines();
		Destroy(mazeMaker.gameObject);
		LoadMaze();
	}
	
}