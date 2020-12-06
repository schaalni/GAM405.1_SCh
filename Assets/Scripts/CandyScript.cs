using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
        //candy should collide with the player to get detroyed
    { if(collider.gameObject.tag == "Player")
        {
            //Increment Score
            Destroy(gameObject);
                }
    //when player misses the candy it should get destroyed
    else if(collider.gameObject.tag == "Boundary")
        {
            //Decrease lives when a cangy is missed
            Destroy(gameObject);
        }
    }
}
