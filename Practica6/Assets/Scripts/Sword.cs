using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sword", menuName = "Inventario/Weapon/Sword")]
public class Sword : Item
{
    public int uses = 3;
    public float sharpeness = 1.5f;
    public string material = "Copper";

    public override void Use()
    {
        Debug.Log("Using " + material + " Sword, HYAAAAA!");
    }
}
