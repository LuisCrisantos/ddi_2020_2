using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable
{
    //private Inventory inventory;
    public Item item;
    void Start()
    {
       /* inventory = FindObjectOfType<Inventory>();
        if(inventory == null)
        {
            Debug.LogWarning("No se encontró el inventario");
        }*/
    }

    public override void Interact()
    {
        if(item.itemType != ItemType.Coin)
        {
            //inventory.Add(item);
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
            //inventory.counter++;
            Debug.Log("Tomando item");
            Debug.Log("Monedas azules + 1 ");
        }
        
        Destroy(gameObject);
    }

}
