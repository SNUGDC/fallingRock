using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface PlayerInput
{
	void ShowUU();
}

public interface PlayerOutput
{
	void MoveLeft();
	void MoveRight();
	void Shoot();
}

public class Player : MonoBehaviour, GameOverOutput, PlayerInput {
	[SerializeField]
	public PlayerColor color;

	[SerializeField]
	public int playerIndex;
    internal InputHandler input;
	public PlayerOutput output;
	[SerializeField]
	private Light _currentLight;
    private bool stop = false;

	[SerializeField]
	private Sprite defaultSprite;
	[SerializeField]
	private Sprite uuSprite;

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

    void PlayerInput.ShowUU()
    {
        StartCoroutine(ShowUUCoroutine());
    }

	IEnumerator ShowUUCoroutine()
	{
		GetComponent<Image>().sprite = uuSprite;
		yield return new WaitForSeconds(0.3f);
		GetComponent<Image>().sprite = defaultSprite;
	}
}
