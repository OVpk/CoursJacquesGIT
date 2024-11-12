using TMPro;
using UnityEngine;

public class PassTurn : MonoBehaviour
{
    public AI aiScript;
    public FightManager fightManager;
    

    #region ATTACK EVENT SYSTEM
    
    //THIS FUNCTION IS CALL AT THE END OF ATTACK ANIM (with event), AND SWITCH THE TURN IF NOBODY HAVE WIN
    
    public TMP_Text endGameText;
    
    public void SwitchTurn()
    {
        if (fightManager.currentPlayerData.hp == 0)
        {
            endGameText.text = "PERDU";
        }
        else if (fightManager.currentAiData.hp == 0)
        {
            endGameText.text = "GAGNE";
        }
        else
        {
            fightManager.ChangeTurn();
            switch (fightManager.currentTurn)
            {
                case FightManager.Turn.AI : aiScript.ManageAITurn(); break;
            }
        }
    }   

    #endregion
    
}
