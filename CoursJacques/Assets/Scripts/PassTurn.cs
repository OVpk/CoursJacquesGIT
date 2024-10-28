using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassTurn : MonoBehaviour
{
    public AI aiScript;
    public FightManager fightManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pass()
    {
        switch (fightManager.currentTurn)
        {
            case FightManager.Turn.AI : fightManager.ChangeTurn(); break;
            case FightManager.Turn.Player : fightManager.ChangeTurn(); break;
        }
        switch (fightManager.currentTurn)
        {
            case FightManager.Turn.AI : aiScript.ManageAITurn(); break;
        }
        
    }
}
