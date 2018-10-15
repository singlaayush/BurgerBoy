using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour
{

	public int coinValue = 1;
	[HideInInspector]
	public bool taken = false;
	public static GameManager gameManager;

	void Start(){
		gameManager = GameObject.FindGameObjectWithTag ("Game Manager").GetComponent<GameManager>();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if ((other.tag == "Player") && (!taken)) {
			taken = true;
			gameManager.AddPoints (coinValue);
				
			other.gameObject.GetComponent<AudioSource> ().PlayOneShot (other.gameObject.GetComponent<AudioSource> ().clip);

			DestroyObject (this.gameObject);
		}
	}

}