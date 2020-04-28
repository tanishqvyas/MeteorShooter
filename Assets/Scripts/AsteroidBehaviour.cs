using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    public float lifeCount = 3f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {   
            lifeCount--;
        }

        if(lifeCount == 0)
        {
            Destroy(gameObject);
        }
    }
}
