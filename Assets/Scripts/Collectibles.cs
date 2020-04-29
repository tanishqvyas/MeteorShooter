using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectibles : MonoBehaviour
{

    [HideInInspector]
    public GameObject shield;

    //Inspector variables
    public GameObject shieldPrefab;
   
    [HideInInspector]
    public float shieldLife = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shieldLife <= 0)
        {

        }

        // set healthbar
    }


    // Manage Collectibles and collision damage
    void OnCollisionEnter2D(Collision2D collision)
    {

        // MANAGE DAMAGE BY OVER SPEEDING AND HITTING


        // MANAGE COLLECTIBLES
        if(collision.gameObject.tag == "shieldpowerup")
        {   
            // Destroy the shield collectible
            Destroy(collision.gameObject);

            //Instantiate the shield prefab and assign spaceship as parent
            shield = Instantiate(shieldPrefab, transform.position, Quaternion.identity);
            shield.transform.parent = gameObject.transform;

            shieldLife = 50f;
            Debug.Log(shieldLife);
        }

        else if(collision.gameObject.tag == "fuel")
        {
            // write code for refueling here
        }

        else if(collision.gameObject.tag == "healthpack")
        {
            // write code to increase heal here
        }

    }
}
