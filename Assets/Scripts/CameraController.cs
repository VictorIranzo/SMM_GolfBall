using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform player;
    private Vector3 offset;
    public float speed = 0.1f;
    private static float t = 0.0f;

    private Vector3 To, From;
	
	// Runs for every frame, but when we update position of the camera we ensure that the player has moved to that frame.
	void Update () {
        To = player.position;
        From = transform.position;
        transform.position = new Vector3(Mathf.Lerp(From.x, To.x, t),0, Mathf.Lerp(From.z, To.z, t));

        t += speed * Time.deltaTime;
        float dist = Vector3.Distance(player.position, transform.position);

        if (dist < 0.2f) t = 0f;
    }
}
