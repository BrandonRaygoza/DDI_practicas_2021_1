using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public bool inZone = false;
    public KeyCode interactionKey = KeyCode.P;

    public virtual void Update(){
        if(inZone && Input.GetKeyDown(interactionKey)){
            Interact();
        }
    }

    void OnTriggerEnter(Collider other){  //Es un collider que entre dentro del area de la esfera.
        if(!other.CompareTag("Player")){
            return;
        }else{
            inZone = true;
            Debug.Log("Entro en el area");
        }
    }

    void OnTriggerExit(Collider other){
        if(!other.CompareTag("Player")){
            return;
        }else{
            inZone = false;
            Debug.Log("Se salio del area");
        }
    }

    public virtual void Interact(){ //puede estar vacio, pero en otras clases se puede extender

    }
}
