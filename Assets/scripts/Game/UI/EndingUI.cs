using UnityEngine;
using UnityEngine.UI;

public class EndingUI : MonoBehaviour, GameOverOutput {
	[SerializeField]
	public PlayerColor color;
	[SerializeField]
	private Image image;
	bool gameEnd = false;

	public void OnTouchToMain()
	{
		SceneChanger.ChangeToScene("main");
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
			SceneChanger.ChangeToScene("main");
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
