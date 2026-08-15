using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnInterval = 2f;
    public float minY = -2f;
    public float maxY = 2f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    void SpawnPipe()
    {
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0f);
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }
}