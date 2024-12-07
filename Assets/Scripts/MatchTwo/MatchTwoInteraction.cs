using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchTwoInteraction : MonoBehaviour, InteractableObj
{
    
    public void OnUse()
    {
        
        MatchTwoGameManager gameManager = FindAnyObjectByType<MatchTwoGameManager>();
        gameManager.AddPlayerChoice(gameObject);
        Debug.Log("Used MatchTwoInteraction, sending" + gameObject.name + "To" + gameManager.name);
    }
}
