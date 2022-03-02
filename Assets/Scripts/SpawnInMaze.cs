using UnityEngine;

public class SpawnInMaze : MonoBehaviour {
    public GameObject obj;
    public StackSO currentMaze;
    
    private Vector3 offset = Vector3.up;

    public void SpawnObject() {
        Vector3 spawnLocation = currentMaze.Data.GetRandomCell().Floor.transform.position;
        Instantiate(obj, spawnLocation + offset, Quaternion.identity);
    }
}
