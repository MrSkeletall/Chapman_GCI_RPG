using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class DialougeManager : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    public float textSpeed = 1f;
    public int lineNumber;
    private string[] currentDialouge;
    
    
    private bool inDialouge = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        lineNumber = 0;
        DisableDialougeBox();
    }



    void Update()
    {
        if(inDialouge && Input.GetKeyDown(KeyCode.Space))
        {
            if (textBox.text != currentDialouge[lineNumber])
            {
                Debug.Log("Stopping textPrint");
                StopAllCoroutines();
            }
            NextLine();
        }
    }

    
    IEnumerator TypeLine()
    {
        textBox.text = String.Empty;
        foreach (char c in currentDialouge[lineNumber])
        {
            textBox.text += c;
            yield return new WaitForSeconds(textSpeed);
            
        }
    }


    //called by DialougeBase Class to set new lines
    public void TriggerNewDialouge(DialougeBase dialougeSet)
    {
        ClearDialouge();
        SetCurrentDialouge(dialougeSet.GetDialougeSet());
        StartDialouge();
    }


    public void StartDialouge()
    {
        inDialouge = true;
        
        ClearDialouge();
        EnableDialougeBox();
        lineNumber = 0;
        
        StartCoroutine(TypeLine());

    }


    public void OnDialougeEnd()
    {
        inDialouge = false;
        DisableDialougeBox();
        lineNumber = 0;
        
    }
    
    
   

    void NextLine()
    {
        
        if (lineNumber < currentDialouge.Length - 1)
        {
            lineNumber++;
            
            StartCoroutine(TypeLine());
        }
        else
        {
            OnDialougeEnd();
        }
    }


    public void SetCurrentDialouge(string[] lines)
    {
        currentDialouge = lines;
    }
    

    void EnableDialougeBox()
    {
        textBox.transform.parent.gameObject.SetActive(true);
    }

    void DisableDialougeBox()
    {
        textBox.transform.parent.gameObject.SetActive(false);
    }
    
    void ClearDialouge()
    {
        textBox.text = String.Empty;
        StopAllCoroutines();
        
    }
    
    
    
    
    
    
}
