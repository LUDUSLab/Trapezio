using UnityEngine;
using System.Collections;

public class OnAppPause : MonoBehaviour {// Controller that holds muted state
    private bool  MutedState;
    public bool CallPauseScreen;
    private bool Paused;
    
    // Use this for initialization
    void Awake()
    {
        Application.runInBackground = false;
        DontDestroyOnLoad(transform.gameObject);
        if(GameObject.FindGameObjectsWithTag("IndestructibleObj").Length!= 1)
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnApplicationPause(bool pauseState)
    {
        bool IsGamePaused = false;
        if (GameObject.FindGameObjectWithTag("GameController"))
        {
            GameObject Controller = GameObject.FindGameObjectWithTag("GameController");
            IsGamePaused = Controller.GetComponent<PauseController>().GetPausedState();
        }
        //Debug.Log("pausou");
        if (pauseState)
        {
            Time.timeScale = 0;
        }
        else
        {
            if(!IsGamePaused)
            Time.timeScale = 1;
        }
    }
    /*void OnApplicationFocus(bool pauseState)
    {
        //Debug.Log("voltou");
        Time.timeScale = 1;
    }*/

}
