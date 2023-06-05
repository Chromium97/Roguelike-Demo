using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject enemyEasy;
    public GameObject enemyHard;
    public GameObject bossEnemy;
    public GameObject spawnEnemyType;
    public GameObject bigBoss;
    public int x;
    public int z;
    public int randomEnemy;
    public int enemyCount;
    public int maxEnemy = 100000;
    public float spawnSpeed = 5.0f;
    public bool bossSpawn = false;
    public int playerScore;

    public AudioClip bossClip;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner());
        StartCoroutine(IncreaseDifficulty());
    }

    private void Update()
    {
        playerScore = ScoreManager.totalScore;

    }

    IEnumerator IncreaseDifficulty()
    {
        while (true)
        {
            spawnSpeed = spawnSpeed - 0.2f;
            Debug.Log(spawnSpeed);
            yield return new WaitForSeconds(10f);
        }
    }

    IEnumerator EnemySpawner()
    {

        while (enemyCount < maxEnemy)
        {
            if (playerScore != 0 && playerScore % 20 == 0)
            {
                bossSpawn = true;
               
            }

            if (bossSpawn)
            {
                spawnEnemyType = bigBoss;
                AudioSource.PlayClipAtPoint(bossClip, transform.position);
                
            }
            else if (playerScore != 0 && playerScore % 15 == 0 || playerScore != 0  && playerScore >= 15 && playerScore % 3 == 0)
            {
                spawnEnemyType = bossEnemy;
                AudioSource.PlayClipAtPoint(bossClip, transform.position);
            }
            else
            {
                randomEnemy = Random.Range(1, 3);
                if (randomEnemy == 1)
                {
                    spawnEnemyType = enemyEasy;
                }
                if (randomEnemy == 2)
                {
                    spawnEnemyType = enemyHard;
                }
            }
            
            x = Random.Range(-28, 32);
            z = Random.Range(-35, 27);
            if (bossSpawn)
            {
                Instantiate(spawnEnemyType, new Vector3(-0.8f, -1.9f, -2.5f), Quaternion.identity);
            }
            else
            {
                Instantiate(spawnEnemyType, new Vector3(x, -1.9f, z), Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnSpeed);
        }
    }
}
