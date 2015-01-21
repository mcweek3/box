using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
	public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
	public int attackDamage = 10;               // The amount of health taken away per attack.
	
	
	Animator anim;                              // Reference to the animator component.
	GameObject player;                          // Reference to the player GameObject.
	//	PlayerHealth playerHealth;                  // Reference to the player's health.
	//	EnemyHealth enemyHealth;                    // Reference to this enemy's health.
	bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
	float timer;                                // Timer for counting up to the next attack.
	public int enemyID = -1;

	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag ("Player");
		//		playerHealth = player.GetComponent <PlayerHealth> ();
		//		enemyHealth = GetComponent<EnemyHealth>();
		anim = GetComponent <Animator> ();
	}
	
	
	void OnTriggerEnter (Collider other)
	{
		// If the entering collider is the player...
		if(other.gameObject.tag == "you")
		{
			// ... the player is in range.
			enemyID = other.gameObject.GetComponent<PhotonView>().viewID;
			playerInRange = true;
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		// If the exiting collider is the player...
		if(other.gameObject.tag == "you")
		{
			// ... the player is no longer in range.
			playerInRange = false;
			enemyID = -1;
		}
	}
	
	
	void Update ()
	{
		// Add the time since Update was last called to the timer.
		timer += Time.deltaTime;
		
		
		// If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
		if(Input.GetButtonDown("Fire1") && timer >= timeBetweenAttacks && playerInRange /*&& enemyHealth.currentHealth > 0*/)
		{
			// ... attack.
			Attack ();
		}
		
		// If the player has zero or less health...
	}
	
	
	void Attack ()
	{
		// Reset the timer.
		timer = 0f;
		Debug.Log ("attack");
		int[] param = {attackDamage, enemyID};
		PhotonView.Get(this).RPC ("TakeDamage", PhotonTargets.All, attackDamage, enemyID);
		// If the player has health to lose...
		//		if(playerHealth.currentHealth > 0)
		//		{
		// ... damage the player.
		//			playerHealth.TakeDamage (attackDamage);
		//		}
	}



}