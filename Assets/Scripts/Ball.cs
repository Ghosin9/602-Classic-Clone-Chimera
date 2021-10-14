using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //speed of ball
    public float speed;
    public Rigidbody2D rb;
    //start position of the ball
    public Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        //initialize the start position
        startPos = transform.position;
        Launch();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //clamp the velocity of the ball to the speed
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed);
    }

    public void Launch(){
        //randomly assign the direction of the ball upon spawn
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
    }

    public void Reset(){
        //reset the ball's position + start the launch
        rb.velocity = Vector2.zero;
        transform.position = startPos;
        StartCoroutine(LaunchBall());
    }

    IEnumerator LaunchBall(){
        //wait a second and then launch the ball
        yield return new WaitForSeconds(1.0f);
        Launch();
    }
}
