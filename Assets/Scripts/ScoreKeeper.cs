using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

    public int Score = 0;
    public ScoreDisplay sd;

	// Use this for initialization
	void Start () {
        sd = FindObjectOfType<ScoreDisplay>();
    }

    // Update is called once per frame
    void Update () {
        sd.text.text = Score.ToString();
	}

    public void RecordHighScore()
    {
        if (Score > PlayerPrefs.GetInt("highscore"))
            PlayerPrefs.SetInt("highscore", Score);
    }
}
