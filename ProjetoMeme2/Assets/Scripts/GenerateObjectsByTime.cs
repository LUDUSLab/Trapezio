using UnityEngine;
using System.Collections;

public class GenerateObjectsByTime : MonoBehaviour {

    public float TimeInterval;
    public GameObject[] ObjectsToGenerate;
    private int randomNumber;
    //private GameObject obj;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Update2", 0, TimeInterval);
  
	}
	private void Update2()
    {
        randomNumber = Random.Range(0, ObjectsToGenerate.Length - 1);

        Instantiate(ObjectsToGenerate[randomNumber]);
        
    }

  

	// Update is called once per frame
	void Update () {
	
	}
}
