using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

	public GameObject SpaceShip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	// Change camera's coordinates as per that os the ship
    	transform.position = new Vector3(SpaceShip.transform.position.x, SpaceShip.transform.position.y, transform.position.z );
    }
}
