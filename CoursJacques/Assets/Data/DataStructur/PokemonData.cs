using UnityEngine;

[CreateAssetMenu]
public class PokemonData : ScriptableObject
{
    [field: Header("pokemon name"),SerializeField]
    public string pokemonName { get; private set; }
    
    [field: Header("pokemon health"),SerializeField]
    public int hp { get; private set; }
    
    [field: Header("pokemon attacks"), Space,SerializeField]
    public AttackData[] attacks { get; private set; }
    
    public PokemonDataInstance Instance()
    {
        return new PokemonDataInstance(this);
    }
}

public class PokemonDataInstance //WRAPPER
{
    public string pokemonName;
    public int hp;
    public AttackData[] attacks;

    public PokemonDataInstance(PokemonData data)
    {
        pokemonName = data.pokemonName;
        hp = data.hp;
        attacks = data.attacks;
    }
}