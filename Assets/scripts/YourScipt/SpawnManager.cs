using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject obstaclePrefab;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, 4f);
    }

    void Spawn()
    {
        
        GameObject player = GameObject.Find("Player");
        bool isGameOver = player.GetComponent<PlayerController>().gameOver;
        if (isGameOver)
        {
            return;
        }

        Instantiate(
            obstaclePrefab,
            spawnPoint.position,
            obstaclePrefab.transform.rotation
        );
    }
}
