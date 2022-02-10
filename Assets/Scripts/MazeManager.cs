using UnityEngine;
using UnityEngine.Events;

public class MazeManager : MonoBehaviour {
	public UnityEvent MazeFinished;

	public MazeMaker mazeMaker;
	public int Columns = 5; // consider making these properties again when you build a UI for the web player
	public int Rows = 4; // and no longer need to access the values directly in the inspector
	//public Player player;
	public Vector3SO spawnPoint;

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
				mazeMaker.BuildTheEggCarton(Rows, Columns, Delay, spawnPoint);
				MazeFinished.Invoke();
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