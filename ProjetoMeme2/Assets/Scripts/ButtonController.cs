using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonController : MonoBehaviour {
	private string LevelToLoad;
    public AudioSource audioSource;
    public AudioClip buttonClickSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void LoadScene(string Level){
        SceneManager.LoadScene(Level);
        //Application.LoadLevel (Level);
	}
	public void LevelOnClick(string Level){
		LevelToLoad = Level;
	}
	public void LoadIf(string Scene){
		if (PlayerPrefs.GetInt (Scene + "Unlocked") == 1) {
            SceneManager.LoadScene(LevelToLoad);
            //Application.LoadLevel(LevelToLoad);
        }
	}

    public void PlaySound()
    {
        audioSource.PlayOneShot(buttonClickSound);
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
