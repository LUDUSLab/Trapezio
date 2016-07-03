using UnityEngine;
using System.Collections;

public class MovimentoMuro : MonoBehaviour {

	private Material currentMaterial;
	public float speed;
	private float offset;

	// Use this for initialization
	void Start () {
		
		currentMaterial = GetComponent<Renderer> ().material;
		//InvokeRepeating ("HighSpeed", 0, 2);
	}

	// Update is called once per frame
	void Update () {

		offset += speed * Time.deltaTime;
		currentMaterial.SetTextureOffset ("_MainTex", new Vector2 (0,offset));

	}
	//void HighSpeed(){

	//speedCenario = speedCenario + 0.01f;

	//}
}
