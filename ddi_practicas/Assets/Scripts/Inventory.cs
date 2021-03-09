using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    /*Un clase single... ¿tone? es una clase de la cual solo puede existir un objecto instanceado*/
    static protected Inventory s_InventoryInstance;       
    static public Inventory InventoryInstance { get { return s_InventoryInstance; } }//para poder referenciar en otras clases

    public int tam = 10;                                    //tamaño del inventario, 10 items
    public List<Item> items = new List<Item>(); //Lista a almacenar items

    /*Invoca un evento, pero otra instancia hara el trabajo. Se hizo un tipo de dato.
    Nota: Sus suscritores (las func, o procs que se llaman cuando se dispara el evento), deben
    tener la misma definicion (si es void, si recibe parametro, etc).
    Es un callback*/
    public delegate void OnChange(); 
    public OnChange onChange;

    void Awake(){                       //Se llama una sola vez, antes del que Start() inicie
        s_InventoryInstance = this;
    }

    /*El onChange, lo va a estar escuchando InventoryUI, para que actualice sus sprites*/
    public void AddItem(Item item){                   
        if(items.Count < tam ){             //¿Hay espacio en el inventario?
            items.Add(item);    
            if(onChange != null){           //¿hay alguien escuchando el evento?
                onChange.Invoke();          //Activa el evento (trigger)
            }
                        
            Debug.Log("Item agregado");
        }else{
            Debug.Log("Inventario lleno");
        }   
    }

    public void RemoveItem(Item item){
        if(items.Contains(item)){           //Si el elemento existe dentro de la lista
            items.Remove(item);
            if(onChange != null){           //¿hay alguien escuchando el evento?
                onChange.Invoke();          //Activa el evento (trigger)
            }
            Debug.Log("Item removido");
        }else{
            Debug.Log("El item no esta dentro del inventario");
        }   
    }
}
