using UnityEngine;

[CreateAssetMenu]
public class AttackData : ScriptableObject
{
    [field: Header("attack name"),SerializeField]
    public string attackName { get; private set; }
    
    [field: Header("power of the attack"),SerializeField]
    public int power { get; private set; }
    
    public enum Target
    {
        Self,
        Other
    }

    [field: Header("target of the attack"),SerializeField]
    public Target target { get; private set; }

    [field: Header("name of the animation play during attack"),SerializeField]
    public string animName { get; private set; }
    
}