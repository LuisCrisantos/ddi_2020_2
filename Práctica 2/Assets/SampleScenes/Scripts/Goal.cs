using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : Interactable
{
    public GameObject message;
    private bool isShowing = false;
    
    void Start()
    {
        message.SetActive(isShowing);
    }

    void FixedUpdate()
    {
        if(IsInsideZone)
        {
            Interact();
            isShowing = true;
        }
        else
        {
            Debug.Log("");
        }
    }

    public override void Interact()
    {
        base.Interact();
        message.SetActive(isShowing);
    }
}
