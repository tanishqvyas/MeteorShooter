using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mines : MonoBehaviour
{
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
        // Get the reference to the other body
        
        // Make the mine is trigger
        

        // Set the other body as parent
        gameObject.transform.SetParent (collision.gameObject.transform);

        // Expand collider radius
    }

}
