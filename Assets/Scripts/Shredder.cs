using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Shredder : MonoBehaviour
{

    public GameObject[] Missed;
    public GameObject RedX;
    public GameObject BlackX;
    private ScoreKeeper sk;

    void Start()
    {
        sk = FindObjectOfType<ScoreKeeper>();
    }

    void Update()
    {
        BlackX = GameObject.FindGameObjectWithTag("BlackX");

        if (!BlackX)
        {
            Invoke("LoadGameOver1", 1f);        // Need to continuously check if there's BlackX left, thus called in Update rather than OnTriggerEnter
            sk.RecordHighScore();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(collider.gameObject);

        if (collider.gameObject.tag == "Fruit")
        {
            foreach (GameObject miss in Missed)
            {
                if (miss)
                {
                    Instantiate(RedX, miss.transform.position, Quaternion.identity);
                    Destroy(miss.gameObject);
                    break;
                }
            }
        }
    }

    void LoadGameOver1()
    {
        SceneManager.LoadScene(3);
    }
}
    

