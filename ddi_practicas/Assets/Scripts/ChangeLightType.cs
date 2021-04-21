using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightType : Interactable
{
    public Light _ligth;
    //Random rand = new Random();
    ArrayList colors = new ArrayList();
    
    public override void Interact()
    {   
        //_ligth.enabled = !_ligth.enabled;+
        colors.Add(Color.blue);
        colors.Add(Color.red);
        colors.Add(Color.clear);
        colors.Add(Color.white);
        colors.Add(Color.yellow);
        
        int value = Random.Range(0,4);
        _ligth.color = (Color)colors[value];  
         
    }
}