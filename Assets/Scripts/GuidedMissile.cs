using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(Rigidbody2D))]
public class GuidedMissile : MonoBehaviour
{

    [HideInInspector]
    public Transform target;
    public float missileSpeed = 1f;
    public float rotateSpeed = 2f;
    private Rigidbody2D rb;

    public string[] targetNames;

    public GameObject missileExplosionEffect;

    // Start is called before the first frame update
    void Start()
    {   
        for (int i = 0; i < targetNames.Length; i++)
        {            
            try
            {
                target = GameObject.FindWithTag(targetNames[i]).transform;
            }
            catch (NullReferenceException ex)
            {   Debug.Log(ex);
                Debug.Log("Not found : "+targetNames[i]);    
            }
                        
            if(target == null)
            {
                continue;
            }
            
            else
            {
                rb = GetComponent<Rigidbody2D>();
                break;
            }
        }
        // target = GameObject.FindWithTag("Player").transform;


        if(target == null)
        {
            Destroy(gameObject,1f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get vector pointing from missile to player
        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, -transform.right).z;

        rb.angularVelocity = rotateAmount * rotateSpeed;

        rb.velocity = transform.right * missileSpeed;
    }


    void OnTriggerEnter2D(Collider2D other)
    {   if(other.tag != "Player")
        {
            GameObject effect = Instantiate(missileExplosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
            Destroy(effect,0.2f);

        }
    }
}
