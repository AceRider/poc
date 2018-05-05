using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour {

    public GameObject target;                
    public float spawnTime = 1f;
    public int quantity = 2;
    public Transform[] spawnPoints;

    private int[] pointsUsed;

    // Use this for initialization
    void Start () {

      

    }
	
	// Update is called once per frame
	void Update () {

        int targetCount = getTargetCount();

        if (targetCount < quantity)
        {

            for (int i = 0; i < quantity; i++)
            {
                Spawn();
            }
        }
    }

    void SpawnMany() {

    }

    void Spawn()
    {
        //int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        //Instantiate(target, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        List<Transform> freeSpawnPoints = new List<Transform>(spawnPoints);
        
            if (freeSpawnPoints.Count <= 0)
                return; // Not enough spawn points
            int index = Random.Range(0, freeSpawnPoints.Count);

            Transform pos = freeSpawnPoints[index];
            freeSpawnPoints.RemoveAt(index); // remove the spawnpoint from our temporary list
            Instantiate(target, pos.position, pos.rotation);
    }

    int getTargetCount() {

        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");

        if (targets != null)
        {
            return targets.Length;
        }
        else
        {
            return 0;
        }       
    }
}
