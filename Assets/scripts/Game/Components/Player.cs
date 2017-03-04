using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerOutput
{
	void MoveLeft();
	void MoveRight();
	void Shoot();
}

public class Player : MonoBehaviour {

	[SerializeField]
	public int playerIndex;
    internal InputHandler input;
	public PlayerOutput output;
	[SerializeField]
	private Light _currentLight;
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
		if (input.Left()) {
			output.MoveLeft();
		} else if (input.Right()) {
			output.MoveRight();
		} else if (input.Shoot()) {
			output.Shoot();
		}
	}
}
