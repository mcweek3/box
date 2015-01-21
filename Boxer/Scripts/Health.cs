using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour
{
	public int startingHealth = 100;
	public int currentHealth;
	//public Slider healthSlider;
	//public Image damageImage;
	public AudioClip deathClip;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 1f);
	GameObject HUD;
	GameObject healthbar;
	
//	Animator anim;
//	AudioSource playerAudio;
	ThirdPersonControllerNET playerMovement;
	EnemyAttack attacking;

	//PlayerShooting playerShooting;
	bool isDead;
	bool damaged;
	
	
	void Awake ()
	{
//		playerAudio = GetComponent <AudioSource> ();
		playerMovement = GetComponent <ThirdPersonControllerNET> ();
		attacking = GetComponent<EnemyAttack> ();
		//playerShooting = GetComponentInChildren <PlayerShooting> ();
		currentHealth = startingHealth;
		HUD = GameObject.FindGameObjectWithTag ("HUD");
		healthbar = GameObject.FindGameObjectWithTag ("healthbar");
	}
	
	//a
	void Update ()
	{	
		GameObject temp = GameObject.FindGameObjectWithTag ("me");
		Debug.Log ("update");
		if(damaged)
		{
			Debug.Log("flash");
		//	damageImage.color = flashColour;
			HUD.transform.SendMessage ("Flash");
			Debug.Log ("flash");
		}
		else
		{
		//	damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
			HUD.transform.SendMessage ("unflash");
			Debug.Log("else");
		}
		damaged = false;
	}
	
	[RPC]
	public void TakeDamage (int damage, int id)
	{
		Debug.Log (id + " got attacked: " + damage);
//		PhotonPlayer pp = PhotonPlayer.Find (id);
		GameObject target = PhotonView.Find (id).gameObject;
		target.GetComponent<Health>().currentHealth -= 10;
		target.transform.SendMessage ("cylinderhealthdown", damage);
	}

	public void RealDamage(int amount){
		Debug.Log (transform.tag);
		damaged = true;
		currentHealth -= amount;

		healthbar.transform.SendMessage ("damagehealth",amount);
		//healthSlider.value = currentHealth;

		//		playerAudio.Play ();

		
		if(currentHealth <= 0 && !isDead)
			
		{
			Death ();
		}
		
		Debug.Log ("attacked2");

	}
	
	void Death ()
	{
		isDead = true;
		
		//playerShooting.DisableEffects ();

		
//		playerAudio.clip = deathClip;
//		playerAudio.Play ();
		playerMovement.enabled = false;
		attacking.enabled = false;
		//playerShooting.enabled = false;
	}
	
	
	public void RestartLevel ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

}
