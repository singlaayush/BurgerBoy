using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public Transform Player;
	public float speed = 0.1f;
    ///     int x = Screen.width;
    ///     int y = Screen.height;
    ///     int s = 16;
    int x = Screen.width;
	int y = Screen.height;
	int s = 16;
	Camera cam;

	void Start(){
		cam = this.gameObject.GetComponent<Camera> ();
		//cam.orthographicSize = x / (((x / y) * 2) * s);
        Debug.Log(cam.orthographicSize + " Check it.");
	}

	public void Update ()
	{
		if (Player) {
			transform.position = Vector3.Lerp (transform.position, Player.position, speed) + new Vector3 (0, 0, -12);
		}
	}
}
