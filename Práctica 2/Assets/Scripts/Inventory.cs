﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnChange();
    public OnChange onChange;

    public int space = 23;
    public int counter = 0;
    public List <Item> items = new List <Item>();

    public void Add(Item item)
    {
        if(items.Count < space)
        {
            items.Add(item);
            if(onChange != null)
            {
                onChange.Invoke();
            }
        }
        else
        {
            Debug.LogWarning("Inventario lleno");
        }

    }

    public void Remove(Item item)
    {
        if(items.Contains(item))
        {
            items.Remove(item);
            if(onChange != null)
            {
                onChange.Invoke();
            }
        }
        else
        {
            Debug.LogWarning("Item no está en el inventario");
        }
    }
}
