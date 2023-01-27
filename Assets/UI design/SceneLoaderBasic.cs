using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderBasic : MonoBehaviour
{
    public Scene sceneToLoad;

    public void sceneLoad1()
    {
        SceneManager.LoadScene(1);
    }
    public void sceneLoad2()
    {
        SceneManager.LoadScene(2);
    }
    public void sceneLoad3()
    {
        SceneManager.LoadScene(3);
    }
    public void sceneLoad4()
    {
        SceneManager.LoadScene(4);
    }
    public void sceneLoad5()
    {
        SceneManager.LoadScene(5);
    }

    public void sceneLoadMainMenu()
    {
        Time.timeScale = 1;
        
        SceneManager.LoadScene(0);
    }
    public void sceneLoadRestart()
    {
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
