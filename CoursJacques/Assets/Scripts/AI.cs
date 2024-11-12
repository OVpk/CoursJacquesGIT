using UnityEngine;
using Random = UnityEngine.Random;

public class AI : MonoBehaviour
{
    
    [SerializeField] private FightManager fightManager;
    
    #region DATA INITIALIZATION
    
    // Stored data
    [SerializeField] private AiComportementData aiComportementData;
    
    // modifiable data
    private AiComportementDataInstance currentAiComportementData;
    
    private void Awake()
    {
        currentAiComportementData = aiComportementData.Instance();
    }
    
    #endregion
    
    
    #region STATE-MACHINE FOR AI WINNING STATE
    
    public enum AIState
    {
        Loosing,
        Winning, 
    }

    private AIState currentAIState = AIState.Winning;

    private void DetermineState(float hp)
    {
        currentAIState = hp < currentAiComportementData.StepBeforeLoosing ? AIState.Loosing : AIState.Winning;
    }
    
    #endregion
    
    
    #region PLAY TURN OF AI IN FUNCTION OF HIS STATE
    
    public void ManageAITurn()
    {
        DetermineState(fightManager.currentAiData.hp);
        switch (currentAIState )
        {
            case AIState.Loosing:ManageLoosing(); break;
            case AIState.Winning: ManageWinning(); break;
        }   
    }

    private void ManageLoosing()
    {
        var rand = Random.Range(0, 100);
        AttackAI(rand > currentAiComportementData.PercentLoosing ? 2 : 0);
    }

    private void ManageWinning()
    {
        var rand = Random.Range(0, 100);
        AttackAI(rand > currentAiComportementData.PercentWinning ? 1 : 0);
    }
    
    #endregion
    
    
    #region ATTACK GESTION SYSTEM FOR AI

    [SerializeField] private Animation aiAnimation;
    
    private void AttackAI(int index)
    {
        switch (fightManager.currentAiData.attacks[index].target)
        {
            case AttackData.Target.Self :
                fightManager.currentAiData.hp = FightManager.EditLife(fightManager.currentAiData.hp, fightManager.currentAiData.attacks[index].power,fightManager.aiData.hp);
                fightManager.LifeDisplayUpdate("ai");
                break;
            case AttackData.Target.Other :
                fightManager.currentPlayerData.hp = FightManager.EditLife(fightManager.currentPlayerData.hp, fightManager.currentAiData.attacks[index].power,fightManager.playerData.hp);
                fightManager.LifeDisplayUpdate("player");
                break;
        }
        aiAnimation.Play(fightManager.currentAiData.attacks[index].animName);
    }
    
    #endregion
    
}