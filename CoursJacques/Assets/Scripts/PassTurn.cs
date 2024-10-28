using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PassTurn : MonoBehaviour
{
    public AI aiScript;
    public FightManager fightManager;

    public GameObject text;
    
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
        if (fightManager.playerLife == 0)
        {
            text.GetComponent<TMP_Text>().text = "PERDU";
        }
        if (fightManager.aiLife == 0)
        {
            text.GetComponent<TMP_Text>().text = "GAGNE";
        }
        else
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
}
