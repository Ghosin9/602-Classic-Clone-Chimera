using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentScript : MonoBehaviour
{
    public bool playerNum;

    public void OnCollisionEnter2D(Collision2D collider){
        if (collider.gameObject.CompareTag("Ball")){
            //if you hit the ball shrink the player
            if(playerNum){
                GameObject.Find("Player1").GetComponent<PlayerController>().Shrink();
            } else {
                GameObject.Find("Player2").GetComponent<PlayerController>().Shrink();
            }
        }
    }
}
