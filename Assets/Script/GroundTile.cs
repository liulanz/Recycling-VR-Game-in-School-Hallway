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
        Destroy(gameObject, 2); //destory the object after 2 seconds
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

        //spawn the obstacle at the position
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
         );
        if (point != collider.ClosestPoint(point)) // if point is generated outside of collider gengerate a new one
        {
            point = GetRandomPointInCollider(collider);
        }
        point.y = -4f;
        return point;

    }
    public void SpawnCoins()
    {
        int coinsToSpawn = 4;
        for(int i = 0; i <coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }
 
    public void SpawnBlueTrash()
    {
        int randomTrash = Random.Range(0, blueTrashPrefab.Length);
        int blueTrashToSpawn = 2;
        for (int i = 0; i < blueTrashToSpawn; i++)
        {
            GameObject temp = Instantiate(blueTrashPrefab[randomTrash]);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }
    public void SpawnBlackTrash()
    {
        int randomTrash = Random.Range(0, blackTrashPrefab.Length);
        int blackTrashToSpawn = 2;
        for (int i = 0; i < blackTrashToSpawn; i++)
        {
            
            GameObject temp = Instantiate(blackTrashPrefab[randomTrash]);

            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }
    public void SpawnGreenTrash()
    {
        int randomTrash = Random.Range(0, greenTrashPrefab.Length);
        int greenTrashToSpawn = 2;
        for (int i = 0; i < greenTrashToSpawn; i++)
        {

            GameObject temp = Instantiate(greenTrashPrefab[randomTrash]);

            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

}
