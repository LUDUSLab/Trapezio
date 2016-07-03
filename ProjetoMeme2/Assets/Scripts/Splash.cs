using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {

    public float SplashTime;
    public string NextSceneName;


	// Use this for initialization
	void Start () {
        Invoke("CallScene", SplashTime);
	}
	

    private void CallScene()
    {
        SceneManager.LoadScene(NextSceneName);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
