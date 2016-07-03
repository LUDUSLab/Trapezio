using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScore : MonoBehaviour {

    public Text ScoreText;
    public Text HighScoreText;

    // Use this for initialization
    void Start ()
    {
        ScoreText.text = PlayerPrefsManager.GetIntLocalValue(PlayerPrefsManager.LASTSCORE).ToString();
        HighScoreText.text = PlayerPrefsManager.GetIntLocalValue(PlayerPrefsManager.HIGHSCORE).ToString();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
