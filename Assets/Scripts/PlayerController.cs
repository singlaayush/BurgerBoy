using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	
	public float speed = 2f;
	public float jumpForce = 1700f;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public LayerMask whatIsDeath;
	public float verticalSpeed = 20;
	public float maxSpeed = 4f;
	public GameObject Cam;
	private Rigidbody2D rb2d;
	private CameraController mycam;
	private bool isGrounded = false;
	private bool isDead = false;
	private GameManager gameManager;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		gameManager = GameObject.FindGameObjectWithTag ("Game Manager").GetComponent<GameManager>();
		mycam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraController> ();
	}

	void Update ()
	{
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.15F, whatIsGround);
		isDead = Physics2D.OverlapCircle (groundCheck.position, 0.15F, whatIsDeath);
        if (Input.GetButtonDown ("Jump") && (isGrounded)) {
			rb2d.AddForce (new Vector2 (0, jumpForce));
		}
		if (isDead) {
			mycam.enabled = false;
			Cam.GetComponent<AudioSource> ().enabled = false;
			GetComponent<Animator>().speed = 0;
			StartCoroutine (reset ());
		}
		if (this.transform.localPosition.y < -10) {
			mycam.enabled = false;
			Cam.GetComponent<AudioSource> ().enabled = false;
			StartCoroutine (reset ());
		}
	}

	IEnumerator reset(){
		yield return new WaitForSeconds(1f);
		gameManager.ResetGame ();
	}

	void FixedUpdate ()
	{
		if (isGrounded) {
			gameManager.updateDistance ();
		}
		float hor = speed;

		rb2d.velocity = new Vector2 (hor * maxSpeed, rb2d.velocity.y);
	}
}
