using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

    public static string HIGHSCORE = "HIGHSCORE";   //int value
    public static string LASTSCORE = "LASTSCORE";   //int value
    public static string MUTE = "MUTE"; //int value (true = 1, false = 0)
    public static string TUTORIAL = "TUTORIAL"; //int value (já rodou = 1, não rodou = 0) 

    // Use this for initialization
    void Start () {
	
	}
	
    public static void UpdateIntLocalValue(string param, int value)
    {
        PlayerPrefs.SetInt(param, value);
        
    }

    public static int GetIntLocalValue(string param)
    {
        return PlayerPrefs.GetInt(param);
    }
    

	// Update is called once per frame
	void Update () {
	
	}
}
