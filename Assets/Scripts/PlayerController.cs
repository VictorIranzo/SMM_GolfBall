using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody playerRigidBody;

    void Start() {
        // Gets the Rigidbody component of the player.
        playerRigidBody = GetComponent<Rigidbody>();
    }

	// Called before frame is rendered.
	void Update () {
		
	}

	// Called before each physics compute.
	void FixedUpdate () {
        // Record the input from the keybord for the axis.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        playerRigidBody.AddForce(movement * speed);
	}
}
