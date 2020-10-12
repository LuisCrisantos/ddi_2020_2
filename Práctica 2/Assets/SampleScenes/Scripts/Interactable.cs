using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool IsInsideZone;

    public virtual void Interact()
    {
        Debug.Log("Ejecutando Interacción...");
    }

    void Update()
    {
        if(IsInsideZone && Input.GetMouseButtonDown(0))
        {
            Interact();
        }
        if(!IsInsideZone)
        {
            Debug.Log("");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            return;
        }
        IsInsideZone = true;
    }

    void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            return;
        }
        IsInsideZone = false;
    }
}
