using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    public void LoadGameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadGameOver1()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadGameOver2()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }
}

