using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName="Inventory/Life")]

public class Life : Item
{
    public float lifePoints = 5.0f;

    public override void UseItem(){
        base.UseItem();
        Debug.Log($"Se aumentaron los L.P del personaje: {lifePoints}%");
    }
}
