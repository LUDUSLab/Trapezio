using UnityEngine;
using System.Collections;

public class SelfDestroyAfterTime : MonoBehaviour {

    public float LifeTime;

    private float timeCreated;
	// Use this for initialization
	void Start () {
        timeCreated = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.realtimeSinceStartup - timeCreated > LifeTime)
        {
            DestroyObject(gameObject);
        }
        
	}
}
