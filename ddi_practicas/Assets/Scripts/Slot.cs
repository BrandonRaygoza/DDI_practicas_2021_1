using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;
    public Image image; //referencia a la imagen 

    void Start()
    {
        
    }

    public void SetItem(Item item)
    {
        this.item = item;                       
        if(image != null){
            image.enabled = true;
            image.sprite = item.icon;           //La imagen que aparece en mi inventario, debe ser igual a la del item
        }
    }

    public void Clear()
    {
        this.item = null;
        image.enabled = false;
    }
}
