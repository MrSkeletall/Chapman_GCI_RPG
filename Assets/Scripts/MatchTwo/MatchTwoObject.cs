using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MatchTwoObject : MonoBehaviour
{
    
    private SpriteRenderer spriteRenderer;

    private Sprite baseSprite;
    private Sprite matchSprite;
    
    private bool foundMatch = false;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseSprite = spriteRenderer.sprite;
    }


    public enum MatchType
    {
        Triangle,
        Circle,
        Square,
        Diamond,
    }
    
    public MatchType matchType;

    public MatchType GetMatchType()
    {
        return matchType;
    }

    public MatchType RandomMatchType()
    {
        int index = Random.Range(0, 3);

        switch (index)
        {
            case 0:
                return MatchType.Triangle;
            case 1:
                return MatchType.Circle;
            case 2: 
                return MatchType.Square;
        }
       
        Debug.LogError("Invalid index");
        return MatchType.Square;
    }


    public void SetMatchType(MatchType matchType)
    {
        this.matchType = matchType;
    }
    


    public void SetColor()
    {
        
    }

    public void SetMatchSprite(Sprite sprite)
    {
        matchSprite = sprite;
    }
    public void EnableMatchSprite()
    {
        spriteRenderer.sprite = matchSprite;
    }

    public void disableMatchSprite()
    {
        spriteRenderer.sprite = baseSprite;
    }


    public void FoundMatch()
    {
        foundMatch = true;
    }

    public bool HasMatch()
    {
        return foundMatch;
    }
    
   
}
