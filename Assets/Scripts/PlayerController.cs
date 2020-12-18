using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public bool canMove = true;
    //to change in inspector
    [SerializeField]
    float maxPos;
    //to change in inspector
    [SerializeField]
    float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
        }
    }
    private void Move()
    {
        //movement of player with in a given time
        float inputX = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * inputX * moveSpeed * Time.deltaTime;
        //player should not move beyond out of the screen
        float xPos = Mathf.Clamp(transform.position.x, -maxPos, maxPos);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
}
