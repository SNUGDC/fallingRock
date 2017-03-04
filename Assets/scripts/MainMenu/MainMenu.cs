using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {
	public void OnStartButtonClicked() {
		Debug.Log("Start button click");
		SceneManager.LoadScene("game");
	}
}
