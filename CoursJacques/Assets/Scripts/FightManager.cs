using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour
{

    #region DATA INITIALIZATION
    
    // Stored data
    public PokemonData playerData;
    public PokemonData aiData;
    
    // modifiable data
    public PokemonDataInstance currentPlayerData { get; private set; }
    public PokemonDataInstance currentAiData { get; private set; }
    
    private void Awake()
    {
        currentPlayerData = playerData.Instance();
        currentAiData = aiData.Instance();
    }
    
    #endregion
    
    
    #region TEXT IN SCENE INITIALIZATION
    
    [SerializeField] private TMP_Text currentTurnText;
    
    [SerializeField] private TMP_Text attack1Name;
    [SerializeField] private TMP_Text attack2Name;
    [SerializeField] private TMP_Text attack3Name;
    
    private void Start()
    {
        currentTurnText.text = currentTurn.ToString();

        attack1Name.text = currentPlayerData.attacks[0].attackName;
        attack2Name.text = currentPlayerData.attacks[1].attackName;
        attack3Name.text = currentPlayerData.attacks[2].attackName;
    }
    
    #endregion
    

    #region TURN GESTION WITH STATE-MACHINE
    
    private bool canPlay = true;
    
    public enum Turn
    {
        Player,
        AI
    }

    public Turn currentTurn { get; private set; }= Turn.Player;
    
    public void ChangeTurn()
    {
        canPlay = true;
        currentTurn = currentTurn == Turn.Player ? Turn.AI : Turn.Player;
        currentTurnText.text = currentTurn.ToString();
    }

    #endregion
    

    #region LIFE SYSTEM
    
    [SerializeField] private Image playerLifeBarImage;
    [SerializeField] private Image aiLifeBarImage;

    public void LifeDisplayUpdate(string target)
    {
        switch (target)
        {
            case "player" : playerLifeBarImage.fillAmount = (float)currentPlayerData.hp / playerData.hp; break;
            case "ai" : aiLifeBarImage.fillAmount = (float)currentAiData.hp / aiData.hp; break;
        }
    }
    
    public static int EditLife(int currentLife, int addedNumber, int maxLife)
    {
        currentLife += addedNumber;
        return Math.Clamp(currentLife, 0, maxLife);
    }

    #endregion
    

    #region ATTACK GESTION SYSTEM

    [SerializeField] private Animation playerAnimation;

    private void Attack(int index)
    {
        if (currentTurn == Turn.Player && canPlay)
        {
            canPlay = false;
            switch (currentPlayerData.attacks[index].target)
            {
                case AttackData.Target.Self : currentPlayerData.hp =
                        EditLife(currentPlayerData.hp, currentPlayerData.attacks[index].power,playerData.hp);
                        LifeDisplayUpdate("player");
                    break;
                case AttackData.Target.Other : currentAiData.hp =
                        EditLife(currentAiData.hp, currentPlayerData.attacks[index].power,aiData.hp);
                        LifeDisplayUpdate("ai");
                    break;
            }
            playerAnimation.Play(currentPlayerData.attacks[index].animName);
        }
    }

    private void Attack1Button()
    {
        Attack(0);
    }
    private void Attack2Button()
    {
        Attack(1);
    }
    private void Attack3Button()
    {
        Attack(2);
    }
    
    #endregion

}
