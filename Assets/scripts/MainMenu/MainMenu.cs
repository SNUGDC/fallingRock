using UnityEngine;

public class MainMenu : MonoBehaviour {
	public void OnStartButtonClicked() {
		Debug.Log("Start button click");
		SceneChanger.ChangeToScene("game");
	}

	public void OnCreditButtonClicked() {
		SceneChanger.ChangeToScene("credit");
	}
}
