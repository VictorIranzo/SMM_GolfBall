using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    // This property is set from the Unity enviroment.
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody playerRigidBody;
    private int pointsCount;

    // Reference to Rigidbody is set in this method. It is called exactly once in the lifetime of the script before any of the Update methods.
    void Start() {
        // Gets the Rigidbody component of the player.
        playerRigidBody = GetComponent<Rigidbody>();
        pointsCount = 0;
        this.SetCountText();
        winText.text = "";
    }

	// Called before frame is rendered.
	void Update () {
		
	}

	// Called before each physics compute.
	void FixedUpdate () {
        // Record the input from the keybord for the axis.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // It doesn't move up (in the y axis).
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // The vector is multiply by the speed scalar.
        playerRigidBody.AddForce(movement * speed);
	}

    // other is the object which we have collide.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            pointsCount++;
            this.SetCountText();
        }
        // Destroy(other.gameObject); This sentence destroy the objects.
    }

    void SetCountText()
    {
        countText.text = "Count: " + pointsCount.ToString();
        if (pointsCount >= 8)
        {
            winText.text = "You win!";
        }
    }
}
