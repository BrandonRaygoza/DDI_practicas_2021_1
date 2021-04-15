using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonRoarVR : Interactable
{
    public AudioSource pokemonCry;
    
    // Start is called before the first frame update
    void Start()
    {
        pokemonCry = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();                                  //Primero ejecuta el update de la clase padre
    }

    public override void Interact()
    {
        pokemonCry.Play();
    }
}
