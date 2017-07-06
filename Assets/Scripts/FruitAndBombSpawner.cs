using UnityEngine;
using System.Collections;

public class FruitAndBombSpawner : MonoBehaviour {

    private float maxX = 5f;
    private float maxXVelocity = 2f;

    public GameObject fruit;
    public GameObject bomb;
    public AudioClip fuse;
    public AudioClip thud;
    private AudioSource audioSource;


    // Use this for initialization
    void Start () {

        InvokeRepeating("SpawnFruitsAndBomb", 3, 6f);      // To spawn them repeatedly every 3s 
        audioSource = GetComponent<AudioSource>();
    }

    void SpawnFruitsAndBomb ()
    {
        StartCoroutine("SpawnFruit");

        if (Random.Range(0, 6.5f) > 2)
        {
            SpawnBomb();
        }
    }

    IEnumerator SpawnFruit()
    {
        for (int i = 0; i < 5; i++)
        {
            float Rand1 = Random.Range(-maxX, maxX);
            float Rand2 = Random.Range(-maxXVelocity, maxXVelocity);
            Vector3 Pos = new Vector3(Rand1, transform.position.y, 0);
            GameObject f = Instantiate(fruit, Pos, Quaternion.identity) as GameObject;
            f.GetComponent<Rigidbody2D>().AddForce(new Vector2(Rand2, 15f), ForceMode2D.Impulse);       // Make fruit go up
            f.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-20f, 20f));       // Add rotation to the fruit 
            audioSource.clip = thud;
            audioSource.Play();
            yield return new WaitForSeconds(0.5f);      // Time before next fruit spawns 
        }
    }

    void SpawnBomb()
    {
        float Rand1 = Random.Range(-maxX, maxX);
        float Rand2 = Random.Range(-maxXVelocity, maxXVelocity);
        Vector3 pos = new Vector3(Rand1, transform.position.y, 0);
        GameObject b = Instantiate(bomb, pos, Quaternion.identity) as GameObject;
        b.GetComponent<Rigidbody2D>().AddForce(new Vector2(Rand2, 15f), ForceMode2D.Impulse);
        b.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-50f, 50f));
        audioSource.clip = fuse;
        audioSource.Play();
    }
}
