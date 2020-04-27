using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

	// Movement variables
	public float move_speed = 10f;
	public float rotation_angle = 10f;
	public float max_speed = 10f;

	// Smoke
	public ParticleSystem thrustSmoke;

	private float rotate = 0f;
	private float move = 0f;
	private Rigidbody2D rigidBody; 


    // Start is called before the first frame update
    void Start()
    {
     	rigidBody = GetComponent<Rigidbody2D>();
     	thrustSmoke.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        

    	// Get Movement Inputs
    	rotate = Input.GetAxis("Horizontal");
    	move = Input.GetAxis("Vertical");

    	// Rotation Control
    	if(rotate > 0)
    	{
    		rigidBody.rotation = rigidBody.rotation - (rotate*rotation_angle);
    	}
    	else if(rotate < 0)
    	{
    		rigidBody.rotation = rigidBody.rotation - (rotate*rotation_angle);    		
    	}

    	// Forward movement control
    	if(move > 0)
    	{
	    	ThrustForce(move_speed * move);
	    	ClampVelocity();
    	}

    	// Control the smoke playing with key press
    	if(Input.GetKeyDown(KeyCode.W))
    	{
        	thrustSmoke.Play();
     	}

    	if(Input.GetKeyUp(KeyCode.W))
    	{
        	 thrustSmoke.Stop();
     	}

       
    }

    private void ClampVelocity()
    {
    	float x = Mathf.Clamp(rigidBody.velocity.x, -max_speed, max_speed);
    	float y = Mathf.Clamp(rigidBody.velocity.y, -max_speed, max_speed);

    	rigidBody.velocity = new Vector2(x, y);    	
    }

    private void ThrustForce(float amount)
    {
    	Vector2 force = transform.up * amount;
    	rigidBody.AddForce(force);
    }


    
}
