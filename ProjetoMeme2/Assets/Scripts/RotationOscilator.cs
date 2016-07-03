using UnityEngine;
using System.Collections;

public class RotationOscilator : MonoBehaviour {

    public float RotationBaseVelocity;
    public float RotationLimit;
    public float Acceleration;
    private Vector3 rotation;
    public float BaseRotation;
    private int multiplier = -1;


    public void AddSpeed(int count)
    {
        RotationBaseVelocity += count * Acceleration;
    }
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Time.timeScale == 0)
        {
            return;
        }
        rotation = transform.eulerAngles;
        // se z > 270

        if(rotation.z >= BaseRotation + RotationLimit)
        {
            multiplier = -1;
        }
        //se z < 90
        else if(rotation.z <= BaseRotation - RotationLimit)
        {
            multiplier = 1;
        }

        rotation.z += multiplier * RotationBaseVelocity;
        transform.eulerAngles = rotation;

        //Debug.Log(transform.eulerAngles);
    }
}
