﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour {
	public void OnTouch()
	{
		SceneManager.LoadScene("main");
	}
}
