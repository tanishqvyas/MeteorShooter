using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStars : MonoBehaviour
{

    public GameObject starPrefab;
    public GameObject asteroid4;
    public GameObject asteroid3;
    public GameObject asteroid2;
    public GameObject asteroid1;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10000; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-42f, 850f), Random.Range(-120f, 120f));

            Instantiate(starPrefab, pos , Quaternion.identity);
        }

        for (int i = 0; i < 10; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-42f, 850f), Random.Range(-120f, 120f));

            Instantiate(asteroid4, pos , Quaternion.identity);
        }

        for (int i = 0; i < 20; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-42f, 850f), Random.Range(-120f, 120f));

            Instantiate(asteroid3, pos , Quaternion.identity);
        }

        for (int i = 0; i < 50; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-42f, 850f), Random.Range(-120f, 120f));

            Instantiate(asteroid2, pos , Quaternion.identity);
        }

        for (int i = 0; i < 500; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-42f, 850f), Random.Range(-120f, 120f));

            Instantiate(asteroid1, pos , Quaternion.identity);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
