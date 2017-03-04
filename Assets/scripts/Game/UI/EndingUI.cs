using System;
using UnityEngine;
using UnityEngine.UI;

public class EndingUI : MonoBehaviour, GameOverOutput {
	[SerializeField]
	public PlayerColor color;
	[SerializeField]
	private Image image;

	public void Show()
	{
		image.enabled = true;
	}

    void GameOverOutput.OnGameEnd(Player loser)
    {
		if (loser.color == color) {
        	Show();
		}
    }
}
