using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    public Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	
	}
}
