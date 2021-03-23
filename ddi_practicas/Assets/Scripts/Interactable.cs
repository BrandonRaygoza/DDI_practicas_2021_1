using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Interactable : MonoBehaviour
{

    public bool inZone = false;
    //public KeyCode interactionKey = KeyCode.P;
    public string interactionButton = "Interact"; //Como lo nombre en el InputManager
    public GameObject interactionButtonUI;

    public virtual void Update(){
        //if(inZone && Input.GetKeyDown(interactionKey)){
        if(inZone && CrossPlatformInputManager.GetButtonDown(interactionButton)){
            Interact();
        }
    }

    void OnTriggerEnter(Collider other){  //Es un collider que entre dentro del area de la esfera.
        if(!other.CompareTag("Player")){
            return;
        }else{
            inZone = true;
            Debug.Log("Entro en el area");
            interactionButtonUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other){
        if(!other.CompareTag("Player")){
            return;
        }else{
            inZone = false;
            Debug.Log("Se salio del area");
            interactionButtonUI.SetActive(false);
        }
    }

    void OnMouseDown() {
        Interact();
    }

    public virtual void Interact(){ //puede estar vacio, pero en otras clases se puede extender

    }
}
