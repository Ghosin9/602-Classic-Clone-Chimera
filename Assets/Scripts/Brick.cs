using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
  public float health;
  private float currentHealth;
  private Color changeColor;
  private SpriteRenderer mainColor;
  private Color keepColor;
    public GameObject p;
    public GameObject powerUp;

    public GameManager gm;



  // Start is called before the first frame update
  void Start()
  {
    //sprite = GetComponent<SpriteRenderer>().color.a;
    mainColor = GetComponent<SpriteRenderer>();
    keepColor = mainColor.color;
    setHeath();
  }
  private void setHeath() {
    currentHealth = health;
  }
  private void lowerHealth() { 
        if(p.GetComponent<PlayerController>().isPoweredUp)
        {
            currentHealth = 0;
            p.GetComponent<PlayerController>().isPoweredUp = false;
            //respawn powerup
            if (p.GetComponent<PlayerController>().playerNum){
              powerUp.GetComponent<PowerUp>().RandomizePosition(1.0f);
            } else {
              powerUp.GetComponent<PowerUp>().RandomizePosition(0.0f);
            }

            gm.resetBrickColor(p.GetComponent<PlayerController>().playerNum);
        }
    currentHealth--;

    //Changing Alpha Depending on Health
    //Debug.Log(alphaToSubtract);
    //alphaToSubtract = 1f/health;
    mainColor.color = new Color(mainColor.color.r,mainColor.color.g,mainColor.color.b, (float)(currentHealth/health));

    if (currentHealth <= 0) Destroy(this.gameObject);
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    // check if ball :d
    if (collision.gameObject.CompareTag("Ball")) {
      lowerHealth();
    }

  }

  public void resetColor(){
    mainColor.color = keepColor;
  }
}
