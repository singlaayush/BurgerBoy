using UnityEngine;
using System.Collections;

public static class PlayerPrefManager {

	public static int GetScore() {
		if (PlayerPrefs.HasKey("Score")) {
			return PlayerPrefs.GetInt("Score");
		} else {
			return 0;
		}
	}

	public static void SetScore(int score) {
		PlayerPrefs.SetInt("Score",score);
	}

	public static int GetDistance() {
		if (PlayerPrefs.HasKey("Distance")) {
			return PlayerPrefs.GetInt("Distance");
		} else {
			return 0;
		}
	}

	public static void SetDistance(int distance) {
		PlayerPrefs.SetInt("Distance",distance);
	}

	public static int GetHighscore() {
		if (PlayerPrefs.HasKey("Highscore")) {
			return PlayerPrefs.GetInt("Highscore");
		} else {
			return 0;
		}
	}

	public static void SetHighscore(int highscore) {
		PlayerPrefs.SetInt("Highscore",highscore);
	}


	public static void SavePlayerState(int score, int highScore, int distance) {
		PlayerPrefs.SetInt("Score",score);
		PlayerPrefs.SetInt("Highscore",highScore);
		PlayerPrefs.SetInt ("Distance", distance);
	}

	public static void ResetPlayerState(bool resetHighscore) {
		Debug.Log ("Reset.");
		PlayerPrefs.SetInt("Score", 0);
		PlayerPrefs.SetInt ("Distance", 0);
		if (resetHighscore)
			PlayerPrefs.SetInt("Highscore", 0);
	}
}
