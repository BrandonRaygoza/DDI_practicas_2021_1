using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Vb_sword_guy : MonoBehaviour, IVirtualButtonEventHandler
{
    VirtualButtonBehaviour[] vbs;
    public Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for(int i = 0; i<vbs.Length; i++){
            vbs[i].RegisterEventHandler(this);
        }
        _animator.SetBool("Walk",false);
        _animator.SetBool("Attack",false);
    }

    /*Métodos necesarios para que funcione la interfaz (IVirtualButtonEventHandler)*/
    public void OnButtonPressed(VirtualButtonBehaviour vb){
       if(vb.VirtualButtonName == "vb_walk"){
           if(_animator.GetBool("Attack")){
               _animator.SetBool("Attack",false);
           }
           _animator.SetBool("Walk",true);
       }else if(vb.VirtualButtonName == "vb_attack"){
           if(_animator.GetBool("Walk")){
               _animator.SetBool("Walk",false);
           }
           _animator.SetBool("Attack",true);
       }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb){

    }
}
