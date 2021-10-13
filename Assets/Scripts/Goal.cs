using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    //keep track of which player this goal is assigned to
    public bool playerBool;

    //game manager
    public GameManager gm;

    public void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Ball")){
            //when colliding with the ball, depending on the player assigned, increment score
            if (!playerBool){
                gm.player1Scored();
            } else {
                gm.player2Scored();
            }
        }

        // Debug.Log("erhjajire");
    }
}
