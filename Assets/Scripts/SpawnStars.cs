using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStars : MonoBehaviour
{

    public GameObject starPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10000; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-42f, 1250f), Random.Range(-120f, 120f));

            Instantiate(starPrefab, pos , Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
