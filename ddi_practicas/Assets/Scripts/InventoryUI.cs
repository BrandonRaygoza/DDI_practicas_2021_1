using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*El script tiene que ser agregado en un elemento padre al panel, ya que si se apaga asi mismo puede causar errores
En este caso fue agregado al canvas
Arrastrar el panel dentro del inspector al script para tener la referencia al inventario */

public class InventoryUI : MonoBehaviour
{

    private Inventory _inventory;
    public GameObject inventoryPanel;
    public GameObject textInventoryPanel;
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        _inventory = Inventory.InventoryInstance;   //referencia a mi clase inventario (el que hace la logica);
        _inventory.onChange += UpdateUI;            //Cuando se dispare el evento, llama a mi procedimiento UpdateUI

        sound = GetComponent<AudioSource>();
    }

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.I)){
            inventoryPanel.SetActive(!inventoryPanel.activeSelf); //Prendido? -> Apagalo, Apagado? -> Prendelo
            textInventoryPanel.SetActive(!textInventoryPanel.activeSelf); 
            UpdateUI();                         //Para que se actulice tambien aqui
            sound.Play();
        }    
    }

    /*OJO: Para que ese proc se ejecute, el OnChange tambien tiene que ser de tipo void y no recibir parametros*/
    void UpdateUI()
    {
        Slot[] slots = GetComponentsInChildren<Slot>(); //Regresa un arreglo de todos los elementos Slot hijos encontrados.
        for(int i = 0; i < slots.Length; i++){
            if( i < _inventory.items.Count){                //¿Hay slots disponibles?
                slots[i].SetItem(_inventory.items[i]);      //Para cada slot, se le asigna el elemento en el inventario (los que se han agregado)
            }else{
                slots[i].Clear();
            }
        }

        Debug.Log("Sprite en inventario, actualizado");
    }

}
