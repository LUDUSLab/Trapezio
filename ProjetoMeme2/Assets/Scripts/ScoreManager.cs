using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public Text ScoreText;
    private int Score;


	// Use this for initialization
	void Start ()
    {
        Score = 0;
	}
	
    public int GetScore()
    {
        return Score;
    }
    public void AddScore(int value)
    {
        Score += value;
    }
	// Update is called once per frame
	void Update ()
    {
        ScoreText.text = Score.ToString();
	}
}
