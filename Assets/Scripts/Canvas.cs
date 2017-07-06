using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Canvas : MonoBehaviour {
    
    public AudioClip startGame;
    private GameObject fruitCut;
    private AudioSource audioSource;
    private StartMenuFruit fruit;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //StartMenuFruit must be active on Start for it to be found, then immediately set to inactive.
        fruit = FindObjectOfType<StartMenuFruit>();
        fruit.gameObject.SetActive(false);  

        Invoke("MakeStartMenuFruitVisible", 1.5f);
    }

    void Update()
    {
        fruitCut = GameObject.FindGameObjectWithTag("FruitCut");

        if (fruitCut && audioSource.clip != startGame)
        {
            audioSource.clip = startGame;
            audioSource.Play();
            Invoke("LoadGame", 1.5f);
        }
    }


    void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    /* This method is implemented to address the issue of the fruit rendering on top of the 
     * fade panel. It is not in StartMenuFruit.cs since an inactive object can't set 
     * itself active. The fruit shall become visible after the fade in effect. */

    void MakeStartMenuFruitVisible()       
    {
        fruit.gameObject.SetActive(true);
    }
}
