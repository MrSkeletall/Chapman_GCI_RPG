using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    
    public string sceneToLoad = "MatchTwo";
    
  
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }



    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeScene(sceneToLoad);
    }


}
