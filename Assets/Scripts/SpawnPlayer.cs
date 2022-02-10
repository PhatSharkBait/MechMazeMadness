using UnityEngine;

public class SpawnPlayer : MonoBehaviour {
    public GameObject player;
    public Vector3SO spawnPoint;

    public void Spawn() {
        Instantiate(player, spawnPoint.value, Quaternion.identity);
    }
}
