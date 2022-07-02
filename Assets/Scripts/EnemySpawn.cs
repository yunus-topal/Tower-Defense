using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemies;

    private Vector3 spawnPosition = new Vector3(150f,1.5f,-60f);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    public IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            int enemyNumber = Random.Range(0,enemies.Length);
            Instantiate(enemies[enemyNumber],spawnPosition, Quaternion.identity);
        }
    }
    
}
