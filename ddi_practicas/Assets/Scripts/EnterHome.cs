using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHome : Interactable
{
    // Start is called before the first frame update
    private BoxCollider door;
    private AudioSource doorSound;

    void Start()
    {
        door = GetComponent<BoxCollider>();
        doorSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public override void Update()
    {
         base.Update();                                  //Primero ejecuta el update de la clase padre
    }

    public override void Interact(){
        if(door.isTrigger == true){
            door.isTrigger = false;
            Debug.Log("Puerta cerrada");
        }else{
            door.isTrigger = true;
            Debug.Log("Puerta abierta");
        }
        doorSound.Play();
    }
}
