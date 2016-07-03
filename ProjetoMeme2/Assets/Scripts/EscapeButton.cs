using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EscapeButton : MonoBehaviour {

    public bool ExitGame;
    public string ExitGameSceneName;
    public bool PauseGame;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(ExitGame)
            {
                SceneManager.LoadScene(ExitGameSceneName);
            }
            
            if(PauseGame)
            {
                //se o jogo estiver pausado
                if(Time.timeScale == 0)
                {
                    //GetComponent<PauseController>().ResumeGame();
                    Time.timeScale = 1;
                    SceneManager.LoadScene(ExitGameSceneName);
                }
                else
                {
                    GetComponent<PauseController>().PauseGame();
                }
            }
        }
	}
}
