using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryUIPanel;
    private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        if(inventory == null)
        {
            return;
        }
        inventoryUIPanel.SetActive(false);
        inventory.onChange += UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        if(CrossPlatformInputManager.GetButtonDown("Fire2"))
        {
            inventoryUIPanel.SetActive(!inventoryUIPanel.activeSelf);
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        int i;
        Slots[] slots = GetComponentsInChildren<Slots>();
        for(i=0; i<slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].SetItem(inventory.items[i]);    
            }
            else
            {
                slots[i].Clear();
            }
        }
    }
}
