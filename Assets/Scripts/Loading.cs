using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Loading : MonoBehaviour {

	public GameObject LoadingScene;
	public Slider LoadingBar;

	public void Awake ()
	{
		StartCoroutine (LevelCoroutine ());
	}
	IEnumerator LevelCoroutine ()
	{
		LoadingScene.SetActive (true);
        AsyncOperation async = SceneManager.LoadSceneAsync (1);

		while (!async.isDone) {
			LoadingBar.value = async.progress / 0.9f;
			Debug.Log (LoadingBar.value);
			yield return null;
		}
	}
}