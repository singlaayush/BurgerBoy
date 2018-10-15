using UnityEngine;
using System.Collections;

public class SpawnerMoveScript : MonoBehaviour
{

	public float speed = 6f;
	public float maxSpeed = 8f;

	private Rigidbody2D rb2d;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate ()
	{
		float hor = speed;
		rb2d.velocity = new Vector2 (hor * maxSpeed, rb2d.velocity.y);
	}

}
