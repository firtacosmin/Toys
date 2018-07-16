using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour, IEnemy
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    public GamePausedManager gamePausedManager;

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        if (gamePausedManager == null || !gamePausedManager.IsGamePaused)
        {
            timer += Time.deltaTime;

            if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
            {
                Attack();
            }

            if (playerHealth.currentHealth <= 0)
            {
                anim.SetTrigger("PlayerDead");
            }
        }
    }


    void Attack ()
    {
        timer = 0f;

        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage);
        }
    }

    public void SetGamePauseManager(GamePausedManager gamePausedManager)
    {
        this.gamePausedManager = gamePausedManager;
    }
}
