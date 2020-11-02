using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bow", menuName = "Inventario/Weapon/Bow")]
public class Bow : Item
{
    public int ammo = 10;
    public float cooldown = 0.5f;
    public string material = "Bronze";

    public override void Use()
    {
        Debug.Log("Using " + material + " Bow. Ammo: " + ammo + "/10");
    }
}
