using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour {

	public Text UIDistance;
	public Text UIGobbled;
	public GameObject HSUI;

	void Start () {
		UIDistance.text = "Distance: " + PlayerPrefManager.GetDistance ();
		UIGobbled.text = "Gobbled: " + PlayerPrefManager.GetScore ();
		if (PlayerPrefManager.GetHighscore() == PlayerPrefManager.GetScore()) {
			HSUI.SetActive (true);
		}
	}
}
