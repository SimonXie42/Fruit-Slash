using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LineCreater : MonoBehaviour
{
    int vertexCount = 0;
    bool mouseDown = false;

    public GameObject blast;
    public AudioClip explosion;
    public AudioClip slice;
    public AudioClip squish;
    public GameObject WatermelonSplash;
    private LineRenderer lineRenderer;
    private AudioSource audioSource;
    private ScoreKeeper sk;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        audioSource = GetComponent<AudioSource>();
        sk = FindObjectOfType<ScoreKeeper>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
        }

        if (mouseDown)
        {
            if (audioSource.clip != squish && audioSource.clip != explosion)
            {
                audioSource.clip = slice;
                audioSource.volume = 0.5f;
                audioSource.Play();
            }

            lineRenderer.SetVertexCount(vertexCount + 1);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(vertexCount, mousePos);
            vertexCount++;

            BoxCollider2D box = gameObject.AddComponent<BoxCollider2D>();
            box.transform.position = transform.position;
            box.size = new Vector2(0.1f, 0.1f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
            vertexCount = 0;
            lineRenderer.SetVertexCount(0);         // Stop rendering the line
            BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();

            foreach (BoxCollider2D box in colliders)
            {
                Destroy(box);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Bomb")
        {
            GameObject b = Instantiate(blast, col.transform.position, Quaternion.identity) as GameObject;
            Destroy(col.gameObject);
            audioSource.clip = explosion;
            audioSource.Play();
            Invoke("LoadGameOver", 1f);        // Not using LevelManager because of the 1s delay
            sk.RecordHighScore();
        }

        else if (col.gameObject.tag == "Fruit")
        {
            audioSource.clip = squish;
            audioSource.Play();

            if(sk)      // In StartMenu there's no Scorekeeper
                sk.Score += 1;      

            Instantiate(WatermelonSplash, col.transform.position, Quaternion.identity);
        }
    }

    void LoadGameOver()
    {
        SceneManager.LoadScene(2);
    }
    
}