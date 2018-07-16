using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject[] enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public GamePausedManager gamePausedManager;

    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        if (gamePausedManager == null || !gamePausedManager.IsGamePaused)
        {
            if (playerHealth.currentHealth <= 0f)
            {
                return;
            }

            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            GameObject enemyObj = Instantiate(enemy[spawnPointIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            EnemyMovement enemyMovement = enemyObj.GetComponent<EnemyMovement>();
            if ( enemyMovement != null ) 
            {
                enemyMovement.SetGamePauseManager(gamePausedManager);
            }
            EnemyAttack enemyAttack = enemyObj.GetComponent<EnemyAttack>();
            if (enemyAttack != null)
            {
                enemyAttack.SetGamePauseManager(gamePausedManager);
            }

        }
    }
}
