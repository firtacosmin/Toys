using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickable : MonoBehaviour, Pickable
{
    public int healthBonus = 10;
    public bool isPicked
    {
        set {
            _isPicked = value;
            if ( anim != null )
            {
                anim.SetBool("IsPicked", _isPicked);
            }
        }
        get {
            return _isPicked;
        }
    }
    private bool _isPicked = false;

    GameObject player;
    PlayerHealth playerHealth;
    Animator anim;


	// Use this for initialization
    void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            int newHealth = playerHealth.currentHealth + healthBonus;
            if (newHealth > playerHealth.startingHealth)
            {
                playerHealth.currentHealth = playerHealth.startingHealth;
            }
            else
            {
                playerHealth.currentHealth = newHealth;
            }
            //Destroy(gameObject, 2f);
            isPicked = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        
    }


}
