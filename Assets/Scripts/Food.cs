using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    //area in which the food will spawn
    public BoxCollider2D gridArea;

    // Start is called before the first frame update
    void Start()
    {
        //randomly spawn the ball upon spawn
        RandomizePosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomizePosition(){
        //take the bounds of the grid and then spawn the food within those bounds
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0f);
    }

    public void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.CompareTag("Player")){
            //when the player collides, randomize position and then grow the player
            RandomizePosition();

            collider.GetComponent<PlayerController>().Grow();
        }
    }
}
