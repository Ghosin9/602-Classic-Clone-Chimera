using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Ball")]
    public GameObject ball;

    [Header("Players")]
    public GameObject player1;
    public GameObject player2;
    // public bool ballPowerUp;
    // public bool ballPowerUp;

    [Header("Goals")]
    public GameObject player1Goal;
    public GameObject player2Goal;

    [Header("Text")]
    public GameObject player1Text;
    public GameObject player2Text;

    [Header("GameOverText")]
    public GameObject gameOverText;

    //private ints to keep track of score
    private int player1Score;
    private int player2Score;

    //bool for game over
    public bool gameOver;

    //increment score for player 1
    public void player1Scored(){
        player1Score++;
        player1Text.GetComponent<Text>().text = player1Score.ToString();
        ResetPosition();
    }

    //increment score for player 2
    public void player2Scored(){
        player2Score++;
        player2Text.GetComponent<Text>().text = player2Score.ToString();
        ResetPosition();
    }

    //reset the ball's position, and reset the players position if the score is 11
    public void ResetPosition(){
        if (player1Score == 11 || player2Score == 11){
            gameOver = true;
            Time.timeScale = 0f;
            gameOverText.GetComponent<CanvasGroup>().alpha = 1;
            player1.GetComponent<PlayerController>().Reset();
            player2.GetComponent<PlayerController>().Reset();
        }

        ball.GetComponent<Ball>().Reset();
    }

    //restart the game
    public void ResetGame(){
        gameOver = false;
        Time.timeScale = 1f;
        gameOverText.GetComponent<CanvasGroup>().alpha = 0;
        player1Score = 0;
        player2Score = 0;
        player1Text.GetComponent<Text>().text = player1Score.ToString();
        player2Text.GetComponent<Text>().text = player2Score.ToString();
        ball.GetComponent<Ball>().Launch();
    }
}
