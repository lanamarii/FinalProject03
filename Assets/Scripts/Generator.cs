using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [Header("Random Location Asset Generator")]

    [SerializeField][Tooltip("The object you want to be spawned into the scene")]
    public GameObject ObjectSpawned;

    [SerializeField]
    [Tooltip("Number of objects to spawn")]
    public int NumberOfObjects = 1;

    //array for game objects spawning
    private GameObject[] _objects;

    [Header("Timer")]

    [SerializeField][Tooltip("How long the object will stay in the same position")]
    public float MoveInterval = 5;

    [SerializeField][Tooltip("Would you like the object to move after a set time?")]
    bool MoveObject = true;

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
      

        //draw a visual representation of bounding box for user to see
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(BoxCenter, BoxSize);
    
    }

    private void Update()
    {

        //setting timer to real time
        UnityTimer += Time.deltaTime;

        //if MoveObject is true and timer is greater than set time, object will move
        if(UnityTimer >= MoveInterval && MoveObject == true)
        {
            ResetPositions();

            ResetTimer();
        }
    }

    public void RandomSpawn()
    {

        //adding a new object to the array, based off the amount of objects the user wants to spawn in 
        _objects = new GameObject[NumberOfObjects];
        for (int i = 0; i < NumberOfObjects; i++)
        {

            //gizmo box parameters used to determine where the objects can be randomly generated in 
            var SpawnPosition = BoxCenter + new Vector3(Random.Range(-BoxSize.x / 2, BoxSize.x / 2), Random.Range(-BoxSize.y / 2, BoxSize.y / 2), Random.Range(-BoxSize.z / 2, BoxSize.z / 2));

            //spawn a new object
            _objects[i] = Instantiate(ObjectSpawned, SpawnPosition, Quaternion.identity);
        }
    }

    public void ResetPositions()
    {
        for (int i = 0; i < _objects.Length; i++)
        {

            //creates new position for the object(s) to move 
            var newPosition = BoxCenter + new Vector3(Random.Range(-BoxSize.x / 2, BoxSize.x / 2), Random.Range(-BoxSize.y / 2, BoxSize.y / 2), Random.Range(-BoxSize.z / 2, BoxSize.z / 2));


            //if object(s) are not destroyed, they can move positions
            if (_objects[i] != null)
            {
                _objects[i].transform.position = newPosition;
            }
        }
    }

    public void ResetTimer()
    {
        UnityTimer = 0;
    }
}
