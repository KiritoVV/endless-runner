using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        /////////////////// COIN SYSTEM /////////////////////////

        //THE CODE BELOW ADDS 1 SCORE TO THE COIN THAT THE PLAYER COLLECTS!

        if(other.gameObject.CompareTag("Player"))
        {
            if(gameObject.tag == "Coins")
            {
                Debug.Log("AAAH");
                GameObject.Find("ScoreManager").GetComponent<ScoreManager>().ChangeScore(coinValue);
            }
        }

        //THIS DESTROYS THE COINS
        if(other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
        }
    }  
}
