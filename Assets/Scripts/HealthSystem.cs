using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

// INVULNERATBILITY FRAMES SOURCE:
// https://www.aleksandrhovhannisyan.com/blog/invulnerability-frames-in-unity/

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth = 3;
    public float invincibilityDuration;

    //public GameObject model;
    private bool isInvincible = false;

    private IEnumerator IFrames()
    {
        float invincibilityDeltaTime = invincibilityDuration / 10;
        for (float i = 0; i < invincibilityDuration; i += invincibilityDeltaTime)
        {
            if (gameObject.GetComponent<SpriteRenderer>().enabled == true) { gameObject.GetComponent<SpriteRenderer>().enabled = false; }
            else if (gameObject.GetComponent<SpriteRenderer>().enabled == false) { gameObject.GetComponent<SpriteRenderer>().enabled = true; }
            yield return new WaitForSeconds(invincibilityDuration);
        }
        gameObject.GetComponent<SpriteRenderer>().enabled = true; // just in case
        isInvincible = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DamageSource")
        {
            //Destroy(collision.gameObject);
            if (!isInvincible) 
            { 
                currentHealth -= 1; 
                Debug.Log("Hit");
                if (currentHealth <= 0) { YouDied(); }
                else
                {
                    isInvincible = true;
                    StartCoroutine(IFrames());
                }
            }
        }
    }

    // basically a placeholder function for now
    void YouDied() 
    {
        GUI.Label(new Rect(0, 0, 100, 100), "You died.");
    }
}
