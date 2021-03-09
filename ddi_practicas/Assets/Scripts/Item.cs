using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Life, Mana, Equipment, Rupias
}

/*
    ScriptableObject: 
    Es para guardar una pequeña instancia de una clase, pero guardada en forma de asset.
    Es una serialización de un "objeto" y se puede referenciar en otras partes.
    Se esta guardando pura información, no se guardan objetos.
*/
[CreateAssetMenu(fileName = "New Item", menuName="Inventory/Generic")]
public class Item : ScriptableObject
{
    public ItemType itemType = ItemType.Life;   //referencia por default
    public Sprite icon = null;                  //Icono que aparecera en el inventario

    public virtual void UseItem(){              //Metodo abstracto, para poderlo utilizar en clases hijas
        Debug.Log($"Usando item {name}");
    }
}
