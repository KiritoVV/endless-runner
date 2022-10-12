using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject groundChecker;
    public LayerMask whatIsGround;

    float maxSpeed = 60.0f;
    bool isOnGround = false;
    bool jump = true;

    //Create a reference to the Rigidbody2D so we can manipulate it
    Rigidbody2D playerObject;
    
    // start is called before the first frame update
    void Start()
    {
        //Find the Rigidbody2D component that is attached to the same object as this script
        playerObject = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        //Create a `float` that will be equal to the players horizontal input
        float movementValueX = 4.0f;
        //Change the X velocity of the Rigidbody2D to be equal to the movement value
        playerObject.velocity = new Vector2 (movementValueX, playerObject.velocity.y); 

        //check to see if the ground check object is touching the ground
        isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 0.01f, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isOnGround == true) 
            {
                playerObject.AddForce(new Vector2(0.0f, 600.0f));
            } 
            else if (jump == true) 
            {
                playerObject.velocity = new Vector2(playerObject.velocity.x, 0.0f);
                playerObject.AddForce(new Vector2(0.0f, 50.0f));
                jump = false;
            }
        }

        if (isOnGround) {
          jump = true;
        }
    }
        /*
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && jump == true) 
        {
          playerObject.AddForce(new Vector2(0.0f, 600.0f));
          jump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == false && jump == false)
        {
          playerObject.AddForce(new Vector2(0.0f, 200.0f));
          jump = true;
        } 
        */

}
