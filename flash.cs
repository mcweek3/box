using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class flash : MonoBehaviour {

	public Image damageimage;
	// Use this for initialization
	void Start () {
		damageimage = this.gameObject.GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Flash(){
		damageimage.color = Color.red;
	}
	void unflash(){
		damageimage.color = Color.clear;
	}
}
