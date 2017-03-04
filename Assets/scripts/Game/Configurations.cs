using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configurations : MonoBehaviour {
	public static Configurations Instance;

	public float rockDownSpeed = 1.0f;
	public float rockDownCool = 3.0f;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		Instance = this;
	}
}
