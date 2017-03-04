using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerOutput
{
	void MoveLeft();
	void MoveRight();
	void Shoot();
}

public class Player : MonoBehaviour, GameOverOutput {
	[SerializeField]
	public PlayerColor color;

	[SerializeField]
	public int playerIndex;
    internal InputHandler input;
	public PlayerOutput output;
	[SerializeField]
	private Light _currentLight;
    private bool stop = false;

    public Light currentLight {
		get {
			return _currentLight;
		}
		set {
			_currentLight = value;
			transform.SetParent(value.transform);
			var rectTransform = GetComponent<RectTransform>();
			rectTransform.anchoredPosition = Vector2.zero;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (stop) {
			return;
		}

		if (input.Left()) {
			output.MoveLeft();
		} else if (input.Right()) {
			output.MoveRight();
		} else if (input.Shoot()) {
			output.Shoot();
		}
	}

    void GameOverOutput.OnGameEnd(Player loser)
    {
        stop = true;
    }
}
