using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;

public class ButtonController : MonoBehaviour, IPointerClickHandler { 
    public Animator animator;
    private int counter = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        counter++;
        if (counter == 10)
        {
            counter = 0;
            animator.SetTrigger("Live");
        }
    }
}
