using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public enum Turn
    {
        Player = 0,
        AI = 1
    }

    public Turn currentTurn = Turn.Player;
    public void ChangeTurn()
    {
        
    }
}
