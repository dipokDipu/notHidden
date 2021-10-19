using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab , powerUpPrefab;
    private int enemyCount, enemyRemain;

   
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = 1;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        enemyRemain = FindObjectsOfType<EnemyContoller>().Length;
        if(enemyRemain <= 0)
        {
            SpawnWave(enemyCount++);
            Instantiate(powerUpPrefab, SpawnPosition(), powerUpPrefab.transform.rotation);
        }
    }


    void SpawnWave(int enemies)
    {

        for(int i =0; i<enemies; i++)
        {
            Instantiate(enemyPrefab, SpawnPosition(),Random.rotation);
        }
      
    }

    Vector3 SpawnPosition()
  {


        float spawnPosX = Random.Range(-9f, 9f);
        float spawnPosZ = Random.Range(-9f, 9f);

        if(spawnPosX == 0 && spawnPosZ == 0 )
        {
            return new Vector3(5f, 0f, 5f);
        }

        return new Vector3(spawnPosX, 0f, spawnPosZ);

    }
}
