using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable
{
    //private Inventory inventory;
    public Item item;
    public float triggerInteractionTime = 1f;
    public float interactionTimer = 0f;
    private bool timerRunning = false;

    void Update()
        {
            if(timerRunning)
            {
                interactionTimer += Time.deltaTime;
                if(interactionTimer > triggerInteractionTime)
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
        }
    }

    public override void Interact()
    {
        if(item.itemType != ItemType.Coin)
        {
            if(item.itemType == ItemType.RangedWeapon)
            {
                Debug.Log("Using Bow. Bows are superefective against flying units!");
            }
            else
            if(item.itemType == ItemType.MeleeWeapon)
            {
                Debug.Log("Using Sword. Swords are weak against Lances and strong against Axes!");
            }
            else
            if(item.itemType == ItemType.Medicine)
            {
                Debug.Log("Tomando item");
                Debug.Log("Using Medicine. 20 HP recovered!");
            }
            else
            if(item.itemType == ItemType.BuffMedicine)
            {
                Debug.Log("Tomando item");
                Debug.Log("Using Buff Potion. You can feel your Defense increasing!");
            }

        }
        else
        {
            Debug.Log("Tomando item");
            Debug.Log("Monedas azules + 1 ");
        }
        
        Destroy(gameObject);
    }

}
