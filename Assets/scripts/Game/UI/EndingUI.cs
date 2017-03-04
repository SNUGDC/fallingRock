using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingUI : MonoBehaviour, GameOverOutput {
	[SerializeField]
	public PlayerColor color;
	[SerializeField]
	private Image image;
	bool gameEnd = false;

	public void OnTouchToMain()
	{
		SceneManager.LoadScene("main");
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if (!gameEnd) {
			return;
		}

		if (Input.GetKeyUp(KeyCode.Escape) ||
			Input.GetKeyUp(KeyCode.Space) ||
			Input.GetKeyUp(KeyCode.Return) ||
			Input.GetKeyUp(KeyCode.Backspace)) {
			SceneManager.LoadScene("main");
		}
	}

    void GameOverOutput.OnGameEnd(Player loser)
    {
		gameEnd = true;
		if (loser.color == color) {
        	image.enabled = true;
		}
    }
}
