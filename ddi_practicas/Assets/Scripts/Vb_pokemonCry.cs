using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Vb_pokemonCry : MonoBehaviour, IVirtualButtonEventHandler
{
    VirtualButtonBehaviour[] vbs;
    public GameObject charizard;
    public GameObject charizard_x;
    private AudioSource cry;

    // Start is called before the first frame update
    void Start()
    {
        vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for(int i = 0; i<vbs.Length; i++){
            vbs[i].RegisterEventHandler(this);
        }

        cry = GetComponent<AudioSource>();

        charizard_x.SetActive(false);
    }

    /*Métodos necesarios para que funcione la interfaz (IVirtualButtonEventHandler)*/
    public void OnButtonPressed(VirtualButtonBehaviour vb){
        if(vb.VirtualButtonName == "vb_changeCharizard"){
            charizard.SetActive(!charizard.activeSelf);
            charizard_x.SetActive(!charizard_x.activeSelf);
            cry.Play();
        }
        else if(vb.VirtualButtonName == "vb_charizardCry"){
            cry.Play();
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb){

    }

    

}
