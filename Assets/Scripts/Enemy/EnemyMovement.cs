using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour, IEnemy
{

    public GamePausedManager gamePausedManager;

    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;

    public void SetGamePauseManager(GamePausedManager gamePausedManager)
    {
        this.gamePausedManager = gamePausedManager;
    }

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }


    void Update ()
    {
        if (!gamePausedManager.IsGamePaused)
        {
            if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {
                nav.isStopped = false;
                nav.SetDestination(player.position);
            }
            else
            {
                nav.enabled = false;
            }
        }else if ( nav.isActiveAndEnabled ){
            nav.isStopped = true;
        }
    }
}
