using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


//this is here to create different particles when ya hit the thing
[System.Serializable]
public struct MatchParticleParameters
{
    public float startSpeed;
    public float startSize;
    //public Color startColor;
    public float lifetime;
    public Sprite matchSprite;

    public MatchParticleParameters(Sprite sprite, float speed, float size, float life)
    {
        startSpeed = speed;
        startSize = size;
        matchSprite = sprite;
        //startColor = color;
        lifetime = life;
    }
}

public class MatchTwoGameManager : MonoBehaviour
{

    private bool MatchTwoGameActive = true;
    
    
    private GameObject firstChoice;
    private GameObject secondChoice;
    public GameObject LevelBlocker;

    public Sprite[] objectSprites;
    
    //private MatchTwoObject[] matchTwoObjects;

    public GameObject EffectBase;
    
    


    private void Start()
    {
        StartMatchTwoGame();
    }
    
    
    public void StartMatchTwoGame()
    {
        //generate random pairs
        GenerateNewMatches();
        SetMatchSprite();
        
        
    }

    public void AddPlayerChoice(GameObject choice)
    {
        addSelection(choice);
        MatchCheck();
    }
    
    
    public void SetFirstChoice(GameObject Choice)
    {
        this.firstChoice = Choice;
    }

    public void SetSecondChoice(GameObject Choice)
    {
        this.secondChoice = Choice;
    }

    
    
     private bool CompareChoices() 
     {
          
          MatchTwoObject.MatchType firstMatchType = firstChoice.GetComponent<MatchTwoObject>().matchType;
          MatchTwoObject.MatchType secondMatchType = secondChoice.GetComponent<MatchTwoObject>().matchType;


          if (firstMatchType == secondMatchType)
          {
              Debug.Log("The two choices are the same: " + firstMatchType + "  " + secondMatchType);
              return true;
          }
          return false;
     }


    
    
    private void ClearChoices()
    {
        firstChoice = null;
        secondChoice = null;
    }



    private void addSelection(GameObject selection)
    {
        if (firstChoice == null)
        {
            SetFirstChoice(selection);
            EnableMatchSprite(selection.GetComponent<MatchTwoObject>());
            Debug.Log("The first choice has been set");
        }
        else if (firstChoice != null && secondChoice == null)
        {
            SetSecondChoice(selection);
            EnableMatchSprite(selection.GetComponent<MatchTwoObject>());
            Debug.Log("The second choice has been set");
        }
        else
        {
            Debug.Log("Something might be wrong, objs:" + firstChoice.name + secondChoice.name);
        }
    }


    public void MatchCheck()
    {
        if (firstChoice != null && secondChoice != null)
        {
            if (CompareChoices())
            {
                Debug.Log("The two choices are the same:");
                firstChoice.GetComponent<MatchTwoObject>().FoundMatch();
                secondChoice.GetComponent<MatchTwoObject>().FoundMatch();
                
            }
            else
            {
                Debug.Log("Not a match");
                
                DisableMatchSprite(firstChoice.GetComponent<MatchTwoObject>());
                DisableMatchSprite(secondChoice.GetComponent<MatchTwoObject>());
            }

            if (CheckIfAllMatch())
            {
                OnGameComplete();
            }
            ClearChoices();

        }
        else
        {
            Debug.Log("Match Check has only one object");
        }
        
    }

    private bool CheckIfAllMatch()
    {
        MatchTwoObject[] matchObjects = GetMatchTwoObjects();
        
        foreach (MatchTwoObject mObj in matchObjects)
        {
            if (mObj.HasMatch() == false)
            {
                return false;
            }
        }
        return true;
    }


    private MatchTwoObject[] GetMatchTwoObjects()
    {
        MatchTwoObject[] matchTwoObjects = FindObjectsOfType<MatchTwoObject>();
        return matchTwoObjects;
    }


    private void GenerateNewMatches()
    {
        List<(MatchTwoObject, MatchTwoObject)> matchTwoObjects = SeparateIntoRandomPairs(GetMatchTwoObjects());
        
        

        foreach (var matchPair in matchTwoObjects)
        {
            MatchTwoObject.MatchType matchType = matchPair.Item1.RandomMatchType();
            
            matchPair.Item1.SetMatchType(matchType);
            matchPair.Item2.SetMatchType(matchType);

        }
        
    }
    
