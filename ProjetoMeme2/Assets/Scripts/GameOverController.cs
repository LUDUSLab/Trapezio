using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	

    public void GameOver()
    {
        int highScore = PlayerPrefsManager.GetIntLocalValue(PlayerPrefsManager.HIGHSCORE);
        int score = GetComponent<ScoreManager>().GetScore();

        if(score > highScore)
        {
            PlayerPrefsManager.UpdateIntLocalValue(PlayerPrefsManager.HIGHSCORE, score);
        }
        
        PlayerPrefsManager.UpdateIntLocalValue(PlayerPrefsManager.LASTSCORE, score);

        SceneManager.LoadScene("Game_Over");

        //Application.LoadLevel("Game_Over");
    }
	// Update is called once per frame
	void Update () {
	
	}
}

