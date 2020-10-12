using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Interactable
{
    int coinCounter = 0;
    public float torque;
    Rigidbody rb;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddTorque(transform.up * torque * 1f);

        if(IsInsideZone && Input.GetMouseButtonDown(0))
        {
            Interact();
        }
        else
        {
            Debug.Log("");
        }
    }

    public override void Interact()
    {
        base.Interact();
        GetComponent<Renderer>().enabled = false;
        coinCounter++;
    }
}
