using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteraction : MonoBehaviour, InteractableObj
{
    
    
    
    public void OnUse()
    {
        Debug.Log("Interaced with TestInteraction");
    }
}
