using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Runs for every frame, but when we update position of the camera we ensure that the player has moved to that frame.
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
