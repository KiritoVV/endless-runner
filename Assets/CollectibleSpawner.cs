using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    //Create a public array of objects to spawn, we will fill this up using unity editor.
    public GameObject[] objectToSpawn;

    float timeToNextSpawn; //Track how long we should wait before spawning a new object
    float timeSinceLastSpawn = 0.0f; //Track the time since we last spawned something.

    public float minSpawnTime = 5.0f;
    public float maxSpawnTime = 10.0f;
    // start is called before the first frame update 
    void Start()
    {
        //Random.Range returns a random float between two values
        timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
    
    // Update is called once per frame
    void Update()
    {
        //Add Time.deltaTime returns the amount of time passed since the last frame.
        //This will create a float that counts up in seconds

        timeSinceLastSpawn = timeSinceLastSpawn + Time.deltaTime;

        //If we`ve counted past the amount of time we need to wait

        if(timeSinceLastSpawn > timeToNextSpawn)
        {
            //use Random.Range to pick a number between 0 and the amount of items we have on our object list
            int selection = Random.Range(0, objectToSpawn.Length);

            //Instantiate spawnsa GameObject - in this case we tell it to spawn a game object from our objects to spawn list
            //The second parameter in the brackets tells it where to spawn, so we`ve entered the position of the spawner.
            //The third Parameter is for rotation, and Quaternion.identity means no rotation

            Instantiate(objectToSpawn[selection], transform.position, Quaternion.identity);

            //After spawning, we select a new random time for the next spawn and set our timer back to zero
            timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
            timeSinceLastSpawn = 0.0f;

        }
    }
}
