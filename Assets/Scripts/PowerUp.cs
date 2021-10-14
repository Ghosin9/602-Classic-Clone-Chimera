using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //area in which the food will spawn
    public BoxCollider2D gridArea1;
    public BoxCollider2D gridArea2;

    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        //randomly spawn the ball upon spawn
        RandomizePosition(Random.Range(0, 2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomizePosition(float z){
        // float z = Random.Range(0, 2);
        //take the bounds of the grid and then spawn the food within those bounds
        if (z == 0)
        {
            Bounds bounds = this.gridArea1.bounds;

            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);
            this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0f);

        }
        else
        {
            Bounds bounds = this.gridArea2.bounds;

            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);
            this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0f);

        }

    }

    public void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.CompareTag("Player")){
            // move ball off camera, then call respawn
            this.transform.position = new Vector3(10.0f, 10.0f, 0.0f);
            collider.GetComponent<PlayerController>().isPoweredUp = true;
            gm.powerUpBricks(collider.GetComponent<PlayerController>().playerNum);
            // StartCoroutine(RespawnPowerUp());
        }
    }
    
    public IEnumerator RespawnPowerUp(){
        //wait a second and then launch the ball
        yield return new WaitForSeconds(1.0f);
        RandomizePosition(Random.Range(0,2));
    }
}
