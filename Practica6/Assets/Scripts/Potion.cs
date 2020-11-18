using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Inventario/Medicine/Potion")]
public class Potion : Item
{
    public int healthRec = 50;
    public string potionType = "Health";

    public override void Use()
    {
        if(String.Equals(potionType, "Health"))
        {
            Debug.Log(healthRec + " HP recovered");
        }
        else if (String.Equals(potionType, "Buff"))
        {
             Debug.Log("Defense up!");
        }
        
    }
}