using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IPointerClickHandler { 
    public Animator animator;
    public Text liveText;
    private int counter = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        counter++;
        if (counter == 10)
        {
            counter = 0;
            animator.SetTrigger("Live");
        }
        int lives;
        int.TryParse(liveText.text, out lives);
        if (lives>0) {
            liveText.text = (lives - 1).ToString();
        }
    }
}
