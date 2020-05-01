using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    public float lifeCount = 3f;
    public GameObject destroyEffect;

    //Asteroids
    public GameObject nextAsteroid;
   
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {   
            lifeCount--;
        }

        if(lifeCount == 0)
        {   
            // Get the name
            string asteroidName = gameObject.tag;

            Debug.Log(asteroidName);
            
            // Destroy the current asteroid
            Destroy(gameObject);
            
            if(asteroidName != "asteroid1")
            {
                for (int i = 0; i < 3; i++)
                {
                    GameObject temp = Instantiate(nextAsteroid, transform.position, Quaternion.identity);
                    if(Random.Range(-2f,2f) > 0)
                        temp.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * Random.Range(1f,20f) * Random.Range(-2f, 2f),ForceMode2D.Impulse);
                    else
                        temp.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * Random.Range(1f,20f) * Random.Range(-2f, 2f),ForceMode2D.Impulse);
                }
            }

            else
            {
                GameObject effect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
                Destroy(effect, 1f);
            }



        }
    }
}