    List<(MatchTwoObject, MatchTwoObject)> SeparateIntoRandomPairs(MatchTwoObject[] array)
        {
            if (array.Length % 2 != 0)
            {
                Debug.LogError("Array length must be even to split into pairs.");
                return null;
            }

            List<MatchTwoObject> shuffledList = new List<MatchTwoObject>(array);
            for (int i = 0; i < shuffledList.Count; i++)
            {
                MatchTwoObject temp = shuffledList[i];
                int randomIndex = Random.Range(i, shuffledList.Count);
                shuffledList[i] = shuffledList[randomIndex];
                shuffledList[randomIndex] = temp;
            }

            List<(MatchTwoObject, MatchTwoObject)> pairs = new List<(MatchTwoObject, MatchTwoObject)>();
            for (int i = 0; i < shuffledList.Count; i += 2)
            {
                pairs.Add((shuffledList[i], shuffledList[i + 1]));
            }

            return pairs;
        }



    private void SetMatchSprite()
    {
        MatchTwoObject[] matchTwoObjects = GetMatchTwoObjects();

        foreach (MatchTwoObject matchTwoObject in matchTwoObjects)
        {
            MatchTwoObject.MatchType matchType = matchTwoObject.GetMatchType();
            switch (matchType)
            {
                case MatchTwoObject.MatchType.Triangle:
                    matchTwoObject.SetMatchSprite(objectSprites[0]);
                    break;
                case MatchTwoObject.MatchType.Circle:
                    matchTwoObject.SetMatchSprite(objectSprites[1]);
                    break;
                case MatchTwoObject.MatchType.Square:
                    matchTwoObject.SetMatchSprite(objectSprites[2]);
                    break;
                case MatchTwoObject.MatchType.Diamond:
                    matchTwoObject.SetMatchSprite(objectSprites[3]);
                    break;
                
                
            }
            
            
        }
        
    }


    private Sprite FindMatchSprite(MatchTwoObject matchObject)
    {
        MatchTwoObject.MatchType matchType = matchObject.GetMatchType();
        switch (matchType)
        {
            case MatchTwoObject.MatchType.Triangle:
                return objectSprites[0];
                
            case MatchTwoObject.MatchType.Circle:
                return objectSprites[1];
                
            case MatchTwoObject.MatchType.Square:
                return objectSprites[2];
                
            case MatchTwoObject.MatchType.Diamond:
                return objectSprites[3];
                
        }
        Debug.LogWarning("Match Sprite has not been found on " + matchObject.name);
        return objectSprites[0];
    }

    private void EnableMatchSprite(MatchTwoObject matchTwoObject)
    {
        matchTwoObject.EnableMatchSprite();
        MakeEffect(EffectBase, matchTwoObject);
    }

    private void DisableMatchSprite(MatchTwoObject matchTwoObject)
    {
        matchTwoObject.disableMatchSprite();
    }


    private void OnGameComplete()
    {
        LevelBlocker.gameObject.SetActive(false);
    }
    
    
    //get a particle system
    private MatchParticleParameters RandomEffectWithShape(Sprite sprite)
    {
        
        
        MatchParticleParameters particleParameters = new MatchParticleParameters(sprite, Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        
        
        return particleParameters;
    }

    private void SetParticleSystem(ParticleSystem particleSystem, MatchParticleParameters particleParameters)
    {
        Debug.Log("setting " + particleSystem.gameObject + " To" + particleParameters.matchSprite);
        particleSystem.textureSheetAnimation.SetSprite(0, particleParameters.matchSprite);
        //particleSystem.startSpeed = particleParameters.startSpeed;
    }

    private void MakeEffect(GameObject BaseParticle, MatchTwoObject matchTwoObj)
    {
        //
        GameObject effectInstance = Instantiate(BaseParticle, matchTwoObj.transform.position, quaternion.Euler(90, 0, 0));
        ParticleSystem particleSystem = effectInstance.GetComponent<ParticleSystem>();
        Sprite effectSprite = FindMatchSprite(matchTwoObj);
        MatchParticleParameters particleParameters = RandomEffectWithShape(effectSprite);
        
        SetParticleSystem(particleSystem, particleParameters);

        StartCoroutine(PlayAndDestroy(particleSystem));

        

    }


    private IEnumerator PlayAndDestroy(ParticleSystem particleSystem)
    {
        particleSystem.Play();
        Debug.Log("this particle system should be playing: "+ particleSystem.isPlaying);
        
       
            yield return new WaitWhile(() => particleSystem.IsAlive(true));

            Destroy(particleSystem.gameObject, 0.2f);




    }

     








    
}
