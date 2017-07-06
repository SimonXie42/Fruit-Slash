using UnityEngine;

public class StartMenuFruit : MonoBehaviour {

    public GameObject cut1;
    public GameObject cut2;
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Line")
        {
            GameObject c1 = Instantiate(cut1, transform.position, cut1.transform.rotation) as GameObject;
            GameObject c2 = Instantiate(cut2, new Vector3(transform.position.x, transform.position.y - 2.5f, 0), cut2.transform.rotation) as GameObject;
            c1.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 1f), ForceMode2D.Impulse);
            c1.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-0.5f, 0.5f), ForceMode2D.Impulse);
            c2.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 0f), ForceMode2D.Impulse);
            Destroy(gameObject);
        }
    }
}

