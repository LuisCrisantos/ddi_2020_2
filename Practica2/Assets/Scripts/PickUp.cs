using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable
{
    private Inventory inventory;
    public Item item;
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        if(inventory == null)
        {
            Debug.LogWarning("No se encontró el inventario");
        }
    }

    public override void Interact()
    {
        Debug.Log("Tomando item");
        if(item.itemType != ItemType.Coin)
        {
            inventory.Add(item);
        }
        else
        {
            inventory.counter++;
            Debug.Log("Monedas azules: " + inventory.counter + "/4");
        }
        
        Destroy(gameObject);
    }

}
