using UnityEngine;

[CreateAssetMenu]
public class Attack : ScriptableObject
{
    public string attackName;
    public int power;
    public enum Target
    {
        Self,
        Other
    }

    public Target target;

    public string animName;
    
    
}