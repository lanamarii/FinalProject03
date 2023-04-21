using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [Header("Random Location Asset Generator")]

    [SerializeField][Tooltip("The object you want to be spawned into the scene")]
    public GameObject ObjectSpawned;

    private GameObject _object;

    [Header("Timer")]

    [SerializeField][Tooltip("How long Object(s) should be spawned in")]
    public float SpawnInterval = 5;

    private float UnityTimer;

    [Header("Bounding Box Parameters")]

    //min boundary variables for gizmo calculation

    [SerializeField] [Tooltip("Where the center of the bounding box is located in the scene")]
    public Vector3 BoxCenter;
    [SerializeField][Tooltip("Size of Bounding Box")]
    public Vector3 BoxSize;

    public void Awake()
    {
        RandomSpawn();

    }
    private void OnDrawGizmosSelected()
    {
      

        //draw a visual representation for min distance
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(BoxCenter, BoxSize);
    
    }

    private void Update()
    {
        UnityTimer += Time.deltaTime;

        if(UnityTimer >= SpawnInterval)
        {
            ResetPositions();

            UnityTimer = 0;
        }
    }

    public void RandomSpawn()
    {
        var SpawnPosition = BoxCenter + new Vector3(Random.Range(-BoxSize.x / 2, BoxSize.x / 2), Random.Range(-BoxSize.y / 2, BoxSize.y / 2), Random.Range(-BoxSize.z / 2, BoxSize.z / 2));

        _object = Instantiate(ObjectSpawned, SpawnPosition, Quaternion.identity);
    }

    public void ResetPositions()
    {
        var newPosition = BoxCenter + new Vector3(Random.Range(-BoxSize.x / 2, BoxSize.x / 2), Random.Range(-BoxSize.y / 2, BoxSize.y / 2), Random.Range(-BoxSize.z / 2, BoxSize.z / 2));

        if (_object != null)
        {
            _object.transform.position = newPosition;
        }
    }
}
