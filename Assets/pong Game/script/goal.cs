using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    public bool isplayer1goal;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            if(isplayer1goal) 
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().player1Score();
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().player2Score();
            }
        }
    }
}
