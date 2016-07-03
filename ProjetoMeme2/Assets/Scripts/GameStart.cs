using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameStart : MonoBehaviour {

    public GameObject TutorialObj;
    public Button PauseButton;

	// Use this for initialization
	void Start ()
    {
        if (PlayerPrefsManager.GetIntLocalValue(PlayerPrefsManager.TUTORIAL) == 1)
        {
            CloseTutorial();
        }
        else
        {
            Time.timeScale = 0;
            PauseButton.gameObject.SetActive(false);
            PlayerPrefsManager.UpdateIntLocalValue(PlayerPrefsManager.TUTORIAL, 1);
        }
        
	}
	
    public void CloseTutorial()
    {
        //Debug.Log("Hello button clock");
        TutorialObj.SetActive(false);
        Time.timeScale = 1;
        PauseButton.gameObject.SetActive(true);
    }

	// Update is called once per frame
	void Update ()
    {
    }
	
}
