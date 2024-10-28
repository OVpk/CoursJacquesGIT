using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour
{
    
    public GameObject textCurrent;

    public bool canPlay = true;
    
    public enum Turn
    {
        Player,
        AI
    }

    public Turn currentTurn = Turn.Player;
    
    public void ChangeTurn()
    {
        canPlay = true;
        currentTurn = currentTurn == Turn.Player ? Turn.AI : Turn.Player;
        textCurrent.GetComponent<TMP_Text>().text = currentTurn.ToString();
    }

    private void Start()
    {
        textCurrent.GetComponent<TMP_Text>().text = currentTurn.ToString();
    }
    
    public float playerLife = 100;
    public float aiLife = 100;
    public float maxLife = 100;

    public float EditLife(float currentLife, float addedNumber)
    {
        currentLife += addedNumber;
        if (currentLife > maxLife)
        {
            currentLife = maxLife;
        }
        else if (currentLife < 0)
        {
            currentLife = 0;
        }

        return currentLife;
    }
    
    public Image playerLifeBarImage;
    public Image aiLifeBarImage;

    public void LifeDisplayUpdate()
    {
        playerLifeBarImage.fillAmount = playerLife / maxLife;
        aiLifeBarImage.fillAmount = aiLife / maxLife;
    }

    public GameObject playerObject;
    
    public void Attaquer()
    {
        if (currentTurn == Turn.Player && canPlay)
        {
            canPlay = false;
            aiLife = EditLife(aiLife, -20f);
            playerObject.GetComponent<Animation>().Play("animation");
            LifeDisplayUpdate();
        }
    }

    public void Soigner()
    {
        if (currentTurn == Turn.Player && canPlay)
        {
            canPlay = false;
            playerLife = EditLife(playerLife, +40f);
            playerObject.GetComponent<Animation>().Play("heal");
            LifeDisplayUpdate();
        }
        
    }
    
    
    
    
    
    
}
