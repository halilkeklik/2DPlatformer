using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    public GameObject[] attackablePrefabs;
    public int platformSpawnCount;

    public Vector3   lastEndPoint;

    public void SpawnPlatforms()
    {
        for (int i = 0; i < platformSpawnCount; i++)
        {
            GameObject platform = GameObject.Instantiate(platformPrefabs[Random.Range(0,platformPrefabs.Length)]);
            Platform platformScript = platform.GetComponent<Platform>();

            platform.transform.position = lastEndPoint;

            int x = Random.Range(0, 10);
            if (x >= 7)
            {
                GameObject enemy = GameObject.Instantiate(attackablePrefabs[Random.Range(0, attackablePrefabs.Length)]);
                {
                    enemy.transform.position = lastEndPoint + new Vector3(1, 0.81f, 0);
                }
            }
            lastEndPoint = platformScript.returnEndPoint();
        }
    }

    private void Awake()
    {
        lastEndPoint.z = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlatforms();
    }

    private void FixedUpdate()
    {

    }
}
