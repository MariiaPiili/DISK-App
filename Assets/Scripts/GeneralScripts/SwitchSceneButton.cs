using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneButton : MonoBehaviour
{
    public int SceneIndexToLoad;    
   
    public void SwitchScene()
    {        
        SceneManager.LoadScene(SceneIndexToLoad);
    }
}
