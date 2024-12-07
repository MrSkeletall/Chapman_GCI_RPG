using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ObjectSwapInteraction : MonoBehaviour, InteractableObj
{
    
    

    public GameObject replacementObject;

    public void OnUse()
    {
        replacementObject.SetActive(true);
        
        gameObject.SetActive(false);
        
    }
    
    
}
