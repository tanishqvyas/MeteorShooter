using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public float maxHealth = 100f;
    public float curHealth;

    // CLass variable from HealthBar script
    public HealthBar healthbar;

    public float maxShieldHealth = 40f;
    public float curShieldHealth;
    private GameObject shield;
    private bool isShieldActive;
    public ShieldBar shieldbar;
    public GameObject shieldPrefab;
    [HideInInspector]
    public Renderer shipShield;

    // Dead menu
    public GameObject deadMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

        isShieldActive = false;
        curShieldHealth = 0f;
        shieldbar.SetShieldMaxHealth(maxShieldHealth);
        shieldbar.SetShieldHealth(curShieldHealth);

    }

    // Update is called once per frame
    void Update()
    {
        healthbar.SetHealth(curHealth);
        shieldbar.SetShieldHealth(curShieldHealth);
        
        // Testing for healthbar
        // if(Input.GetKeyDown(KeyCode.L))
        // {
        //     curHealth -= 30;
        //     healthbar.SetHealth(curHealth);
        // }

        if(curHealth <= 0)
        {
            // Enable the pause screen ui element in canvas
            deadMenuUI.SetActive(true);

            // Freeze time in game
            Time.timeScale = 0f;

        }    

       

        if(isShieldActive)
        {
            if(curShieldHealth <= 0)
            {
                Destroy(shield);
                isShieldActive = false;
            }

            // The shield fades as it weakens
            shipShield = shield.GetComponent<Renderer>();
            Debug.Log(curShieldHealth/ maxShieldHealth);
            // shipShield.material.color.a = curShieldHealth/ maxShieldHealth;
        }


        if(curShieldHealth <= 0)
        {
            if(isShieldActive)
            {
                Destroy(shield);
                isShieldActive = false;
            }
        }    
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.relativeVelocity.magnitude > 2)
        {
            if(collision.gameObject.tag == "boundary" || collision.gameObject.tag == "asteroid1" || collision.gameObject.tag == "asteroid2" || collision.gameObject.tag == "asteroid3" || collision.gameObject.tag == "asteroid4" )
            {

                if(curShieldHealth > 0)
                {
                    curShieldHealth -= collision.relativeVelocity.magnitude * 0.1f;
                    shieldbar.SetShieldHealth(curShieldHealth);
                }
                else
                {
                    curHealth -= collision.relativeVelocity.magnitude * 0.1f;
                    healthbar.SetHealth(curHealth);
                }

            }
        }


        if(collision.gameObject.tag == "healthpowerup")
        {
            curHealth = maxHealth;
            healthbar.SetHealth(curHealth);
        }

        else if(collision.gameObject.tag == "shieldpowerup")
        {
            curShieldHealth = maxShieldHealth;
            shieldbar.SetShieldHealth(curShieldHealth);


            // Destroy the shield collectible
            Destroy(collision.gameObject);

            //Instantiate the shield prefab and assign spaceship as parent
            isShieldActive = true;
            shield = Instantiate(shieldPrefab, transform.position, Quaternion.identity);
            shield.transform.parent = gameObject.transform;

        }


    } // collision ends

}
