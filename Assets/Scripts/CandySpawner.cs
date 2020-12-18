using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    //max x position candy can be spawned
    [SerializeField]
    float maxX;

    //create an interval
    [SerializeField]
    float spawnInterval;
    //store all the candies
    public GameObject[] Candies;
    //access any function from any code
    public static CandySpawner instance;
    public void Awake()
    {
        if(instance == null) 
        {
            instance = this;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        //SpawnCandy();
        StartSpawrningCandies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //randomnly spawn one candy from the candies selected in random positions
    void SpawnCandy()
    {
        int rand = Random.Range(0, Candies.Length);
        float randomX = Random.Range(-maxX, maxX);
        Vector3 randomPos = new Vector3(randomX, transform.position.y, transform.position.z);
        Instantiate(Candies[rand], randomPos, transform.rotation);
    }
    //repeatedly spawn candies
    IEnumerator SpawnCandies()
        //halt the execution of candies for sometime
    { yield return new WaitForSeconds(2f);
            while (true)
        {
            SpawnCandy();
                yield return new WaitForSeconds(spawnInterval);
        }
            }
    public void StartSpawrningCandies()
    {
        StartCoroutine("SpawnCandies");
            }
    public void StopSpawningCandies()
    { StopCoroutine("SpawnCandies");
    }

}
