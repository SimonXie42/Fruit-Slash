using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
    
    int time = 60;

    private Text text;
    private ScoreKeeper sk;
    private LevelManager lm;


    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        sk = FindObjectOfType<ScoreKeeper>();
        lm = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update () {
        Invoke("Timer", 2);        
	}

    void Timer()
    {
        /* Cast to int to only display seconds, else I find it too distracting.
           The +3 compensates for the 2s invoke delay, which serves to ease the game in. */

        text.text = ((int)(time - Time.timeSinceLevelLoad + 3)).ToString();     

        if (((int)(time - Time.timeSinceLevelLoad + 3)) == 0)
        {
            sk.RecordHighScore();
            lm.LoadGameOver2();
        }
    }
}
