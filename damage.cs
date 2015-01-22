using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class damage : MonoBehaviour {
	
	public Slider healthbar;
	// Use this for initialization
	void Start () {
		healthbar = this.gameObject.GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void damagehealth(int amount){
		healthbar.value = healthbar.value - amount; 
	}
}
