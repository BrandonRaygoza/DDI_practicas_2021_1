using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjectVR : Interactable
{
    public Item item;       //Referencia al ScriptableObject que existe en los assets del proyecto  
    public GameObject wea;  //Referencia al objeto a desaparecer

    public override void Interact(){
       
        //Cuando entre en el area (ya que hereda Interact de Interactable) agregara
        //la referencia del objeto al inventario.
        //Referencia al inventario.
        Inventory.InventoryInstance.AddItem(item);
        //Destroy(wea); //Se el objecto, pero no la informacion
        wea.SetActive(false);
    }
}
