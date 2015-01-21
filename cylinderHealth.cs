using UnityEngine;
using System.Collections;

public class cylinderHealth : MonoBehaviour {

	float starthealth;
	public  Transform cylinder;
	// Use this for initialization
	void Start () {
		cylinder = this.gameObject.transform.FindChild("Cylinder");
		starthealth = cylinder.transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void cylinderhealthdown(float amount){
		Debug.Log ("cylinder");
		Debug.Log ("localscale" + cylinder.localScale.y);

		Vector3 scale = cylinder.localScale;
		scale.y = scale.y - starthealth * amount / 100; // your new value
		if(cylinder.localScale.y > 0)
			cylinder.localScale = scale;

//		float temp = starthealth * amount / 100;
//		float temp2 = cylinder.transform.localScale.y;
//		Vector3 vector = Vector3.zero;
//		cylinder.transform.localScale += Vector3(0.1,0,0);
	//		cylinder.transform.localScale.y = 1;
		//cylinder.position = vector;
	}
}
