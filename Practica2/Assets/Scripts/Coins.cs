using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Interactable
{
    public float torque;
    Rigidbody rb;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddTorque(transform.up * torque * 1f);
    }

    public override void Interact()
    {
        base.Interact();
    }
}
