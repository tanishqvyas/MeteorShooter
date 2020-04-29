using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class GuidedMissile : MonoBehaviour
{

    [HideInInspector]
    public Transform target;
    public float missileSpeed = 1f;
    public float rotateSpeed = 2f;
    private Rigidbody2D rb;

    public GameObject missileExplosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
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


    void OnTriggerEnter2D()
    {
        GameObject effect = Instantiate(missileExplosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(effect,0.2f);
    }
}
