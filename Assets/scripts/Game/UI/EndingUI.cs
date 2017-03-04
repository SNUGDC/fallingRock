using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingUI : MonoBehaviour, GameOverOutput {
	[SerializeField]
	public PlayerColor color;
	[SerializeField]
	private Image image;

	public void OnTouchToMain()
	{
		SceneManager.LoadScene("main");
	}

    void GameOverOutput.OnGameEnd(Player loser)
    {
		if (loser.color == color) {
        	image.enabled = true;
		}
    }
}
