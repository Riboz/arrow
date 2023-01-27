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
        SceneManager.LoadScene(0);
    }
}
