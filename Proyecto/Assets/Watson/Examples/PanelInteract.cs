using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelInteract : Interactable
{
    public float triggerInteractionTime = 1f;
    public float interactionTimer = 0f;
    public bool timerRunning = false;
    public List<GameObject> panels;
    public List <GameObject> animals;
    public GameObject animal;

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
            foreach(var panel in panels)
            {
                panel.SetActive(false);
            }
            foreach(var prefab in animals)
            {
                prefab.SetActive(false);                          
            }
        }
    }

    public override void Interact()
    {
        foreach(var panel in panels)
            {
                if(animal.name == panel.name)
                {
                    panel.SetActive(true);
                }
            }
    }

    public bool GetBool()
    {
        return timerRunning;
    }

}
