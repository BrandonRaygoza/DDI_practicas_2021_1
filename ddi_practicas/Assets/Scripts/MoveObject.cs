using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : Interactable
{

    private Rigidbody rb;
    public KeyCode directionKey = KeyCode.X;
    private AudioSource moveSound;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();                 //obtener referencia a la propiedad.
        moveSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();                                  //Primero ejecuta el update de la clase padre
        
    }

    public override void Interact(){

        if(directionKey == KeyCode.X){                          //se mueve en x
            rb.AddForce(transform.right*500,ForceMode.Force); 
            Debug.Log("Objeto desplazado en X");  
        }else if(directionKey == KeyCode.Y){                    //se mueve en y
            rb.AddForce(transform.up*500,ForceMode.Force);
            Debug.Log("Objeto desplazado en Y");
        }else if(directionKey == KeyCode.Z){
            rb.AddForce(transform.forward*500,ForceMode.Force); //se mueve en z
            Debug.Log("Objeto desplazado en Z");
        }

         moveSound.Play();

       
    }
}
