using TMPro;
using UnityEngine;

public class PassTurn : MonoBehaviour
{
    [SerializeField] private AI aiScript;
    [SerializeField] private FightManager fightManager;
    

    #region ATTACK EVENT SYSTEM
    
    //THIS FUNCTION IS CALL AT THE END OF ATTACK ANIM (with event), AND SWITCH THE TURN IF NOBODY HAVE WIN
    
    [SerializeField] private TMP_Text endGameText;
    
    private void SwitchTurn()
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
