using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject game;
    
    public enum GameState
    {
        Menu = 0,
        Game = 1
    }

    public GameState m_currentGameState { get; private set; }= GameState.Menu;

    public void ChangeCurrentState(GameState newGameState)
    {
        switch (m_currentGameState)
        {
            case GameState.Menu: DisableMenu();break;
            case GameState.Game: DisableGame();break;
        }

        m_currentGameState = newGameState;
        
        switch (m_currentGameState)
        {
            case GameState.Menu: SetUpMenu();break;
            case GameState.Game: SetUpGame();break;
        }
        
    }

    public void SetUpGame()
    {
        game.SetActive(true);
    }
    
    public void SetUpMenu()
    {
        menu.SetActive(true);
    }

    public void DisableMenu()
    {
        menu.SetActive(false);
    }
    
    public void DisableGame()
    {
        game.SetActive(false);
    }
    
    
    
    
}
