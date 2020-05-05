using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public float maxHealth = 100f;
    public float curHealth;

    // CLass variable from HealthBar script
    public HealthBar healthbar;

    // Dead menu
    public GameObject deadMenuUI;


    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.SetHealth(curHealth);
        
        // Testing for healthbar
        if(Input.GetKeyDown(KeyCode.L))
        {
            curHealth -= 30;
            healthbar.SetHealth(curHealth);
        }

        if(curHealth <= 0)
        {
            Debug.Log("Ded");
            // Enable the pause screen ui element in canvas
            deadMenuUI.SetActive(true);

            // Freeze time in game
            Time.timeScale = 0f;

        }        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.relativeVelocity.magnitude);
        if (collision.relativeVelocity.magnitude > 2)
        {
            if(collision.gameObject.tag == "boundary" || collision.gameObject.tag == "asteroid1" || collision.gameObject.tag == "asteroid2" || collision.gameObject.tag == "asteroid3" || collision.gameObject.tag == "asteroid4" )
            {
                curHealth -= collision.relativeVelocity.magnitude * 0.1f;
                healthbar.SetHealth(curHealth);
            }
        } 
    }
}
