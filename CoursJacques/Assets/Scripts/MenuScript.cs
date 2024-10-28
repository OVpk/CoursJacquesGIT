using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public GameManager gameManager;

    public void ClickOnPlay()
    {
        switch (gameManager.m_currentGameState)
        {
            case GameManager.GameState.Menu: gameManager.ChangeCurrentState(GameManager.GameState.Game); break;
            case GameManager.GameState.Game: gameManager.ChangeCurrentState(GameManager.GameState.Menu); break;
        }
    }
    

}
