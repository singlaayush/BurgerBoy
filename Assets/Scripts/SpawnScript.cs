using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{

	public GameObject[] obj;
	public float spawnMin = 1f;
	public float spawnMax = 2f;
	public Transform offset;

	void Start ()
	{
		Spawn ();
	}

	void Spawn ()
	{
		int index = Random.Range (0, obj.GetLength (0));

		if (index == (obj.GetLength (0) - 1)) {
			Instantiate (obj [index], transform.position + offset.position, Quaternion.identity);
		} else {
			Instantiate (obj [index], transform.position, Quaternion.identity);
		}

		Invoke ("Spawn", Random.Range (spawnMin, spawnMax));
	}
}
