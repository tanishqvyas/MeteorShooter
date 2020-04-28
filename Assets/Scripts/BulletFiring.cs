using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFiring : MonoBehaviour
{

    public Transform firepoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;


    // Update is called once per frame
    void Update()
    {

        // Get vector pos of gun point
        // gunpointPos = gunpoint.transform.position;

        // Subtract spaceship position vector from this to get direction vector of gun wrt ship
        // Vector math bitch!!
        // fireDirection = gunpointPos - rigidBody.position;
        // float angle = Mathf.Atan2(fireDirection.y, fireDirection.x) * Mathf.Rad2Deg- 90f;

        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }


    void Shoot()
    {
        // Instantiate bullet
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firepoint.up * bulletForce,ForceMode2D.Impulse);

    }
}
