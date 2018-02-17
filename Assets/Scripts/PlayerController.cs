﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    // This property is set from the Unity enviroment.
    public float speed;
    public Text coinsText;
    public Text winText;
    public Text pointsText;

    private Rigidbody playerRigidBody;
    private int coinsCount;
    private int pointsCount;

    // Reference to Rigidbody is set in this method. It is called exactly once in the lifetime of the script before any of the Update methods.
    void Start() {
        // Gets the Rigidbody component of the player.
        playerRigidBody = GetComponent<Rigidbody>();
        coinsCount = 0;
        pointsCount = 0;
        this.SetCountText();
        this.SetPointText();
        winText.text = "";
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
            coinsCount++;
            this.SetCountText();
            this.IncreasePoints();
        }
        if (other.gameObject.CompareTag("Fall plane"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        // Destroy(other.gameObject); This sentence destroy the objects.
    }

    void SetCountText()
    {
        coinsText.text = coinsCount.ToString();
        if (coinsCount >= 12)
        {
            winText.text = "You win!";
        }
    }

    void IncreasePoints()
    {
        // We add to the points the time when the coin is caught rounded to the decimal part. 
        // For example, if a coins is collected in the time 48, 50 points will be added.
        pointsCount += (int)Math.Round(((double)CounterScript.counter)/10) *10;
        SetPointText();
    }

    void SetPointText()
    {
        pointsText.text = pointsCount.ToString();
    }
}
