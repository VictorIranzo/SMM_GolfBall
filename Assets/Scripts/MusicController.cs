using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour {

    public Image soundImage;

    private Animator animator;
    private AudioSource music;

    private bool isMuted;

	// Use this for initialization
	void Start () {
        music = GetComponent<AudioSource>();
        animator = soundImage.GetComponent<Animator>();
        isMuted = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetMusicState() {
        if (!isMuted)
        {
            Debug.Log("Click");
            music.Pause();
            isMuted = true;
            animator.SetBool("mute",true);
        }
        else {
            music.UnPause();
            isMuted = false;
            animator.SetTrigger("ActiveSound");
            animator.SetBool("mute", false);
        }
    }
}
