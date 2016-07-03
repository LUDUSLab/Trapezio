using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("Hello1");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hello2");
    }
}
