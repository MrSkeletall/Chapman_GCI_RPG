using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public abstract class DialougeBase : MonoBehaviour
{
    public string[] DialougeSet;
    
    
    public string[] GetDialougeSet()
    {
        return DialougeSet;
    }


    protected void SetActiveDialougeSet()
    {
        DialougeManager dialougeMan = Object.FindAnyObjectByType<DialougeManager>();
        dialougeMan.TriggerNewDialouge(this);
    }
    
    
    



}
