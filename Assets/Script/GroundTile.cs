using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject coinPrefab;
   
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject [] blueTrashPrefab;
    [SerializeField] GameObject[] blackTrashPrefab;
    [SerializeField] GameObject[] greenTrashPrefab;


    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
       
    }

    void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnObstacle()
    {
        //choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        int randomTrash;
        GameObject temp;
        //spawn the obstacle at the position
        if (obstacleSpawnIndex == 2)
        {
            randomTrash = Random.Range(0, greenTrashPrefab.Length);

            Instantiate(greenTrashPrefab[randomTrash], spawnPoint.position, Quaternion.identity, transform);

        }
        else if (obstacleSpawnIndex == 3)
        {
            randomTrash = Random.Range(0, blueTrashPrefab.Length);

            Instantiate(blueTrashPrefab[randomTrash], spawnPoint.position, Quaternion.identity, transform);

        }
        else 
        {
            randomTrash = Random.Range(0, blackTrashPrefab.Length);
         
            Instantiate(blackTrashPrefab[randomTrash], spawnPoint.position, Quaternion.identity, transform);


        }


    }


}
