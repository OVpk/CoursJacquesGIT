using UnityEngine;

[CreateAssetMenu]
public class PokemonData : ScriptableObject
{
    [field: Header("pokemon name"),SerializeField]
    public string pokemonName { get; private set; }
    
    [field: Header("pokemon health"),SerializeField]
    public int hp { get; private set; }
    
    [field: Header("pokemon attacks"), Space,SerializeField]
    public Attack[] attacks { get; private set; }
    
    public PokemonDataInstance Instance()
    {
        return new PokemonDataInstance(this);
    }
}

public class PokemonDataInstance
{
    public string pokemonName;
    public int hp;
    public Attack[] attacks;

    public PokemonDataInstance(PokemonData data)
    {
        pokemonName = data.pokemonName;
        hp = data.hp;
        attacks = data.attacks;
    }
}