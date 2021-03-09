using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName="Inventory/Rupia")]

public class Rupia : Item
{
    public float rupia = 1.0f;

    public override void UseItem(){
        base.UseItem();
        Debug.Log($"Se aumento la cantidad de rupias del personaje: {rupia}%");
    }
}
