using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface RockOutput {
    void OnBoom(Rock target);
}

public class Rock : MonoBehaviour {
	public SpawnPoint sSpawnPoint;
	public RockOutput output;

	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	void FixedUpdate()
	{
		var speed = Configurations.Instance.rockDownSpeed;
		transform.position -= new Vector3(0, Time.fixedDeltaTime * speed, 0);
	}

    internal void Boom()
    {
		output.OnBoom(this);
        Destroy(gameObject);
    }
}
