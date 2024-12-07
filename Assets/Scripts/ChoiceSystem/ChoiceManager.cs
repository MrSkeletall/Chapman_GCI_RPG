using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChoiceManager : MonoBehaviour, InteractableObj
{
    public GameObject textBoxPrefab;
    public string dialogue;
    public Canvas canvas;
    // 0 is yes : 1 is no
    [SerializeField] private int choiceMemory;
    private bool choosing;
    private GameObject textBox;
    public void OnUse()
    {
        //Instantiates textBox object and updates the text while also setting the choosing bool = to true
        if (textBox != null)
        {
            DestroyTextBox();
        }
        textBox = Instantiate(textBoxPrefab, canvas.gameObject.transform.position,canvas.gameObject.transform.rotation );
        textBox.transform.parent = canvas.transform;
        textBox.GetComponentInChildren<TextMeshProUGUI>().text = dialogue;
        choosing = true;
        Debug.Log("Choice Box Instantiated");

    }
    public void Update()
    {
        if (choosing)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                PlayerMadeChoice(0);
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                PlayerMadeChoice(1);
            }
        }
    }
    private void SceneTransition()
    {
        //transistion to the minigame phase
        //pause timer
        //whatever else you have to do
    }
    private void PlayerMadeChoice(int choiceNumber)
    {
        choiceMemory = choiceNumber;
        choosing = false ;
        DestroyTextBox();
    }
    private void DestroyTextBox()
    {
        Destroy(textBox);
    }
    
    

}
