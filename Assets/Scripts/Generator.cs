using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [Header("Random Location Asset Generator")]

    [SerializeField][Tooltip("The object you want to be spawned into the scene")]
    public GameObject ObjectSpawned;

    [Header("Bounding Box Parameters")]
    [SerializeField]
    public float minX = -10;
    public float maxX = 10;
    public float minY = 10;
    public float maxY = 20;
    public float minZ = -10;
    public float maxZ = -10;


    public void Awake()
    {
        RandomSpawn();
    }
    private void OnDrawGizmosSelected()
    {
        // Gizmos.DrawWireCube()

        //on void awake it should call spawn function
       // Instantiate(ObjectSpawned, randomPosition, Quaternion.identity);
    }

    public void RandomSpawn()
    {
        var SpawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));

        Instantiate(ObjectSpawned, SpawnPosition, Quaternion.identity);
    }
}
