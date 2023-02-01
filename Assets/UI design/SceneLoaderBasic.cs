using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderBasic : MonoBehaviour
{
    public Scene sceneToLoad;
    public void Start()
    {
        Application.targetFrameRate=60;
    }
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
    public void sceneLoad6()
    {
        SceneManager.LoadScene(6);
    }
    public void sceneLoad7()
    {
        SceneManager.LoadScene(7);
    }
    public void sceneLoad8()
    {
        SceneManager.LoadScene(8);
    }
    public void sceneLoad9()
    {
        SceneManager.LoadScene(9);
    }
    public void sceneLoad10()
    {
        SceneManager.LoadScene(10);
    }
    public void sceneLoad11()
    {
        SceneManager.LoadScene(11);
    }
    public void sceneLoad12()
    {
        SceneManager.LoadScene(12);
    }
    public void sceneLoad13()
    {
        SceneManager.LoadScene(13);
    }
    public void sceneLoad14()
    {
        SceneManager.LoadScene(14);
    }
    public void sceneLoad15()
    {
        SceneManager.LoadScene(15);
    }
    public void sceneLoad16()
    {
        SceneManager.LoadScene(16);
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
    
    public void loadNextLevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   
        
    }
}
