using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonCry : Interactable
{
    private AudioSource pokemonCry;
    // Start is called before the first frame update
    void Start()
    {
        pokemonCry = GetComponent<AudioSource>();
    }

    public override void Interact(){
        pokemonCry.Play();
    }
}
