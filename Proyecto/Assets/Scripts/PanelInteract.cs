using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelInteract : Interactable
{
    public float triggerInteractionTime = 1f;
    public float interactionTimer = 0f;
    private bool timerRunning = false;
    public GameObject panel;

    void Update()
        {
            if(timerRunning)
            {
                interactionTimer += Time.deltaTime;
                if(interactionTimer >= triggerInteractionTime)
                {
                    Interact();
                }
            }
        }

    public void SetGazedAt(bool gazedAt)
    {
        if(gazedAt)
        {
           timerRunning = true;
        }
        else
        {
            timerRunning = false;
            interactionTimer = 0f;
            panel.SetActive(false);
        }
    }

    public override void Interact()
    {
        panel.SetActive(true);
    }
}
