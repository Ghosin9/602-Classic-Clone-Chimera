using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
  public int health;
  private int currentHealth;


  // Start is called before the first frame update
  void Start()
  {
    setHeath();
  }
  private void setHeath() {
    currentHealth = health;
  }
  private void lowerHealth() { 
    currentHealth--;
    if (currentHealth <= 0) Destroy(this.gameObject);
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    // check if ball :d
    if (collision.gameObject.CompareTag("Ball")) {
      lowerHealth();
    }

  }
}
