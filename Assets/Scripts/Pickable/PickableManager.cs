using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableManager : MonoBehaviour {
    public GameObject PickableObject;
    public PlayerHealth playerHealth;
    public GamePausedManager gamePausedManager;
    public Transform[] spawnPoints;
    public float spawnTime = 3f;


    private int lastSpawnPosition = 0;
    private List<GameObject> pickableInstances = new List<GameObject>();

   
    void Start () {
        for (int i = 0; i < spawnPoints.Length; i++ )
        {
            pickableInstances.Insert(i, Instantiate(PickableObject, spawnPoints[i].position, spawnPoints[i].rotation) );
            Pickable pickable = pickableInstances[i].GetComponent<Pickable>();
            if (pickable != null)
            {
                pickable.isPicked = true;
            }
        }
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	void Spawn () {
        if (gamePausedManager == null || !gamePausedManager.IsGamePaused)
        {
            if (playerHealth.currentHealth <= 0f)
            {
                return; 
            }
            /*hide the last spawned one*/
            HideLastSpawnedPickable();
            /*spawn a new one*/
            SpawnNewPickable();
        }
	}

    private void HideLastSpawnedPickable()
    {
        Pickable lastSpawned = pickableInstances[lastSpawnPosition].GetComponent<Pickable>();
        if (lastSpawned != null)
        {
            lastSpawned.isPicked = true;
        }  
    }

    private void SpawnNewPickable()
    {
        lastSpawnPosition = (lastSpawnPosition + 1) >= spawnPoints.Length ? 0 : lastSpawnPosition + 1;

        GameObject pickableObj = pickableInstances[lastSpawnPosition];
        Pickable pickable = pickableObj.GetComponent<Pickable>();
        if (pickable != null)
        {
            pickable.isPicked = false;
        }

    }
}
