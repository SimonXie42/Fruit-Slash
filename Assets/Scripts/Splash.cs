using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 2f);        // Remove Splash 2s after it appears
	}
}
