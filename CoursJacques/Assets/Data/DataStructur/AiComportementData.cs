using UnityEngine;

[CreateAssetMenu]
public class AiComportementData : ScriptableObject
{
    [field: Header("Life step for pass in loosing state"),SerializeField]
    public int StepBeforeLoosing { get; private set; }
    
    [field: Header("Percent of chance to do attack 1 while loosing"),SerializeField]
    public int PercentLoosing { get; private set; }
    
    [field: Header("Percent of chance to do attack 1 while winning"),SerializeField]
    public int PercentWinning { get; private set; }
    
    public AiComportementDataInstance Instance()
    {
        return new AiComportementDataInstance(this);
    }
}

public class AiComportementDataInstance
{
    public int StepBeforeLoosing;
    public int PercentLoosing;
    public int PercentWinning;

    public AiComportementDataInstance(AiComportementData data)
    {
        StepBeforeLoosing = data.StepBeforeLoosing;
        PercentLoosing = data.PercentLoosing;
        PercentWinning = data.PercentWinning;
    }
}
