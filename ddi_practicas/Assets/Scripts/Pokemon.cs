using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PokemonType
{
    Fire, Water, Electric
}

[CreateAssetMenu(fileName = "New Pokemon", menuName="Inventory/Pokemon")]
public class Pokemon : Item
{
    public PokemonType pokemonType = PokemonType.Fire;   //referencia por default
    //public Sprite icon = null;                  Ya no se ocupa, porque eso lo hereda de Item

}


