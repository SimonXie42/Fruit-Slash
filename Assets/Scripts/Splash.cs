using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {

    private float time;

	// Use this for initialization
	void Start () {
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - time > 2f)
        {
            Destroy(gameObject);        // Remove Splash 2s after it appears
        }
	}
}
