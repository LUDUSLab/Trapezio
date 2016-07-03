using UnityEngine;
using System.Collections;

public class PlayOneSound : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip Acerto;
    public AudioClip Erro;
    public AudioClip Critico;
    public AudioClip Peso;


    // Use this for initialization
    void Start () {
	
	}
	
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
