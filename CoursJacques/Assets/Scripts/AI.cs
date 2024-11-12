using UnityEngine;
using Random = UnityEngine.Random;

public class AI : MonoBehaviour
{
    
    public FightManager fightManager;
    
    
    #region DATA INITIALIZATION
    
    // Stored data
    public AiComportementData aiComportementData;
    
    // modifiable data
    public AiComportementDataInstance currentAiComportementData;
    public void Awake()
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

    public AIState currentAIState = AIState.Winning;
        
    public void DetermineState(float hp)
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

    public void ManageLoosing()
    {
        var rand = Random.Range(0, 100);
        AttackAI(rand > currentAiComportementData.PercentLoosing ? 2 : 0);
    }
    
    public void ManageWinning()
    {
        var rand = Random.Range(0, 100);
        AttackAI(rand > currentAiComportementData.PercentWinning ? 1 : 0);
    }
    
    #endregion
    
    
    #region ATTACK GESTION SYSTEM FOR AI

    public Animation aiAnimation;
    
    private void AttackAI(int index)
    {
        switch (fightManager.currentAiData.attacks[index].target)
        {
            case Attack.Target.Self :
                fightManager.currentAiData.hp = fightManager.EditLife(fightManager.currentAiData.hp, fightManager.currentAiData.attacks[index].power,fightManager.aiData.hp);
                fightManager.LifeDisplayUpdate("ai");
                break;
            case Attack.Target.Other :
                fightManager.currentPlayerData.hp = fightManager.EditLife(fightManager.currentPlayerData.hp, fightManager.currentAiData.attacks[index].power,fightManager.playerData.hp);
                fightManager.LifeDisplayUpdate("player");
                break;
        }
        aiAnimation.Play(fightManager.currentAiData.attacks[index].animName);
    }
    
    #endregion
    
}