/*
Student Name: Muhammad Murtaza
Student ID: K00223470 
Desc: Object responsible for spawning enemies.	 
*/

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public float minY = -2.5f, maxY = 2.5f;
    public float spawnTimer = 1.2f;		// Time interval to spawn an enemy
    public float bossSpawnTimer = 35f;	// Time after which boss appears
    public GameObject[] enemies;		// array of enemies
    public GameObject boss;				// Boss associated with spawner

    private float startTime;
    private float elapsedTime;			// Time since this object is running

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        Invoke("SpawnEnemies", spawnTimer);
    }

    void SpawnEnemies()
    {
        elapsedTime = Time.time - startTime;

        float posY = Random.Range(minY, maxY);

        Vector3 temp = transform.position;
        temp.y = posY;

        Instantiate(enemies[Random.Range(0, enemies.Length)], temp, Quaternion.identity);

        if(elapsedTime > bossSpawnTimer)
        {
            Debug.Log("Boss appearing!!" + "BossTime: " + elapsedTime);
            SpawnBoss();
        }
        else
        {
            Invoke("SpawnEnemies", spawnTimer);
        }

        
    }
	
	// To instantiate Boss associated with the spawner
    void SpawnBoss()
    {
        Instantiate(boss, boss.transform.position, boss.transform.rotation);

        CancelInvoke(); // Stop spawning of other enemies
        

        gameObject.SetActive(false);
        //Debug.Log("Enemy Spawner deactivated");
    }
}
