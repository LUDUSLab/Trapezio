using UnityEngine;
using System.Collections;

public class LifeBarManager : MonoBehaviour {

    public GameObject LifeBarObject;
    private int lifecount = 5;

	// Use this for initialization
	void Start () {
	    
	}
	
    public void ReduceLife(int count)
    {
        
        
        lifecount--;
        LifeBarObject.transform.GetChild(4 - lifecount).gameObject.SetActive(false);

        //LifeBarObject.transform.GetComponentInChildren<SelfDestruction>().DestroyItself();

        if (lifecount == 0)
        {
            GetComponent<GameOverController>().GameOver();
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
