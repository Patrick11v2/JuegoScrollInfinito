using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{   
    [SerializeField] private float minHeigt, maxHeigt;
    [SerializeField] private GameObject prefab;
    [SerializeField] private float spawnTime, minSpawnTime, timeDecreaseStep;
    [SerializeField] private int spawnCountToDecreaseTime;
    private int spawnerIstances;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        
        while (true)
        {
            DecreaseSpawnTime();
            Instantiate(prefab, GetRandomPosition(), Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
            spawnerIstances++;
        }

    }

    private void DecreaseSpawnTime()
    {
        if (spawnerIstances % spawnCountToDecreaseTime == 0)
        {
            spawnTime -= timeDecreaseStep;
            if (spawnTime < minSpawnTime)
            {
                spawnTime = minSpawnTime;
            }
        }
    }

    private Vector2 GetRandomPosition()
    {
        float randomHeigth = Random.Range(minHeigt, maxHeigt);
        return new Vector2(transform.position.x, randomHeigth);
     
    }

    public void StopSpawn() { StopAllCoroutines(); }
}
