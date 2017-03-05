using System;
using UnityEngine;

public class Configurations : MonoBehaviour {
	public static Configurations Instance;

	// public float rawRockDownDistance = 200.0f;
	public float rawRockDownCool = 2.0f;
	public float rawRockDownSpeed = 200.0f;
	
	[NonSerialized]
	private int difficulty = 10;

	public void IncreaseDifficulty() {
		difficulty += 10;
	}

    public float rockDownDistance { 
		get {
			return rawRockDownCool * rawRockDownSpeed;
			// return rawRockDownDistance;
		}
	}
    public float rockDownCool {
		get {
			var defaultDistance = rawRockDownCool * rawRockDownSpeed;
			var newDistance = defaultDistance / Mathf.Log10(difficulty);
			return newDistance / rawRockDownSpeed;
			// var defaultSpeed = rawRockDownDistance / rawRockDownCool;
			// var newSpeed = defaultSpeed * Mathf.Log10(difficulty);
			// return rawRockDownDistance / newSpeed;
		}
	}

    public float rockDownSpeed {
		get {
			return rawRockDownSpeed;
			// return rockDownDistance / rockDownCool;
		}
	}


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
	{
		Instance = this;
	}
}
