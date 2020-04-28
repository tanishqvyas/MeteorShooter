using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    public float lifeCount = 3f;
    public GameObject destroyEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {   
            lifeCount--;
        }

        if(lifeCount == 0)
        {
            GameObject effect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject);

        }
    }
}
