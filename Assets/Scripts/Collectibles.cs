using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public float life = 100f;
    
    [HideInInspector]
    public float shieldLife = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        // MANAGE DAMAGE BY OVER SPEEDING AND HITTING


        // MANAGE COLLECTIBLES
        if(collision.gameObject.tag == "shieldpowerup")
        {   
            // write code for shield here
            Destroy(collision.gameObject);
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
