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
        //Debug.Log("pausou");
        Time.timeScale = 0;
    }
    void OnApplicationFocus(bool pauseState)
    {
        //Debug.Log("voltou");
        Time.timeScale = 1;
    }

}
