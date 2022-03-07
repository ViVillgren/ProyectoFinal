using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;

    public int health;
    public int killedEnemies;

    public List<EnemyData> enemyPos;
    public GameObject prefabEnemy;

    // Start is called before the first frame update
    void Start()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
            ReloadRemainingEnemies();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void KillEnemy()
    {
        killedEnemies++;
    }

    public void ReduceHealth()
    {
        health--;
    }

    public void ReloadRemainingEnemies()
    {
        foreach(EnemyData e in enemyPos)
        {
            if (!e.isDead && SceneManager.GetActiveScene().name==e.levelName)
            {
                Instantiate(prefabEnemy, e.enemyPos, Quaternion.identity);
            }
        }
    }

}
