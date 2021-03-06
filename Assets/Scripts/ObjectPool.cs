using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    [SerializeField] GameObject enemyPawnPrefab;
    [SerializeField] GameObject enemyKnightPrefab;
    [SerializeField] GameObject enemyBishopPrefab;
    [SerializeField] GameObject enemyRookPrefab;
    [SerializeField] GameObject enemyQueenPrefab;

    [SerializeField] int poolSize = 5;

    GameObject[] pool;

    [SerializeField] float LevelLength = 60f;
    [SerializeField] float spawnTimer = 1f;

    void Awake()
    {
        PopulatePool();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPawnPrefab, transform);
            pool[i].SetActive(false);
        }
    }
    void EnableObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (!pool[i].activeInHierarchy) { 
                pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (Time.timeSinceLevelLoad < LevelLength)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}