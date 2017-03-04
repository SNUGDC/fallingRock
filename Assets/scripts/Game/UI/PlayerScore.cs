using System;
using UnityEngine;
using UnityEngine.UI;

public interface PlayerScoreInput {
	void scoreChanged(int score);
}
public class PlayerScore : MonoBehaviour, PlayerScoreInput {
	[SerializeField]
	public PlayerColor color;
	[SerializeField]
	private Text text;

    void PlayerScoreInput.scoreChanged(int score)
    {
        text.text = score.ToString();
    }
}
