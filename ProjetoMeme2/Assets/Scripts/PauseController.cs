using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseController : MonoBehaviour {

    public Button PauseButton;
    public Button ResumeButton;
    public AudioSource AudioFont;
    private bool IsPaused;
    // Use this for initialization
    void Start () {
   
    }
	
    public void PauseGame()
    {
        this.IsPaused = true;
        //oculta o botão de pause
        PauseButton.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        PauseButton.interactable = false;

        //silencia a fonte de som dos estados
        AudioFont.volume = 0;

        // mostra o botão de resumo
        ResumeButton.gameObject.SetActive(true);
        ResumeButton.interactable = true;
        

        //para o tempo
        Time.timeScale = 0;
        

    }

    public void ResumeGame()
    {
        this.IsPaused = false;
        //Debug.Log("resume click");
        // ativa o botao de pause
        PauseButton.interactable = true;

        //volta o tempo ao normal
        Time.timeScale = 1;

        //mostra o botao de pause
        PauseButton.GetComponent<Image>().color = new Color(255, 255, 255, 1);

        //oculta o botão de resumo
        ResumeButton.interactable = false;
        ResumeButton.gameObject.SetActive(false);

        //ativa o volume da fonte de som
        AudioFont.volume = 1;
        
    }

	// Update is called once per frame
	void Update () {
	
	}
    public bool GetPausedState()
    {
        return this.IsPaused;
    }
}
