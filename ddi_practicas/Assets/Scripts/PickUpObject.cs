using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*Clase que añade un objeto al inventario*/
public class PickUpObject : Interactable
{
    public Item item; //Referencia al ScriptableObject que existe en los assets del proyecto  

    public override void Interact(){
       
        //Cuando entre en el area (ya que hereda Interact de Interactable) agregara
        //la referencia del objeto al inventario.
        //Referencia al inventario.
        Inventory.InventoryInstance.AddItem(item);
        Destroy(this.gameObject); //Se el objecto, pero no la informacion
    }
}
