using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonLoadLevel : MonoBehaviour {

	public Text HS;

	void Start(){
		if (HS) {
			HS.text = "High Score : " + PlayerPrefManager.GetHighscore ().ToString ();
		}
	}

	public void loadLevel(string leveltoLoad)
	{
		PlayerPrefManager.ResetPlayerState (false);
		SceneManager.LoadScene (leveltoLoad);
	}

	public void Quit(){
		Debug.Log ("Quit");
		Application.Quit ();
	}
}
