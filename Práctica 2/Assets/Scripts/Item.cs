using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    MeleeWeapon,
    RangedWeapon,
    Equip,
    Medicine,
    BuffMedicine,
    Coin
}
[CreateAssetMenu(fileName = "Nuevo Item", menuName = "Inventario/Generic")]
public class Item : ScriptableObject
{
    public Sprite icon = null;
    public ItemType itemType = ItemType.RangedWeapon;
    public virtual void Use()
    {
       Debug.Log("Usando item:" + name);
    }

}
