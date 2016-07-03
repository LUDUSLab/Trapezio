using UnityEngine;
using System.Collections;

public class SelfDestruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public void DestroyItself()
    {
        Destroy(this);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
