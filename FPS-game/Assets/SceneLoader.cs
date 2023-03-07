using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Reload()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
   public void stop()
    {
        Application.Quit();
    }
    
}
