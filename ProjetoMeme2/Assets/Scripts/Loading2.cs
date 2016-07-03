using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Loading2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneManager.LoadScene("Game");
		//Application.LoadLevel("Game");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
