using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {
	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	void FixedUpdate()
	{
		var speed = Configurations.Instance.rockDownSpeed;
		transform.position -= new Vector3(0, Time.fixedDeltaTime * speed, 0);
	}
}
