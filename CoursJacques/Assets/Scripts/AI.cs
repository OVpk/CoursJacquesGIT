using System;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class AI : MonoBehaviour
{
    public FightManager fightManager;
    public GameObject aiObject;
    public enum AIState
    {
        loosing,
        winning, 
    }

    public AIState m_currentAIState = AIState.winning;
        
    public void DetermineState(float hp)
    {
        m_currentAIState = hp < 10 ? AIState.loosing : AIState.winning;
    }
        
    public void ManageAITurn()
    {
        DetermineState(fightManager.aiLife);
        switch (m_currentAIState )
        {
            case AIState.loosing:ManageLoosing(); break;
            case AIState.winning: ManageWinning(); break;
        }   
    }

    public void ManageLoosing()
    {
        var rand = Random.Range(0, 100);
        if(rand > 50)
        {
            Heal();
        }
        else
        {
            Attack();
        }
        
        fightManager.LifeDisplayUpdate();
    }

    public void Attack()
    {
        fightManager.playerLife = fightManager.EditLife(fightManager.playerLife, -20f);
        aiObject.GetComponent<Animation>().Play("animation");
    }
    
    public void Heal()
    {
        fightManager.aiLife = fightManager.EditLife(fightManager.aiLife, +40f);
        aiObject.GetComponent<Animation>().Play("heal");
    }
    
    public void RunAway()
    {
        // IA QUITS FIGHT
    }
    
    public void ManageWinning()
    {
        Attack();
        fightManager.LifeDisplayUpdate();
    }

    public void EndTurn()
    {
        // next player
    }
    
        
}