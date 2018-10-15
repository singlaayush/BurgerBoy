using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

	public static GameManager gm;

	public string levelAfterGameOver;

	public int score = 0;
	public int highscore = 0;
	float distance = 0;
	int lastDist = 0;

	public Sprite PlaySprite;
	public Sprite PauseSprite;
	public Image UIPause;
	public Text UIDistance;
	public Text UIGobbled;
	public GameObject UIGamePaused;
	public GameObject Cam;
	public GameObject _player;
	int x = 1;

	void Awake ()
	{
		if (gm == null)
			gm = this.GetComponent<GameManager> ();

		setupDefaults ();
	}

	public void Quit ()
	{
		Debug.Log ("Quit");
		Application.Quit ();
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Pause ();
		}

		distance += Time.deltaTime * Random.Range (23, 78);
	}

	public void Pause ()
	{
		if (Time.timeScale > 0f) {
			UIGamePaused.SetActive (true); 
			Cam.GetComponent<AudioSource> ().volume = 0.2f;
			UIPause.sprite = PlaySprite;
			Time.timeScale = 0f;
		} else {
			Time.timeScale = 1f;
			Cam.GetComponent<AudioSource> ().volume = 1f;
			UIPause.sprite = PauseSprite;
			UIGamePaused.SetActive (false);
		}
	}

	public void updateDistance ()
	{
		lastDist = ((int)distance);
		UIDistance.text = "Distance: " + lastDist.ToString ();
		if (distance > 300 * x) {
			x++;
			_player.GetComponent<PlayerController> ().speed += 0.2f;
		}
	}

	void setupDefaults ()
	{
		if (levelAfterGameOver == "") {
			levelAfterGameOver = SceneManager.GetActiveScene().name;
		}
	
		refreshPlayerState ();

		refreshGUI ();
	}

	void refreshPlayerState ()
	{
		score = PlayerPrefManager.GetScore ();
		highscore = PlayerPrefManager.GetHighscore ();
	}

	void refreshGUI ()
	{
		UIGobbled.text = "Gobbled: " + score.ToString ();
	}

	public void AddPoints (int amount)
	{
		score += amount;

		UIGobbled.text = "Gobbled: " + score.ToString ();

		if (score > highscore) {
			highscore = score;
		}
	}

	public void ResetGame ()
	{
		refreshGUI ();
		PlayerPrefManager.SavePlayerState (score, highscore, ((int)lastDist));
		SceneManager.LoadScene (levelAfterGameOver);
	}
}
