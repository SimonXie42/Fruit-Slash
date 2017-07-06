using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BestScore : MonoBehaviour {
    
    public Text text;
    
    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        text.text += PlayerPrefs.GetInt("highscore").ToString();
    }
}
