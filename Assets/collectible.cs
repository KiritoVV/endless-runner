using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    public int coinValue = 1;
     
    private void OnTriggerEnter2D(Collider2D other)
    {
        /////////////////// COIN SYSTEM ///////////////////

        //THE CODE BELOW ADDS 1 SCORE TO THE COIN THAT THE PLAYER COLLECTS!

        if(other.gameObject.CompareTag("Player"))
        {
            if(gameObject.tag == "Coins")
            {
                Debug.Log("AAAH");
                GameObject.Find("scoreManager").GetComponent<scoreManager>().ChangeScore(coinValue);
            }
      
        }

        //THIS DESTROYS THE COIN
        if(other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
        }
    }
}
