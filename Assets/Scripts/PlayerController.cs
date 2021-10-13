using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //bool for which player you are
    public bool playerNum;
    //speed of player
    public float speed;
    public Rigidbody2D rb;

    //start pos of player
    public Vector3 startPos;

    public GameManager gm;

    //direction of the player
    private Vector2 direction = Vector2.up;
    //movement vectors
    private float movementX;
    private float movementY;

    //int of initial size of snake
    public int initialSize;

    //list of segments
    public List<Transform> segments;

    //segment prefab
    public Transform segmentPrefab;

    void Start(){
        //initialize list and start pos
        segments = new List<Transform>();
        startPos = this.transform.position;
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        //gain input of the player depending on which player
        if (playerNum){
            movementX = Input.GetAxisRaw("Horizontal");
            movementY = Input.GetAxisRaw("Vertical");
        } else {
            movementX = Input.GetAxisRaw("Horizontal2");
            movementY = Input.GetAxisRaw("Vertical2");
        }

        //assign direction vectors based on movement vectors
        if (movementX == -1) {
            direction = Vector2.left;
        } else if (movementX == 1){
            direction = Vector2.right;
        }

        if (movementY == -1){
            direction = Vector2.down;
        } else if (movementY == 1){
            direction = Vector2.up;
        }

        //restart game if game over
        if (gm.gameOver){
            if (Input.GetButtonDown("Jump")){
                gm.ResetGame();
            }
        }
    }

    void FixedUpdate(){

        //move the segments to follow the previous segment by a certain distance
        for(int x = segments.Count -1; x > 0; x--){
            if (segments[x] != null){
                if (Vector3.Distance(segments[x].position, segments[x-1].position) > 0.4f)
                    segments[x].position = Vector3.MoveTowards(segments[x].position, segments[x-1].position, speed * Time.fixedDeltaTime);
            }
            
        }

        //assign the velocity of the player depending on direction vector
        rb.velocity = new Vector3(direction.x, direction.y, 0f) * speed;
    }

    public void Reset(){
        //reset player's velocity and position
        rb.velocity = Vector2.zero;
        transform.position = startPos;

        //destroy all the segments + segments list
        for (int x = 1; x < segments.Count; x++){
            Destroy(segments[x].gameObject);
        }
        segments.Clear();
        segments.Add(this.transform);

        //add the initial list
        for(int x = 1; x < initialSize; x++){
            Grow();
        }
    }

    public void Grow(){
        //instantiate a new segment, assign it to the player, and then add it to the list of segments
        Transform segment = Instantiate(this.segmentPrefab);
        if (playerNum){
            segment.GetComponent<SegmentScript>().playerNum = true;
        } else {
            segment.GetComponent<SegmentScript>().playerNum = false;
        }
        Vector3 newPos = new Vector3(segments[segments.Count -1].position.x - direction.x, segments[segments.Count -1].position.y - direction.y, 0f);
        segment.position = newPos;

        segments.Add(segment);
    }

    public void Shrink(){
        //remove the last segment in the list
        if (segments.Count > 1){
            Destroy(segments[segments.Count-1].gameObject);
            segments.RemoveAt(segments.Count-1);
        }
    }

    public void OnCollisionEnter2D(Collision2D collider){
        if (collider.gameObject.CompareTag("Ball")){
            //shrink if you hit the ball
            if(playerNum){
                Shrink();
            } else {
                Shrink();
            }
        }
    }
}
