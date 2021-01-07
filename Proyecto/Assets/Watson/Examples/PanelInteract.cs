using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelInteract : Interactable
{
    public float triggerInteractionTime = 1f;
    public float interactionTimer = 0f;
    public bool timerRunning = false;
    public GameObject panel;
    public List <GameObject> animals;

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
            foreach(var prefab in animals)
            {
                prefab.SetActive(false);                          

            }
        }
    }

    public override void Interact()
    {
        panel.SetActive(true);
    }

    public bool GetBool()
    {
        return timerRunning;
    }

}
